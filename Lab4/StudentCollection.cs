using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class StudentCollection
    {
        private List<Student> _students;

        public StudentCollection()
        {
            _students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void DisplayStudents()
        {
            foreach (var student in _students)
            {
                Console.WriteLine(student);
            }
        }

        public void SortStudentsByAverageScore()
        {
            _students = _students.OrderByDescending(s => s.AverageScore).ToList();
        }

        public List<Student> FilterStudentsByGroup(string groupName)
        {
            return _students.Where(s => s.Group.Equals(groupName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var student in _students)
                {
                    writer.WriteLine($"{student.LastName};{student.Group};{student.EducationForm};{student.AverageScore}");
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File no exist!");

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 4 &&
                        double.TryParse(parts[3], out double avgScore))
                    {
                        var student = new Student(parts[0], parts[1], parts[2], avgScore);
                        _students.Add(student);
                    }
                }
            }
        }
    }
}
