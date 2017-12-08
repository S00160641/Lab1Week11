namespace Lab1Week11.Migrations.ClubMigrations
{
    using Models.ClubModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lab1Week11.Models.ClubModel.ClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ClubMigrations";
        }

        protected override void Seed(Lab1Week11.Models.ClubModel.ClubContext context)
        {
            SeedClubs(context);
        }

        private void SeedClubs(ClubContext context)
        {
            #region Club1 
            context.Clubs.AddOrUpdate(c => c.ClubName,
            new Club
            {
                ClubName = "The Tiddly Winks Club",
                CreationDate = DateTime.Now,
                adminID = -1,
                // It seem you cannot reliably assign the result of a method to a field while using 
                // AddOrUpdate. My suspicion is that it cannot evaluate whether 
                // or not it is an update. Ther could also be a EF version issue
                // The club events assignment will work though as it is 
                clubEvents = new List<ClubEvent>()
            {	// Create a new ClubEvent 
                        new ClubEvent { StartDateTime = DateTime.Now.Subtract( new TimeSpan(5,0,0,0,0)),
                           EndDateTime = DateTime.Now.Subtract( new TimeSpan(5,0,0,0,0)),
                           Location="Sligo", Venue="Arena",
                           // Update attendees with a method similar to the SeedClubMembers 
                           // See below
                        },
                        new ClubEvent { StartDateTime = DateTime.Now.Subtract( new TimeSpan(3,0,0,0,0)),
                           EndDateTime = DateTime.Now.Subtract( new TimeSpan(3,0,0,0,0)),
                           Location="Sligo", Venue="Main Canteen"
        },
            }
            });

            #endregion
            #region club2
            context.Clubs.AddOrUpdate(c => c.ClubName,
                new Club { ClubName = "The Chess Club", CreationDate = DateTime.Now });
            #endregion
            context.SaveChanges(); // NOTE EF will update the relevant foreign key fields in the clubs, club events and member tables based on the attributes
                                   // But not always!! So
        }
    }
}
