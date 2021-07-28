using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport.TransportManagerSystem;

namespace UtopiaCity.Common.Initializers.AirportTransportSystem
{
    public class ForPassengerInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.ForPassengers.Any())
            {
                return;
            }

            context.RemoveRange(context.ForPassengers.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.ForPassengers.Any())
            {
                return;
            }

            var passenger1 = new ForPassenger
            {
                Id = "Gregorii",
                MobilePhone = "97773332211",
                FullName = "Gregor'ev Gregorii Gregorievich",
                Address = "Rechnaya 7",
                TransportType = "car",
                PayType = "cash",
            };

            var passenger2 = new ForPassenger
            {
                Id = "Vanya",
                MobilePhone = "97786452323",
                FullName = "Ivanov Ivan Ivanovich",
                Address = "Rechnaya 6",
                TransportType = "BusNumber",
                PayType = "cash",
            };
            var passenger3 = new ForPassenger
            {
                Id = "Jenya",
                MobilePhone = "87754331212",
                FullName = "Evgen'ev Evgenii Evgenievich",
                Address = "Rechnaya 8",
                TransportType = "BusNumber",
                PayType = "BankService",
            };
            var passenger4 = new ForPassenger
            {
                Id = "Petya",
                MobilePhone = "97783256454",
                FullName = "Petrov Petr Petrovich",
                Address = "Rechnaya 2",
                TransportType = "car",
                PayType = "cash",
            };
            var passenger5 = new ForPassenger
            {
                Id = "Sasha",
                MobilePhone = "97778056311",
                FullName = "Aleksandrov Aleksandr Aleksandrovich",
                Address = "Rechnaya 3",
                TransportType = "BusNumber",
                PayType = "webMoney",
            };
            var passenger6 = new ForPassenger
            {
                Id = "Nastya",
                MobilePhone = "12634500303",
                FullName = "Petrova Anastasiya Arkadievna",
                Address = "Braiton str 11/24",
                TransportType = "AirportSpecialBus",
                PayType = "cash",
            };
            var passenger7 = new ForPassenger
            {
                Id = "Vasya",
                MobilePhone = "78435232121",
                FullName = "Vasil'ev Vasilii Vasil'evich",
                Address = "Sadovaya 8",
                TransportType = "car",
                PayType = "eMoney",
            };
            var passenger8 = new ForPassenger
            {
                Id = "Sergei",
                MobilePhone = "87772473589",
                FullName = "Sergeev Sergei Sergeevich",
                Address = "Yablochnaya 24",
                TransportType = "BusNumber",
                PayType = "cash",
            };
            var passenger9 = new ForPassenger
            {
                Id = "Kolya",
                MobilePhone = "99873034452",
                FullName = "Nikolaev Nikolai Nikolaevich",
                Address = "Yablochnaya 28",
                TransportType = "car",
                PayType = "eMoney",
            };
            var passenger10 = new ForPassenger
            {
                Id = "Oleg",
                MobilePhone = "87332226454",
                FullName = "Olegov Oleg Olegovich",
                Address = "Yablochnaya 15",
                TransportType = "car",
                PayType = "webMoney",
            };

            context.AddRange(passenger1, passenger2, passenger3, passenger4, passenger5, passenger6, passenger7, passenger8, passenger9, passenger10);
            context.SaveChanges();
        }
    }
}
