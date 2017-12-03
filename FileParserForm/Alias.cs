using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserForm
{
    class Alias
    {
        private string name;
        private List<string> jobs = new List<string>();

        public Alias(string nameIn, string fate)
        {
            name = nameIn;
            jobs.Add(fate);
        }

        public Alias(string nameIn)
        {
            name = nameIn;
        }
        public string GetName()
        {
            return name;
        }

        public void AddJob(string newJob)
        {
            if (!jobs.Exists(x=> x.CompareTo(newJob)==0))
            {
                jobs.Add(newJob);
            }
        }
        public List<String> GetJobs()
        {
            return jobs;
        }
        public override string ToString()
        {
            string ouput = name;

            foreach (String job in jobs)
            {
                ouput += "\r \t" + job;
            }
            return ouput;
        }
    }
}
