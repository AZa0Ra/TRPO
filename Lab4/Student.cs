using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Student
    {
        private string _lastName;
        private string _group;
        private string _educationForm;
        private double _averageScore;
        public Student(string lastName, string group, string educationForm, double averageScore)
        {
            LastName = lastName;
            Group = group;
            EducationForm = educationForm;
            AverageScore = averageScore;
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Surname can't be empty");
                _lastName = value;
            }
        }

        public string Group
        {
            get => _group;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Group can't be empty");
                _group = value;
            }
        }
        public string EducationForm
        {
            get => _educationForm;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Education form can't be empty");
                _educationForm = value;
                UpdateEducationForm();
            }
        }

        public double AverageScore
        {
            get => _averageScore;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Average mark can be between 0-100.");
                _averageScore = value;
                UpdateEducationForm();
            }
        }
        private void UpdateEducationForm()
        {
            if (EducationForm == "Paid" && AverageScore > 98)
            {
                EducationForm = "At the expense of a named scholarship";
            }
        }

        public override string ToString()
        {
            return $"{LastName} - {EducationForm}, Group: {Group}, Avarage mark: {AverageScore:F1}";
        }
    }
}
