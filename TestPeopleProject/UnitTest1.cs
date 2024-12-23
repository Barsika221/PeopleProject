using PeopleProject;

namespace TestPeopleProject
{
    public class Tests
    {
        PersonStatistics personStatistics;
        [SetUp]
        public void Setup()
        {
        }
        /*
             public class PersonStatistics
    {

        public List<Person> People { private get; set; }
        public PersonStatistics()
        {
            People = new List<Person>();
        }

        public double getAverageAge()
        {
            return People.Where(p => p.IsStudent).Select(p => (double?)p.Age).DefaultIfEmpty().Average();
        }
        public int getNumberOfStudents()
        {
            return People.Count(p => p.IsStudent);
        }
        public Person getPersonWithHighestScore()
        {
            return People.Where(p => p.IsStudent).OrderByDescending(p => p.Score).First();
        }
        public double getAverageScoreOfStudents()
        {
            return People.Where(p => p.IsStudent).Average(p => p.Score);
        }
        public Person getOldestStudent()
        {
            return People.Where(p => p.IsStudent).OrderByDescending(p => p.Age).First();
        }
        public bool isAnyoneFailing()
        {
            return People.Any(p => p.IsStudent && p.Score < 40);
        }
         */

        [Test]
        public void Atlageletkor_ValosAdatokkal_ErtekeDouble()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 80),
                new Person(2, "Jane Doe", 22, true, 90),
                new Person(3, "Jack Doe", 25, true, 70),
                new Person(4, "Jill Doe", 30, true, 60)
            };
            Assert.That(personStatistics.getAverageAge(), Is.EqualTo(24.25));
        }
        [Test]
        public void Atlageletkor_NullAdat_ErtekNull()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>();
            Assert.That(personStatistics.getAverageAge(), Is.Null);
        }
        [Test]
        public void Atlageletkor_CsakStudentNez_Ertek15()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 10, true, 80),
                new Person(2, "Jane Doe", 20, true, 90),
                new Person(3, "Jack Doe", 25, false, 70),
                new Person(4, "Jill Doe", 30, false, 60),
                new Person(5, "Jill Doe", 30, false, 60)
            };
            Assert.That(personStatistics.getAverageAge(), Is.EqualTo(15));
        }
        [Test]
        public void Atlageletkor_NincsStudent_NullDob()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 10, false, 80),
                new Person(2, "Jane Doe", 20, false, 90),
                new Person(3, "Jack Doe", 25, false, 70),
                new Person(4, "Jill Doe", 30, false, 60),
                new Person(5, "Jill Doe", 30, false, 60)
            };
            Assert.That(personStatistics.getAverageAge(), Is.Null);
        }
        [Test]
        public void NegativAtlageletkor_ArgumentExceptiontDob()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", -10, true, 80),
                new Person(2, "Jane Doe", -20, true, 90),
                new Person(3, "Jack Doe", -25, true, 70),
                new Person(4, "Jill Doe", -30, true, 60),
                new Person(5, "Jill Doe", -30, true, 60)
            };
            Assert.That(() => personStatistics.getAverageAge(), Throws.ArgumentException);
        }
        public void PozivivAtlageletkor_NegatívErtekkel_ArgumentExceptiontDob2()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", -10, true, 80),
                new Person(2, "Jane Doe", 20, true, 90),
                new Person(3, "Jack Doe", 25, true, 70),
                new Person(4, "Jill Doe", 30, true, 60),
                new Person(5, "Jill Doe", 30, true, 60)
            };
            Assert.That(() => personStatistics.getAverageAge(), Throws.ArgumentException);
        }
        [Test]
        public void Hallgatok_Valosadatokkal_Ertek4()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 80),
                new Person(2, "Jane Doe", 22, true, 90),
                new Person(3, "Jack Doe", 25, true, 70),
                new Person(4, "Jill Doe", 30, true, 60)
            };
            Assert.That(personStatistics.getNumberOfStudents(), Is.EqualTo(4));
        }
        [Test]
        public void Hallgatok_NincsHallgato_Ertek0()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, false, 80),
                new Person(2, "Jane Doe", 22, false, 90),
                new Person(3, "Jack Doe", 25, false, 70),
                new Person(4, "Jill Doe", 30, false, 60)
            };
            Assert.That(personStatistics.getNumberOfStudents(), Is.EqualTo(0));
        }
        [Test]
        public void Hallgatok_NincsHallgato_Ertek0_2()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>();
            Assert.That(personStatistics.getNumberOfStudents(), Is.EqualTo(0));
        }
        [Test]
        public void LegjobbPontszam_ValosAdatokkal_Ertek90()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 80),
                new Person(2, "Jane Doe", 22, true, 90),
                new Person(3, "Jack Doe", 25, true, 70),
                new Person(4, "Jill Doe", 30, true, 60)
            };
            Assert.That(personStatistics.getPersonWithHighestScore().Score, Is.EqualTo(90));
        }
        [Test]
        public void LegjobbPontszam_NullLista_ArgumentNullExceptionDob()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = null;
            Assert.That(() => personStatistics.getPersonWithHighestScore(), Throws.ArgumentNullException);
        }

        [Test]
        public void LegjobbPontszam_NincsHallgato_ArgumentExceptionDob()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, false, 80),
                new Person(2, "Jane Doe", 22, false, 90),
                new Person(3, "Jack Doe", 25, false, 70),
                new Person(4, "Jill Doe", 30, false, 60)
            };
            Assert.That(() => personStatistics.getPersonWithHighestScore(), Throws.ArgumentException);
        }

        [Test]
        public void LegjobbPontszam_KetUgyanolyanPontszam_Ertek80()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 80),
                new Person(2, "Jane Doe", 22, true, 80),
                new Person(3, "Jack Doe", 25, true, 70),
                new Person(4, "Jill Doe", 30, true, 60)
            };
            Assert.That(personStatistics.getPersonWithHighestScore().Score, Is.EqualTo(80));
        }
        [Test]
        public void AtlagPontszam_ValosAdatokkal_Ertek75()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 80),
                new Person(2, "Jane Doe", 22, true, 90),
                new Person(3, "Jack Doe", 25, true, 70),
                new Person(4, "Jill Doe", 30, true, 60)
            };
            Assert.That(personStatistics.getAverageScoreOfStudents(), Is.EqualTo(75));
        }
        [Test]
        public void AtlagPontszam_NincsHallgato_ArgumentExceptionDob()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, false, 80),
                new Person(2, "Jane Doe", 22, false, 90),
                new Person(3, "Jack Doe", 25, false, 70),
                new Person(4, "Jill Doe", 30, false, 60)
            };
            Assert.That(() => personStatistics.getAverageScoreOfStudents(), Throws.ArgumentException);
        }
        [Test]
        public void AtlagPontszam_NemCsakHAllgato_ValosErtek()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 80),
                new Person(2, "Jane Doe", 22, true, 90),
                new Person(3, "Jack Doe", 25, true, 70),
                new Person(4, "Jill Doe", 30, true, 60),
                new Person(5, "Jill Doe", 30, false, 60)
            };
            Assert.That(personStatistics.getAverageScoreOfStudents(), Is.EqualTo(75));
        }
        [Test]
        public void AtlagPontszam_NincsHallgato_ArgumentExceptionDob2()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>();
            Assert.That(() => personStatistics.getAverageScoreOfStudents(), Throws.ArgumentException);
        }
        [Test]
        public void AtlagPontszam_DoubleErtekkel()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 63),
                new Person(2, "Jane Doe", 22, true, 72),
                new Person(3, "Jack Doe", 25, true, 68),
                new Person(4, "Jill Doe", 30, true, 75)
            };
            Assert.That(personStatistics.getAverageScoreOfStudents(), Is.EqualTo(69.5));
        }
        [Test]
        public void LegidosebbHallgato_ValosAdatokkal_Ertek30()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 63),
                new Person(2, "Jane Doe", 22, true, 72),
                new Person(3, "Jack Doe", 25, true, 68),
                new Person(4, "Jill Doe", 30, true, 75)
            };
            Assert.That(personStatistics.getOldestStudent().Age, Is.EqualTo(30));
        }
        [Test]
        public void LegidosebbHallgato_NincsHallgato_ArgumentExceptionDob()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, false, 63),
                new Person(2, "Jane Doe", 22, false, 72),
                new Person(3, "Jack Doe", 25, false, 68),
                new Person(4, "Jill Doe", 30, false, 75)
            };
            Assert.That(() => personStatistics.getOldestStudent(), Throws.ArgumentException);
        }
        [Test]
        public void LegidosebbHallgato_NemCsakTanuloVan()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 63),
                new Person(2, "Jane Doe", 22, false, 72),
                new Person(3, "Jack Doe", 25, true, 68),
                new Person(4, "Jill Doe", 30, false, 75)
            };
            Assert.That(personStatistics.getOldestStudent().Age, Is.EqualTo(25));
        }
        [Test]
        public void LegidosebbHallgato_KetUgyanidosebb_Ertek30()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 63),
                new Person(2, "Jane Doe", 22, true, 72),
                new Person(3, "Jack Doe", 30, true, 68),
                new Person(4, "Jill Doe", 30, true, 75)
            };
            Assert.That(personStatistics.getOldestStudent().Age, Is.EqualTo(30));
        }
        [Test]
        public void LegidosebbHallgato_NincsHallgato_ArgumentExceptionDob2()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>();
            Assert.That(() => personStatistics.getOldestStudent(), Throws.ArgumentException);
        }
        [Test]
        public void BukottEValaki_ErtekTrue()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 63),
                new Person(2, "Jane Doe", 22, true, 72),
                new Person(3, "Jack Doe", 25, true, 68),
                new Person(4, "Jill Doe", 30, true, 75),
                new Person(5, "Jill Doe", 30, true, 35)
            };
            Assert.That(personStatistics.isAnyoneFailing(), Is.True);
        }
        [Test]
        public void BukottEValaki_ErtekFalse()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 63),
                new Person(2, "Jane Doe", 22, true, 72),
                new Person(3, "Jack Doe", 25, true, 68),
                new Person(4, "Jill Doe", 30, true, 75)
            };
            Assert.That(personStatistics.isAnyoneFailing(), Is.False);
        }
        [Test]
        public void BukottEValaki_NincsHallgato_ErtekFalse()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, false, 63),
                new Person(2, "Jane Doe", 22, false, 72),
                new Person(3, "Jack Doe", 25, false, 68),
                new Person(4, "Jill Doe", 30, false, 75)
            };
            Assert.That(personStatistics.isAnyoneFailing(), Is.False);
        }
        [Test]
        public void BukottEValaki_NincsHallgato_ErtekFalse2()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>();
            Assert.That(personStatistics.isAnyoneFailing(), Is.False);
        }
        [Test]
        public void BukottEValaki_Alsoponthatar()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 39),
                new Person(2, "Jane Doe", 22, true, 72),
                new Person(3, "Jack Doe", 25, true, 68),
                new Person(4, "Jill Doe", 30, true, 75)
            };
            Assert.That(personStatistics.isAnyoneFailing(), Is.True);
        }
        [Test]
        public void BukottEValaki_FelsõpontHatar()
        {
            personStatistics = new PersonStatistics();
            personStatistics.People = new List<Person>
            {
                new Person(1, "John Doe", 20, true, 40),
                new Person(2, "Jane Doe", 22, true, 72),
                new Person(3, "Jack Doe", 25, true, 68),
                new Person(4, "Jill Doe", 30, true, 75)
            };
            Assert.That(personStatistics.isAnyoneFailing(), Is.False);
        }
        [Test]
        public void PontszamNemMegfelelo_ArgumentOutOfRangeExceptionDob()
        {
            Assert.That(() => new Person(1, "John Doe", 20, true, 101), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void PontszamNemMegfelelo_ArgumentOutOfRangeExceptionDob2()
        {
            Assert.That(() => new Person(1, "John Doe", 20, true, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}