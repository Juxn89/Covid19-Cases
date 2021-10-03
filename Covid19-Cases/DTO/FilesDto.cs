using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Covid19_Cases.Emuns.Enums;

namespace Covid19_Cases.DTO
{
    public class FilesDto
    {
        public ExportFile typeFile { get; set; }
        public string ContentType { get; set; }
        public string extensionFile { get; set; }
    }
}