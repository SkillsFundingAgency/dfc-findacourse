using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Settings
{
        public class App
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string ContainerReference { get; set; }
        public string SynonymsFilename { get; set; }
        public string QualSettingsFilename { get; set; }
   
        public string SynonymFileName { get; set; }
        public string QualSettingsFileName { get; set; }
        public string SynonymFilePath { get; set; }
        public string SettingsFilePath { get; set; }
        public string TempSynonymFilePath { get; set; }
        public string TempSettingsFilePath { get; set; }
  
        public string ContentNCHLink { get; set; }
        public string ContentQualLink { get; set; }    
        public string Page1Title { get; set; }
        public string Page1Text1 { get; set; }
        public string Page1Text2 { get; set; }
        public string Page1Text3 { get; set; }
        public string Page1Text4 { get; set; }
        public string Page1Text5 { get; set; }
        public string Page1Text6 { get; set; }
        public string Page1Text7 { get; set; }

        public bool Page3DisplayTravel { get; set; }
        public bool Page3DisplayOtherDates { get; set; }

        public string ApiKey { get; set; }
        public int PerPage { get; set; }
        public string APIAddress { get; set; }

    }
}
