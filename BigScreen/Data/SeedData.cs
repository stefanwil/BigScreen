using BigScreen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Data
{
    public class SeedData
    {

        internal class TifoUser
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string UserName { get; set; }
        }


        public static async Task Initialize(IServiceProvider serviceProvider, string adminPw)
        {
            using (var context = new BigScreenContext(
             serviceProvider.GetRequiredService<DbContextOptions<BigScreenContext>>()))
            {
                //if (!context.ReadyState.Any())
                //{
                //    var readyStates = new List<ReadyState>();
                //    var readyStaeNames = new[] { "Inte Påbörjad", "Påbörjad", "Klar", "Godkänd" };


                //    foreach (var name in readyStaeNames)
                //    {




                //        var readyState = new ReadyState
                //        {
                //            Type = name,

                //        };
                //        readyStates.Add(readyState);
                //    }

                //    context.ReadyState.AddRange(readyStates);
                //    context.SaveChanges();
                //}
                var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //if (context.Course.Any())
                //{

                //    context.Course.RemoveRange(context.Course);
                //    context.Module.RemoveRange(context.Module);
                //    context.LmsActivity.RemoveRange(context.LmsActivity);


                //}
                ////if (context.Users.Any())
                ////{
                ////    context.Users.RemoveRange(context.Users);


                ////}
                //context.SaveChanges();
                //// Let's seed!
                //var courses = new List<Course>();
                //var courseNames = new[] { "Java Grundkurs", "Java Avanserad", "Unix från grunden", "DotNet för alla", "DotNet för webben" };


                //foreach (var name in courseNames)
                //{




                //    var course = new Course
                //    {
                //        Name = name,
                //        StartDate = DateTime.Today,
                //        EndDate = DateTime.Today.AddDays(90),
                //        Description = Faker.Lorem.Sentence(3),
                //    };
                //    courses.Add(course);
                //}

                //context.Course.AddRange(courses);
                //context.SaveChanges();

                //var modules = new List<Module>();



                //for (int i = 1; i < 20; i++)
                //{





                //    var random = Faker.RandomNumber.Next(4);
                //    var module = new Module
                //    {
                //        Name = $"module{i}",
                //        StartDate = DateTime.Today,
                //        EndDate = DateTime.Today.AddDays(10),
                //        Description = Faker.Lorem.Sentence(3),

                //        CourseId = courses[random].Id
                //    };
                //    modules.Add(module);
                //}
                //context.Module.AddRange(modules);
                //context.SaveChanges();

                //var activityTypes = new List<ActivityType>();
                //var activityTypeNames = new[] { "E-learningpass", "Föreläsning", "Övningsuppgift" };


                //foreach (var name in activityTypeNames)
                //{




                //    var activityType = new ActivityType
                //    {
                //        Type = name,

                //    };
                //    activityTypes.Add(activityType);
                //}

                //context.ActivityType.AddRange(activityTypes);
                //context.SaveChanges();







                //var activities = new List<LmsActivity>();



                //for (int i = 1; i < 50; i++)
                //{





                //    var random = Faker.RandomNumber.Next(14);
                //    var random1 = Faker.RandomNumber.Next(3);
                //    var activity = new LmsActivity
                //    {
                //        Name = $"activity{i}",
                //        StartDate = DateTime.Today,
                //        EndDate = DateTime.Today.AddDays(4),
                //        Description = Faker.Lorem.Sentence(3),

                //        ModuleId = modules[random].Id,
                //        ActivityTypeId = activityTypes[random1].Id

                //    };
                //    activities.Add(activity);
                //}
                //context.LmsActivity.AddRange(activities);
                //context.SaveChanges();











                if (roleManager == null || userManager == null)
                {
                    throw new Exception("roleManager or userManager is null");
                }

                var roleNames = new[] { "TifoAdmin", "ArenaAdmin","UserAdmin","Visitor" };

                foreach (var name in roleNames)
                {
                    if (await roleManager.RoleExistsAsync(name)) continue;
                    var role = new IdentityRole { Name = name };
                    var result = await roleManager.CreateAsync(role);
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }
                //if (!context.Users.Any())
                //{
                var tifoadmins = new List<TifoUser>();

                for (int i = 1; i < 3; i++)
                {
                    var fakename = $"TifoAdmins{i}";
                    TifoUser newTifoAdmin = new TifoUser { UserName = $"{fakename}@gmail.com", Email = $"{fakename}@gmail", Name = $"{fakename} Olsson"/*, PhoneNumber = Faker.Phone.Number()*/ };


                    tifoadmins.Add(newTifoAdmin);
                }


                foreach (var tifoadmin in tifoadmins)
                {
                    var foundUser = await userManager.FindByEmailAsync(tifoadmin.Email);
                    if (foundUser != null) continue;
                    var user = new ApplicationUser { UserName = tifoadmin.UserName, Email = tifoadmin.Email, Name = tifoadmin.Name };
                    var addUserResult = await userManager.CreateAsync(user, adminPw);
                    if (!addUserResult.Succeeded)
                    {
                        throw new Exception(string.Join("\n", addUserResult.Errors));
                    }
                    var addToRoleResultAdmin = await userManager.AddToRoleAsync(user, "TifoAdmin");
                    if (!addToRoleResultAdmin.Succeeded)
                    {
                        throw new Exception(string.Join("\n", addToRoleResultAdmin.Errors));
                    }


                }
                var visitors = new List<TifoUser>();

                for (int i = 0; i < 5; i++)
                {
                    var fakename = $"Visitor{i}";
                    TifoUser newVisitor = new TifoUser { UserName = $"{fakename}@gmail.com", Email = $"{fakename}@gmail.com", Name = $"{fakename} Stensson"/*, PhoneNumber = Faker.Phone.Number()*/ };


                    visitors.Add(newVisitor);
                }



                foreach (var visitor in visitors)
                {
                    var foundUser = await userManager.FindByEmailAsync(visitor.Email);
                    if (foundUser != null) continue;

                    var user = new ApplicationUser { UserName = visitor.Email, Email = visitor.Email, Name = visitor.Name/*,PhoneNumber=student.PhoneNumber*/ }; // , CourseId = courses[randomcourse].Id, Course = courses[randomcourse]};

                    var addUserResult = await userManager.CreateAsync(user, adminPw);
                    if (!addUserResult.Succeeded)
                    {
                        throw new Exception(string.Join("\n", addUserResult.Errors));
                    }


                    var addToRoleResultAdmin = await userManager.AddToRoleAsync(user, "Visitor");
                    if (!addToRoleResultAdmin.Succeeded)
                    {
                        throw new Exception(string.Join("\n", addToRoleResultAdmin.Errors));
                    }

                    //var randomcourse = Faker.RandomNumber.Next(4);
                    //user.CourseId = courses[randomcourse].Id;
                    //var identityResult = await userManager.UpdateAsync(user);
                    //if (!identityResult.Succeeded)
                    //{
                    //    throw new Exception(string.Join("\n", identityResult.Errors));
                    //}
                }
            }

        }
    }
}

