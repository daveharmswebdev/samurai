using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiApp.Domain;
using SamuraiApp.Data;
using Microsoft.EntityFrameworkCore;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            //SimpleSamuraiQuery();
            //FilterQuery("Ormain");
            //RetrieveAndUpdate();
            //RetrieveAndUpdateMultiple();
            //InsertBattle();
            //AddALot();
            DeleteManyWhileTracked();
        }

        private static void AddALot()
        {
            _context.AddRange(
                new Samurai { Name = "Marcus" },
                new Samurai { Name = "Jamal" },
                new Samurai { Name = "Lysa" },
                new Samurai { Name = "Wynfred" },
                new Samurai { Name = "York" },
                new Samurai { Name = "Yally" }
                );
            _context.SaveChanges();
        }

        private static void DeleteManyWhileTracked()
        {
            var samurais = _context.Samurais.Where(s => s.Name.ToLower().Contains("y"));
            _context.Samurais.RemoveRange(samurais);
            _context.SaveChanges();
        }

        private static void InsertBattle()
        {
            _context.Battles.Add(new Battle
            {
                Name = "Battle of the Bastard's",
                StartDate = new DateTime(1983, 1, 1),
                EndDate = new DateTime(1983, 1, 2)
            });
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultiple()
        {
            var samurais = _context.Samurais.ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdate()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }

        private static void FilterQuery(string name)
        {
            var result = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "M%")).FirstOrDefault();
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
