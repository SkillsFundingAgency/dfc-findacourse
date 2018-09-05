using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Settings
{
    public class StorageSettings
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string ContainerReference { get; set; }
        public string SynonymsFilename { get; set; }
        public string QualSettingsFilename { get; set; }
    }
    public class ConfigSettings
    {
        public string SynonymFileName { get; set; }
        public string QualSettingsFileName { get; set; }
        public string SynonymFilePath { get; set; }
        public string SettingsFilePath { get; set; }
        public string TempSynonymFilePath { get; set; }
        public string TempSettingsFilePath { get; set; }
    }
    public class AppSettings
    {
        public string App__ContentNCHLink { get; set; }
        public string App__ContentQualLink { get; set; }    
        public string App__Page1Title { get; set; }
        public string App__Page1Text1 { get; set; }
        public string App__Page1Text2 { get; set; }
        public string App__Page1Text3 { get; set; }
        public string App__Page1Text4 { get; set; }
        public string App__Page1Text5 { get; set; }
        public string App__Page1Text6 { get; set; }
        public string App__Page1Text7 { get; set; }


    }
}
