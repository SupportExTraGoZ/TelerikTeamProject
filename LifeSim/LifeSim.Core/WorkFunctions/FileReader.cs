using LifeSim.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LifeSim.Core.WorkFunctions
{
    public class FileReader : IReadable
    {
        public IList<string> ReadFile(string path)
        {
            var strLines = new List<string>();

            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    strLines.Add(line);

                    line = reader.ReadLine();
                }
            }

            return strLines;
        }
    }
}