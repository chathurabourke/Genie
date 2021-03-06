﻿#region Usings

using System;
using System.Linq;
using Genie.Core.Base.Configuration.Abstract;
using Genie.Core.Base.Configuration.Concrete;
using Genie.Core.Base.Exceptions;
using Genie.Core.Base.Files.Abstract;
using Genie.Core.Base.Files.Concrete;
using Genie.Core.Base.Generating;
using Genie.Core.Base.ObstacleManaging;
using Genie.Core.Base.ProcessOutput.Abstract;
using Genie.Core.Base.ProcessOutput.Concrete;
using Genie.Core.Base.ProjectFileManaging;
using Genie.Core.Base.Reading.Concrete;
using Genie.Core.Base.Versioning.Abstract;
using Genie.Core.Base.Versioning.Concrete;
using Genie.Core.Base.Writing;
using Genie.Core.Tools;
using Newtonsoft.Json;

#endregion

namespace Genie.Core.Base
{
    /// <summary>
    ///     The base genie class that only provides a static method to generate
    /// </summary>
    public static class Genie
    {
        /// <summary>
        ///     Generates the Data Access Layer using given configuration file
        /// </summary>
        /// <param name="pathToConfigurationJsonFile">the full readable path to the configuration JSON file.</param>
        /// <param name="output">Just implement your own one and pass it here</param>
        /// <returns>the result of the generation process</returns>
        public static GenieGenerationResult Generate(string pathToConfigurationJsonFile, IProcessOutput output)
        {
            return GenerateInternal(pathToConfigurationJsonFile, output);
        }

        /// <summary>
        ///     Generates the Data Access Layer using given configuration file.
        /// </summary>
        /// <param name="pathToConfigurationJsonFile">the full readable path to the configuration JSON file.</param>
        /// <returns>the result of the generation process</returns>
        public static GenieGenerationResult Generate(string pathToConfigurationJsonFile)
        {
            return GenerateInternal(pathToConfigurationJsonFile, new NonFunctioningProcessOutput());
        }


        private static GenieGenerationResult GenerateInternal(string pathToConfigurationJsonFile, IProcessOutput output)
        {
            var result = new GenieGenerationResult();
            IConfiguration config = null;
            IFileSystem fileSystem = new GenieFileSystem();
            IVersionManager versionManager = new GenieVersionManager(fileSystem);

            using (var progress = output.Progress(7, "Generating", "Done!"))
            {
                try
                {
                    if (!fileSystem.Exists(pathToConfigurationJsonFile))
                        throw new GenieException(
                            $"The configuration file ({pathToConfigurationJsonFile}) could not be found.\nPlease make sure that the genieSettings.json file exists in the location.");

                    progress.Tick("Reading Configuration File");
                    try
                    {
                        config = JsonConvert.DeserializeObject<GenieConfiguration>(
                            fileSystem.ReadText(pathToConfigurationJsonFile));

                        config.Setup();
                    }
                    catch (GenieException exception)
                    {
                        throw;
                    }
                    catch (Exception exception)
                    {
                        throw new GenieException(
                            $"Unable to read the configuration file ({exception.Message}), The configuration file must be a valid JSON file.");
                    }

                    progress.Tick("Validating Configuration");
                    config.Validate();
                }
                catch (Exception exception)
                {
                    result.Error = GenieExceptionMessageFormatter.FormatException(exception,
                        "En error occurred while trying to initialize generation process (probably a configuration error)");
                }

                if (!string.IsNullOrEmpty(result.Error) || config == null)
                {
                    result.Success = false;
                    return result;
                }

                try
                {
                    progress.Tick("Reading Database Schema");
                    var schemaReader = DatabaseSchemaReaderFactory.GetReader(config.DBMS);
                    var schema = schemaReader.Read(config);

                    progress.Tick("Generating File Contents");
                    var contentFiles = DalGenerator.Generate(schema, config, progress).ToList();

                    progress.Tick("Removing Leftovers");
                    ObstacleManager.Clear(config.ProjectPath, output, config, fileSystem);

                    progress.Tick("Writing Content to Files");
                    using (var writeProgress = progress.Child(contentFiles.Count, "Writing Content",
                        $"Done writing content to {contentFiles.Count}"))
                    {
                        DalWriter.Write(contentFiles, config.ProjectPath, writeProgress, fileSystem);
                        writeProgress.Tick();
                    }

                    progress.Tick("Processing project files");
                    if (!string.IsNullOrWhiteSpace(config.ProjectFile) && !config.Core)
                        CSharpProjectItemManager.Process(
                            fileSystem.CombinePaths(config.ProjectPath, config.ProjectFile),
                            contentFiles.Select(c => c.Path).ToList());

                    progress.Tick();
                }
                catch (Exception e)
                {
                    result.Error = GenieExceptionMessageFormatter.FormatException(e.InnerException, e.Message);
                    result.Success = false;
                    return result;
                }

                return result;
            }
        }
    }
}