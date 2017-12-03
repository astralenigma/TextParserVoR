using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserForm
{
    class SearchParser
    {
        private static List<SearchInterest> listSI = new List<SearchInterest>();
        private static string namefile;
        public static void readFile(string filename)
        {

            string[] lines = System.IO.File.ReadAllLines( @filename);

            foreach (string line in lines)
            {
                if (line.Length<1)
                {
                    continue;
                }
                if (line[0]== '•')
                {
                    string[] separator = { " : " };
                    string[] inputSI = line.Substring(2).Split(separator,StringSplitOptions.None);
                    inputSI[1] = inputSI[1].Trim();
                    SearchInterest interest = listSI.Find(x => x.getName() == inputSI[1]);
                    if (interest!=null)
                    {
                        interest.AddAlias(inputSI[0]);
                    }
                    else
                    {
                        listSI.Add(new SearchInterest(inputSI[1], inputSI[0]));
                    }
                }
            }

        }

        public static SearchInterest startSearch(string filename, string searchName)
        {
            if (filename!=namefile)
            {
                listSI.Clear();
                readFile(filename);
                namefile = filename;
            }
            return getResults(searchName);
        }

        public static SearchInterest getResults(string searchName)
        {
            SearchInterest si = listSI.Find(x => x.getName().ToUpper().CompareTo(searchName.ToUpper()) == 0);
            return si;
        }
        public static void printResults(SearchInterest sI)
        {
            string filename = sI.getName() + "_Alias.txt";
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@filename))
            {
                foreach (string alias in sI.ShowAliasJobs())
                {
                    file.WriteLine(alias);
                }
            }
        
    }
    }
}
