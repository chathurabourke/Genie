﻿#region Usings

using Genie.Core.Models.Abstract;

#endregion

namespace Genie.Core.Models.Concrete
{
    internal class EnumValue : IEnumValue
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string FieldName { get; set; }
    }
}