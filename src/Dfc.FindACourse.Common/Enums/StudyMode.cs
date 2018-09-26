using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum StudyMode
    {
        NotKnown = 0,

        [Display(Name = "Full-time")]
        FullTime = 1,

        [Display(Name = "Part-time")]
        PartTime = 2,

        PartTimeOfAFullTimeProgram = 3,

        [Display(Name = "Flexible")]
        Flexible = 4,
    }
    public class StudyModeExt
    {
        public int Key;
        public string Value;
    }
    public class StudyModes
    {
        public StudyModes()
        {
            StudyModesList = new List<StudyModeExt>
            {
                new StudyModeExt() { Key = 0, Value = "SM0" },
                new StudyModeExt() { Key = 1, Value = "SM1" },
                new StudyModeExt() { Key = 2, Value = "SM2" },
                new StudyModeExt() { Key = 3, Value = "SM3" },
                new StudyModeExt() { Key = 4, Value = "SM4" },
                new StudyModeExt() { Key = 5, Value = "SM5" }
            };
        }
        public List<StudyModeExt> StudyModesList { get; }
    }
}