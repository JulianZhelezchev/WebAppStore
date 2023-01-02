using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Data.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public string WwwRootPath { get; set; }
        public string DatabaseValue { get; set; }
    }
}
