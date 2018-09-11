using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Dfc.FindACourse.Common.UnitTests")]

namespace Dfc.FindACourse.Common.Models
{
    public class Provider : IProvider
    {
        public int Id  { get; }
        public string Name  { get; }
        public string ProviderName  { get; set; }
        public string UKPRN { get; set; }
        public string UPIN { get; set; }
        public bool TFPlusLoans { get; set; }
        public bool TFPlusLoansSpecified  { get; set; }
        public bool DFE1619Funded  { get; set; }
        public bool DFE1619FundedSpecified  { get; set; }
        public double FEChoices_LearnerDestination  { get; set; }
        public bool FEChoices_LearnerDestinationSpecified  { get; set; }
        public double FEChoices_LearnerSatisfaction  { get; set; }
        public bool FEChoices_LearnerSatisfactionSpecified  { get; set; }
        public double FEChoices_EmployerSatisfaction  { get; set; }
        public bool FEChoices_EmployerSatisfactionSpecified  { get; set; }
        public string Website  { get; set; }
        public string Email  { get; set; }
        public string Phone  { get; set; }
        public string Fax  { get; set; }

        public Provider(int id, string name)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} cannot be null, empty or only whitespace.");

            Id = id;
            Name = NameFormatting(name);
        }

        internal static string NameFormatting(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            var split = name.Split(" ");

            if (split.Length == 1)
                return name;

            return name.ToSentenceCase();
        }
    }
}