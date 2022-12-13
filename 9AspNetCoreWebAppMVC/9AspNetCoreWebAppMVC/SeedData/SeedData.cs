using _9AspNetCoreWebAppMVC.Data;
using _9AspNetCoreWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace _9AspNetCoreWebAppMVC.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new _9AspNetCoreWebAppMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<_9AspNetCoreWebAppMVCContext>>()))
            {
                // Look for any movies.
                if (context.Student.Any() || context.Course.Any() || context.Group.Any())
                {
                    return;   // DB has been seeded
                }

                context.Course.AddRange(
                    new Course
                    {
                        Name = "C# course",
                        Description = "Course for .Net Developers"
                    },

                    new Course
                    {
                        Name = "Java course",
                        Description = "Course for Java Developers"
                    },

                    new Course
                    {
                        Name = "Python course",
                        Description = "Course for Python Developers"
                    }

                    );

                context.Group.AddRange(
                    new Group
                    {
                        Name = "SR-01",
                        CourceId = 1
                    },

                    new Group
                    {
                        Name = "SR-02",
                        CourceId = 1
                    },

                    new Group
                    {
                        Name = "SR-03",
                        CourceId = 2
                    },

                    new Group
                    {
                        Name = "SR-04",
                        CourceId = 2
                    },

                    new Group
                    {
                        Name = "SR-05",
                        CourceId = 3
                    }
                );

                context.Student.AddRange(
                    new Student
                    {
                        First_Name = "Harry",
                        Last_Name = "Potter",
                        GroupId = 1
                    },

                    new Student
                    {
                        First_Name = "John",
                        Last_Name = "Walker",
                        GroupId = 1
                    },

                    new Student
                    {
                        First_Name = "Brad",
                        Last_Name = "Pitt",
                        GroupId = 1
                    },

                    new Student
                    {
                        First_Name = "Angelina",
                        Last_Name = "Jolie",
                        GroupId = 2
                    },

                    new Student
                    {
                        First_Name = "Peter",
                        Last_Name = "Parker",
                        GroupId = 2
                    },

                    new Student
                    {
                        First_Name = "Bradley",
                        Last_Name = "Cooper",
                        GroupId = 3
                    },

                    new Student
                    {
                        First_Name = "Peter",
                        Last_Name = "Ivanov",
                        GroupId = 3
                    },

                    new Student
                    {
                        First_Name = "Bill",
                        Last_Name = "Black",
                        GroupId = 4
                    },

                    new Student
                    {
                        First_Name = "Jana",
                        Last_Name = "Dark",
                        GroupId = 5
                    },

                    new Student
                    {
                        First_Name = "Ivan",
                        Last_Name = "Sevcenco",
                        GroupId = 5
                    },

                    new Student
                    {
                        First_Name = "Alex",
                        Last_Name = "Kadzoev",
                        GroupId = 5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
