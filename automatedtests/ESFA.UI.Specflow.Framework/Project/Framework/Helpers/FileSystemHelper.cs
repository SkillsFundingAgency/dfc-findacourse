using System;
using System.IO;

namespace ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers
{
    public class FileSystemHelper
    {
        //private static string reportNm = null;
        //private static string reportPath = null;

        public static void CreateFilePath(string filePath)
        {
            String reportsDirectory = AppDomain.CurrentDomain.BaseDirectory
                       + "../../"
                       + filePath
                       + DateTime.Now.ToString("dd-MM-yyyy")
                       + "\\";
            if (!Directory.Exists(reportsDirectory))
            {
                Directory.CreateDirectory(reportsDirectory);
            }
            string reportNm = (DateTime.Now.ToString("yyyyMMddHHmmss") + ".html");
            string reportPath = Path.Combine(reportsDirectory, reportNm);
            return;
        }
    }
}