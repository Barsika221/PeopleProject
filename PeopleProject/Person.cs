using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject
{
    public class Person
    {
        private int _score = 0;
        public const int MinScore = 0;
        public const int MaxScore = 100;
        public Person(int id, string name, int age, bool isStudent, int score) 
        { 
            Id = id;
            Name = name;
            Age = age;
            IsStudent = isStudent;
            Score = score;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsStudent { get; set; }
        public int Score
        {
            get { return _score; }
            set
            {
                if (value < MinScore || value > MaxScore)
                {
                    throw new ArgumentOutOfRangeException(nameof(Score), "Az értéknek 0 és 100 között kell lennie.");
                }
                _score = value;
            }
        }
    }
}
