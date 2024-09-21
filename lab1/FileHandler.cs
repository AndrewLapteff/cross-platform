using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class FileHandler
    {
        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath).Trim();
        }

        public void WriteFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        public bool IsValidMaxDominoPoint(string content)
        {
            return int.TryParse(content, out int number) && number > 0 && number < 1000;
        }
    }
}
