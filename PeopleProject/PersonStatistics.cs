namespace PeopleProject
{
    public class PersonStatistics
    {
        public List<Person> People { private get; set; }
        public PersonStatistics()
        {
            People = new List<Person>();
        }

        public double? getAverageAge()
        {
            var studentAges = People.Where(p => p.IsStudent).Select(p => p.Age).ToList();

            if (studentAges.Any(age => age < 1))
            {
                throw new ArgumentException("A felvett adatok nem megfelelőek: van 1 évnél fiatalabb diák");
            }

            return studentAges.Any() ? studentAges.Average() : null;
        }

        public int getNumberOfStudents()
        {
            return People.Count(p => p.IsStudent);
        }
        public Person getPersonWithHighestScore()
        {
            if (People == null)
            {
                throw new ArgumentNullException(nameof(People), "A People lista nem lehet null.");
            }

            var students = People.Where(p => p.IsStudent).ToList();
            if (!students.Any())
            {
                throw new ArgumentException("Nincsenek diákok a listában.");
            }

            return students.OrderByDescending(p => p.Score).First();
        }
        public double getAverageScoreOfStudents()
        {
            var students = People.Where(p => p.IsStudent).ToList();

            if (!students.Any())
            {
                throw new ArgumentException("Nincsenek diákok a listában");
            }

            return students.Average(p => p.Score);
        }
        public Person getOldestStudent()
        {
            var oldestStudent = People.Where(p => p.IsStudent).OrderByDescending(p => p.Age).FirstOrDefault();

            if (oldestStudent == null)
            {
                throw new ArgumentException("Nincsenek diákok a listában.");
            }

            return oldestStudent;
        }
        public bool isAnyoneFailing()
        {
            return People.Any(p => p.IsStudent && p.Score < 40);
        }
    }
}
