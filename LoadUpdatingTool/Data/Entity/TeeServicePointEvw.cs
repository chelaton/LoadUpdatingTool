using System;
using System.Collections.Generic;

namespace LoadUpdatingTool.Data.Entity
{
    public partial class TeeServicePointEvw
    {
        public int Id { get; set; }
        public string? Identification { get; set; }
        public int? Gid { get; set; }
        public string? ConversionInfo { get; set; }
    }
}
