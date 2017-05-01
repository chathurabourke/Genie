﻿namespace Genie.Models.Abstract
{
    /// <summary>
    /// Represents an attribute that does not need to track changes (must be a simple property)
    /// </summary>
    internal interface ISimpleAttribute
    {
        /// <summary>
        /// Data type of the attribute
        /// </summary>
        string DataType { get; set; }

        /// <summary>
        /// Name of the attribute
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Is the type is a literal type or and integral type
        /// </summary>
        bool IsLiteralType { get; set; }

        /// <summary>
        /// Name of the field
        /// </summary>
        string FieldName { get; set; }
    }
}
