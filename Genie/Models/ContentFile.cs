﻿
using Genie.Models.Abstract;

namespace Genie.Models
{
    internal class ContentFile: IContentFile
    {
        public string Content { get; set; }
        public string Path { get; set; }
    }
}
