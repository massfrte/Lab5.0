using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task2
{
    [Serializable]
    struct Student
    {
        [Mark] public char MathematicsMark { get; private set; }
        [Mark] public char PhysicsMark { get; private set; }
        [Mark] public char InformaticsMark { get; private set; }

        [JsonIgnore] public bool DoesHaveScholarship => Scholarship > 0;
        [JsonIgnore] public bool IsBad => Grades.Any(x => char.GetNumericValue(x) < 3 || x == '-');

        public string Surname { get; private set; }
        public string FirstName { get; private set; }
        public string Patronymic { get; private set; }
        public string DateOfBirth { get; private set; }
        public char Sex { get; private set; }
        public int Scholarship { get; private set; }
        public char[] Grades
        {
            get
            {
                var marks = GetType().GetProperties()
                    .Where(x => x.GetCustomAttribute<MarkAttribute>() != null);

                var type = this;

                return marks.Select(p => (char)p.GetValue(type)!).ToArray();
            }
        }

        public Student(string dataLine)
        {
            var data = Parser.ExtractData(dataLine, @"[\S-]+");

            Surname = data[0];
            FirstName = data[1];
            Patronymic = data[2];
            Sex = char.Parse(data[3]);
            DateOfBirth = data[4];
            MathematicsMark = char.Parse(data[5]);
            PhysicsMark = char.Parse(data[6]);
            InformaticsMark = char.Parse(data[7]);
            Scholarship = int.Parse(data[8]);
        }

        public Student RemoveScholarship()
        {
            if (!DoesHaveScholarship)
            {
                Console.WriteLine($"The student \"{Surname} {FirstName} {Patronymic}\" already doesn't have a scholarship.");
                return this;
            }

            Student student = (Student)MemberwiseClone();
            student.Scholarship = 0;
            return student;
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }

        public override string ToString()
        {
            return $"Surname: {Surname}\n" +
                $"Math: {MathematicsMark}\n" +
                $"Physics: {PhysicsMark}\n" +
                $"IT: {InformaticsMark}\n" +
                $"Scholarship: {Scholarship}\n";
        }
    }
}
