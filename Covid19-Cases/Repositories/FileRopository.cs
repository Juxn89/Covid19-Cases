using Covid19_Cases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Covid19_Cases.Emuns.Enums;

namespace Covid19_Cases.Repositories
{
    public class FileRopository
    {
        private List<FilesDto> lstFilesInfo = new List<FilesDto>() {
            new FilesDto() { typeFile = ExportFile.JSON, ContentType = "application/json", extensionFile = ".json"},
            new FilesDto() { typeFile = ExportFile.XML, ContentType = "application/xml", extensionFile = ".xml"},
            new FilesDto() { typeFile = ExportFile.CSV, ContentType = "text/csv", extensionFile = ".csv"}
        };

        public FilesDto GetInfoFileExport(int type) {
            return lstFilesInfo.Where(a => (int)a.typeFile == type).FirstOrDefault();
        }
    }
}