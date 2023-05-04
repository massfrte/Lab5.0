using System.Text;
using System.Text.Encodings;
using System.Text.Json;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = ParseAllStudents("input.txt", Encoding.Default).ToList();

            var badStudents = GetAllBadStudents(students);

            string path = @"data_new.json";

            File.Create(path).Dispose();

            PurgeEveryBadStudentOfScholarship(students);

            WriteAllLines(path, students.Select(x => x.Serialize()).ToArray());
        }

        static void PurgeEveryBadStudentOfScholarship(List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].IsBad)
                {
                    students[i] = students[i].RemoveScholarship();
                }
            }
        }

        static void WriteAllLines(string filePath, string[] contents)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            using (StreamWriter fileStream = new StreamWriter(File.Open(filePath, FileMode.Open)))
            {
                foreach (string line in contents)
                {
                    fileStream.WriteLine(line);
                }
            }
        }

        static List<Student> GetAllBadStudents(List<Student> students)
        {
            return students.Where(x => x.IsBad)
                           .ToList();
        }

        static IEnumerable<Student> ParseAllStudents(string filePath, Encoding encoding)
        {
            var lines = Parser.ReadLines(filePath, encoding);

            foreach (var item in lines)
            {
                yield return new Student(item);
            }
        }
    }
}