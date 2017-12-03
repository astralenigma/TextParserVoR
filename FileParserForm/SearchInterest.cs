using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserForm
{
    class SearchInterest
    {
        private string name;
        private List<string> alias;

        public SearchInterest(string nameIn, string aliasIn)
        {
            name = nameIn;
            alias = new List<string>();
            alias.Add(aliasIn);
        }
        public List<string> getAlias()
        {
            return alias;
        }

        public string getName()
        {
            return name;
        }

        public void AddAlias(string input)
        {
            alias.Add(input);
        }
    }
}
