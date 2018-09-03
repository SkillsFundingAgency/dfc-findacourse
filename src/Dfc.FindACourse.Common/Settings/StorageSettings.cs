using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Settings
{
    public class StorageSettings
    {
        public string Storage_AccountName { get; set; }
        public string Storage_AccountKey { get; set; }
        public string Storage_ContainerReference { get; set; }
        public string Storage_SynonymsFilename { get; set; }
        public string Storage_QualSettingsFilename { get; set; }
    }
}
