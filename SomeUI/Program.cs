using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiApp.Domain;
using SamuraiApp.Data;

namespace SomeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleSamuraiQuery();
        }

        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
            }
        }

        private static void InsertMultipleDifferentObjects()
        {
            var samurai = new Samurai { Name = "Ethan" };
            var battle = new Battle
            {
                Name = "Helm's Deep",
                StartDate = new DateTime(1972, 07, 07),
                EndDate = new DateTime(1973, 07, 07)
            };

            using (var context = new SamuraiContext())
            {
                context.AddRange(samurai, battle);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleSamurai()
        {
            var samuraiA = new Samurai { Name = "Ormain" };
            var samuraiB = new Samurai { Name = "Marianna" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samuraiA, samuraiB);
                context.SaveChanges();
            }
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Dave" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
    }
}
