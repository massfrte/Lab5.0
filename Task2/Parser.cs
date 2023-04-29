using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public static class Parser
    {
        public static IEnumerable<string> ReadLines(string filePath, Encoding encoding)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            List<string> lines = new List<string>();

            using (StreamReader streamReader = new StreamReader(File.Open(filePath, FileMode.Open), encoding))
            {
                while (streamReader.Peek() > -1)
                {
                    lines.Add(streamReader.ReadLine()!);
                }
            }

            return lines;
        }

        public static List<string> ExtractFields(string dataLine, string pattern)
        {
            var matches = Regex.Matches(dataLine, pattern);

            return matches.Select(match => match.Value).ToList();
        }
    }
}
