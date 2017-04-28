using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using u_of_json_api.Models;

namespace u_of_json_api.Seeders
{
    public static class SchoolContextSeed
	{
		public static void SeedContext(this SchoolContext context)
		{
			context.Database.Migrate();

			if (!context.Courses.Any())
			{
				context.Courses.AddRange(GetSeedCourses());
			}

			if (!context.Grades.Any())
			{
				context.Grades.AddRange(GetSeedGrades());
			}

			if (!context.Students.Any())
			{
				context.Students.AddRange(GetSeedStudents());
			}

			context.SaveChanges();

			if (!context.Rosters.Any())
			{
				var rosters = new List<Roster>();

				foreach (var student in context.Students.ToList())
				{
					rosters.Add(new Roster() { studentId = student.ID });
					rosters.Add(new Roster() { studentId = student.ID });
				}

				var random = new Random();
				var courses = context.Courses.ToList();
				var grades = context.Grades.ToList();

				foreach (var item in rosters)
				{
					item.courseId = random.Next(1, courses.Count);
					item.gradeId = random.Next(1, grades.Count);
				}

				context.Rosters.AddRange(rosters);
			}

			context.SaveChanges();
		}

		static IEnumerable<Course> GetSeedCourses()
		{
			return new List<Course>()
			{
				new Course()
				{
					code = "ECON100"
				},
				new Course()
				{
                    code = "HIST100"
				},
				new Course()
				{
                    code = "MATH101"
				},
				new Course()
				{
                    code = "MATH102"
				},
				new Course()
				{
                    code = "MATH103"
				}
			};
		}

		static IEnumerable<Grade> GetSeedGrades()
		{
			return new List<Grade>()
			{
				new Grade()
				{
					grade = "F"
				},
				new Grade()
				{
                    grade = "D"
				},
				new Grade()
				{
                    grade = "I"
				},
				new Grade()
				{
                    grade = "B"
				},
				new Grade()
				{
                    grade = "A"
				},
				new Grade()
				{
                    grade = "C"
				}
			};
		}

		static IEnumerable<Student> GetSeedStudents()
		{
			return new List<Student>()
			{
				new Student()
				{
					first = "Herbert",
					last = "Becker",
					age = 35,
					address = "271 Evacat Terrace",
					city = "Lodofaj",
					state = "VA",
					zip = "45204",
					email = "cif@uvecozma.bz",
					gradYear = 2020
				},
				new Student()
				{
					first = "Lizzie",
					last = "James",
					age = 48,
					address = "1934 Evasi Road",
					city = "Bavcabe",
					state = "KS",
					zip = "28251",
					email = "sivihele@teche.in",
					gradYear = 2020
				},
				new Student()
				{
					first = "Jeremy",
					last = "Barnett",
					age = 45,
					address = "711 Cipe Street",
					city = "Ruktureh",
					state = "MN",
					zip = "19654",
					email = "imi@uwvinec.ls",
					gradYear = 2019
				},
				new Student()
				{
					first = "Maggie",
					last = "Hayes",
					age = 46,
					address = "1241 Elfu Road",
					city = "Heugouja",
					state = "OR",
					zip = "94230",
					email = "mup@miza.th",
					gradYear = 2019
				},
				new Student()
				{
					first = "Georgie",
					last = "Barnett",
					age = 26,
					address = "1448 Jeleva Circle",
					city = "Zekalduc",
					state = "LA",
					zip = "74210",
					email = "dilo@lekpuze.se",
					gradYear = 2020
				},
				new Student()
				{
					first = "Ora",
					last = "Riley",
					age = 64,
					address = "301 Lihe Heights",
					city = "Anmacko",
					state = "MO",
					zip = "25912",
					email = "orucar@kefzegote.ck",
					gradYear = 2019
				},
				new Student()
				{
					first = "Sarah",
					last = "Rivera",
					age = 21,
					address = "619 Popep Highway",
					city = "Wedofkun",
					state = "TN",
					zip = "15564",
					email = "fodahsu@joleggi.mz",
					gradYear = 2019
				},
				new Student()
				{
					first = "Victor",
					last = "Parks",
					age = 53,
					address = "1317 Uchac Ridge",
					city = "Adgenhev",
					state = "IA",
					zip = "75517",
					email = "hol@ul.aw",
					gradYear = 2017
				},
				new Student()
				{
					first = "Wayne",
					last = "Hansen",
					age = 57,
					address = "1413 Bigri Place",
					city = "Gihteig",
					state = "AZ",
					zip = "74658",
					email = "laj@unu.zw",
					gradYear = 2020
				},
				new Student()
				{
					first = "Jason",
					last = "Peterson",
					age = 35,
					address = "1728 Padiv Lane",
					city = "Zakajug",
					state = "MI",
					zip = "46286",
					email = "nuhhemi@ja.co.uk",
					gradYear = 2017
				}
			};
		}

	}
}
