using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Models.Sport;
using UtopiaCity.Models.Sport.Enums;
using UtopiaCity.Data;

namespace UtopiaCity.Common.Initializers
{
    public class SportComplexInitializer : ISubDbInitializer
    {
        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.SportComplex.Any())
            {
                return;
            }

            var sportComplexes = new SportComplex[]
            {
                new SportComplex
                {
                    Title = "Central swimming pool",
                    NumberOfSeats = 1000,
                    BuildDate = DateTime.Now,
                    TypeOfSport = TypesOfSport.Swimming,
                    Address = "5th Avenue"
                },

                new SportComplex
                {
                    Title = "Central football stadium",
                    NumberOfSeats = 10000,
                    BuildDate = DateTime.Now,
                    TypeOfSport = TypesOfSport.Football,
                    Address = "Fleet street"
                },

                new SportComplex
                {
                    Title = "The main racing track of the city",
                    NumberOfSeats = 50000,
                    BuildDate = DateTime.Now,
                    TypeOfSport = TypesOfSport.Motorsport,
                    Address = "Seventh North street"
                },

                new SportComplex
                {
                    Title = "Snowy Mountains skating rink",
                    NumberOfSeats = 1000,
                    BuildDate = DateTime.Now,
                    TypeOfSport = TypesOfSport.FigureSkating,
                    Address = "Mountain street"
                },

                new SportComplex
                {
                    Title = "Central athletic stadium",
                    NumberOfSeats = 5000,
                    BuildDate = DateTime.Now,
                    TypeOfSport = TypesOfSport.Athletics,
                    Address = "5th Avenue"
                }
            };

            context.AddRange(sportComplexes);
            context.SaveChanges();
        }

        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.SportComplex.Any())
            {
                return;
            }

            context.RemoveRange(context.SportComplex.ToList());
            context.SaveChanges();
        }
    }
}
