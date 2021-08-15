using System;
using UtopiaCity.Models.Sport;
using UtopiaCity.Models.Sport.Enums;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCityTest.Common.ObjectsForTests
{
    public static class SportObjectsForTests
    {
        public static SportComplex SportComplexForTests()
        {
            return new SportComplex
            {
                SportComplexId = "1",
                Title = "title_1",
                Address = "address_1",
                NumberOfSeats = 100,
                TypeOfSport = TypesOfSport.Athletics,
                BuildDate = new DateTime(2021, 8, 10),
                SportEvents = null
            };
        }

        public static SportComplexViewModel SportComplexViewModelForTests()
        {
            return new SportComplexViewModel
            {
                SportComplexId = "1",
                SportComplexTitle = "title_1",
                Address = "address_1",
                NumberOfSeats = 100,
                TypeOfSport = TypesOfSport.Athletics,
                BuildDate = new DateTime(2021, 8, 10),
            };
        }

        public static SportComplex[] ArrayOfSportComplexesForTests()
        {
            SportComplex[] sportComplexes = new SportComplex[]
                {
                    new SportComplex
                    {
                        SportComplexId = "1",
                        Title = "title_1",
                        NumberOfSeats = 100,
                        TypeOfSport = TypesOfSport.Athletics,
                        Address = "address_1",
                        BuildDate = new DateTime(2021, 10, 12),
                        SportEvents = null
                    },

                    new SportComplex
                    {
                        SportComplexId = "2",
                        Title = "title_2",
                        NumberOfSeats = 200,
                        TypeOfSport = TypesOfSport.FigureSkating,
                        Address = "address_2",
                        BuildDate = new DateTime(2022, 10, 12),
                        SportEvents = null
                    },

                    new SportComplex
                    {
                        SportComplexId = "3",
                        Title = "title_3",
                        NumberOfSeats = 300,
                        TypeOfSport = TypesOfSport.Motorsport,
                        Address = "address_3",
                        BuildDate = new DateTime(2023, 10, 12),
                        SportEvents = null
                    }
                };

            return sportComplexes;
        }

        public static SportEvent SportEventForTests()
        {
            return new SportEvent
            {
                SportEventId = "1",
                Title = "title_1",
                DateOfTheEvent = new DateTime(2021, 11, 12),
                SportComplexId = "1"
            };
        }

        public static SportEventViewModel SportEventViewModelForTests()
        {
            return new SportEventViewModel
            {
                SportEventId = "1",
                SportEventTitle = "title_1",
                DateOfTheEvent = new DateTime(2021, 11, 12),
                SportComplexId = "1",
                SportComplexTitle = "title_1",
                Address = "address_1"
            };
        }

        public static SportEvent[] ArrayOfSportEventsForTests()
        {
            SportEvent[] sportEvents = new SportEvent[]
            {
                new SportEvent
                {
                    SportEventId = "1",
                    Title = "title_1",
                    DateOfTheEvent = new DateTime(2021, 11, 12),
                    SportComplexId = "1"
                },

                new SportEvent
                {
                    SportEventId = "2",
                    Title = "title_2",
                    DateOfTheEvent = new DateTime(2021, 11, 12),
                    SportComplexId = "2"
                },

                new SportEvent
                {
                    SportEventId = "3",
                    Title = "title_3",
                    DateOfTheEvent = new DateTime(2021, 11, 12),
                    SportComplexId = "3"
                }
            };

            return sportEvents;
        }
    }
}