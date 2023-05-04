using System.Text;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = ParseAllStudents("input.txt", Encoding.UTF8).ToList();

            var badStudents = GetAllBadStudents(students);

            PrintAll(badStudents);

            string path = @"data_new.json";

            File.Create(path).Dispose();

            PurgeEveryBadStudentOfScholarship(students);

            WriteAllLines("data_new.txt", students.Select(x => x.Serialize()));
        }

        static void PrintAll<T>(IEnumerable<T> values) where T : struct
        {
            foreach (var v in values)
            {
                Console.WriteLine(v);
            }
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

        static void WriteAllLines(string filePath, IEnumerable<string> contents)
        {
            using (StreamWriter fileStream = new StreamWriter(File.Open(filePath, FileMode.OpenOrCreate)))
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