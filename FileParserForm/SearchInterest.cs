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
        private List<Alias> aliases = new List<Alias>();

        public SearchInterest(string nameIn, string aliasIn)
        {
            name = nameIn;
            AddAlias(aliasIn);
        }
        public List<Alias> getAliases()
        {
            return aliases;
        }

        public string getName()
        {
            return name;
        }
        public List<String> ShowAliasJobs()
        {
            List<String> list = new List<string>();
            
            foreach (Alias alias in aliases)
            {
                list.Add(alias.GetName());
                foreach (String item in alias.GetJobs())
                {
                    list.Add("\t" + item);
                }
            }
            return list;
        }
        public void AddAlias(string input)
        {
            string[] alias = input.Split("(".ToArray());
            Alias check = aliases.Find(x => x.GetName().CompareTo(alias[0]) == 0);
            if (alias.Length > 1)
            {
                alias[1] = alias[1].TrimEnd(')');
                if (check==null)
                {
                    aliases.Add(new Alias(alias[0], alias[1]));
                }
                else
                {
                    check.AddJob(alias[1]);
                }

            }
            else
            {
                if (check==null)
                {
                    aliases.Add(new Alias(alias[0]));
                }
            }
        }
    }
}
