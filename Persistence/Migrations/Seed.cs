using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Bob", UserName = "bob", Email = "bob@test.com"},
                    new AppUser{DisplayName = "Tom", UserName = "tom", Email = "tom@test.com"},
                    new AppUser{DisplayName = "Jane", UserName = "jane", Email = "jane@test.com"}
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            } 

            if (context.Activities.Any()) return;
            
            var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "Quarterly Devotional",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Guest Speaker: Jason Evans",
                    Category = "Youth",
                    Sponsor = "",
                    POC = "Freddie Flintstone",
					City = "Knoxville",
					Venue = "West Side Church of Christ"
                },
                new Activity
                {
                    Title = "Teenage Camp",
                    Date = DateTime.Now.AddMonths(+3),
                    Description = "Fee is $50 per camper",
                    Category = "Youth",
                    Sponsor = "",
                    POC = "Isaac Clanton",
					City = "Knoxville",
					Venue = "Karns Church of Christ"
                },
                new Activity
                {
                    Title = "Area-Wide Ladies Meeting",
                    Date = DateTime.Now.AddMonths(+1),
                    Description = "Guest Speaker: Elwanda McKane",
                    Category = "Adult Gatherings",
                    Sponsor = "Lenoir City Church of Christ",
                    POC = "Ethyl McClintoc",
					City = "Knoxville",
					Venue = "Hyatt Regency"
                },
                new Activity
                {
                    Title = "Area-Wide Singing",
                    Date = DateTime.Now.AddMonths(+1),
                    Description = "An annual event",
                    Category = "Singing",
                    Sponsor = "Lenoir City church of Christ",
                    POC = "Freddie Flintstone",
					City = "Lenoir City",
					Venue = "Lenoir City Venue"
                },
                new Activity
                {
                    Title = "Gospel Meeting",
                    Date = DateTime.Now.AddMonths(+2),
                    Description = "Sunday - Wednesday - 7:00 each evening Guest Speaker: Todd Wilson",
                    Category = "Gospel Meetings",
                    Sponsor = "",
                    POC = "Bill Winson",
					City = "Friendsville",
					Venue = "Friendsville Community Center"
                },
                new Activity
                {
                    Title = "Quarterly Devotional",
                    Date = DateTime.Now.AddMonths(+1),
                    Description = "Guest Speaker: Donald Trump",
                    Category = "Youth",
                    Sponsor = "East Side Church of Christ",
                    POC = "Issiah Fredricksen",
					City = "Maryville",
					Venue = "Maryville Park"
                },
                new Activity
                {
                    Title = "Pre-Teenage Camp",
                    Date = DateTime.Now.AddMonths(+2),
                    Description = "Fee is $50 per camper",
                    Category = "Youth",
                    Sponsor = "",
                    POC = "Isaac Clanton",
					City = "Knoxville",
					Venue = "Karns Church of Christ"
                },
                new Activity
                {
                    Title = "Gospel Meeting",
                    Date = DateTime.Now.AddMonths(+1),
                    Description = "Sunday - Wednesday - 7:00 each evening Guest Speaker: George Jones",
                    Category = "Gospel Meetings",
                    Sponsor = "",
                    POC = "Charlie Farrar",
					City = "Lenoir City",
					Venue = "Lenoir City Church of Christ"
                },
                new Activity
                {
                    Title = "Church Security Seminar",
                    Date = DateTime.Now.AddMonths(+4),
                    Description = "Guest Speaker: Matt Dillon and Bat Masterson",
                    Category = "Information",
                    Sponsor = "Maryville Baptist Church",
                    POC = "Don Pleasant",
					City = "Maryville",
					Venue = "Maryville Convention Center"
                },
                new Activity
                {
                    Title = "Quarterly IT Geek Meeting",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Discussion of late-breaking security challenges",
                    Category = "Info",
                    Sponsor = "Loudon County Sheriff Dept.",
                    POC = "Fred Jones",
					City = "Greenback",
					Venue = "Greenback Community Center"
                }
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}