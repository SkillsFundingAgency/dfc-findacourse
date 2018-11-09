using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.Helpers
{
    public class MessageHelper
    {
        public string CountOccurrencesInString (string queryResult, string searchTerm)
        {
            //Convert the string into an array of words  
            string[] source = queryResult.ToLower().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var matchQuery = from word in source
                             where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
                             select word;

            string wordCount = matchQuery.Count().ToString();

            Console.WriteLine("{0} occurrences(s) of the search term \"{1}\" were found.", wordCount, searchTerm);
            return wordCount;
        }


    }
}
