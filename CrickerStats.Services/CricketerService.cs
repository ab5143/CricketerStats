using CricketerStats.Data;
using CricketerStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrickerStats.Services
{
    public class CricketerService
    {
        private readonly Guid _userId;

        public CricketerService(Guid userId)
        {
            _userId = userId;
        }

        //Create Cricketer 
        public bool CreateCricketer(CricketerCreate model)
        {
            var entity =
                new Cricketer()
                {
                    UserId = _userId,
                    Name = model.Name,
                    Country = model.Country,
                    TotalRuns = model.TotalRuns
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cricketerss.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get Cricketers

        public IEnumerable<CricketerList> GetCricketers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cricketerss
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new CricketerList
                                {
                                    Name = e.Name,
                                    CricketerId = e.CricketerId,

                                }
                        );

                return query.ToArray();
            }
        }


        public CricketerDetails GetCricketerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cricketerss
                        .Single(e => e.CricketerId == id && e.UserId == _userId);
                return
                    new CricketerDetails
                    {
                        Name = entity.Name,
                        Country = entity.Country,
                        TotalRuns = entity.TotalRuns,
                        CricketerId = entity.CricketerId
                        
                    };
            }

        }

        public bool UpdateCricketer(CricketerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cricketerss
                    .Single(e => e.CricketerId == model.CricketerId && e.UserId == _userId);

                entity.Name = model.Name;
                entity.Country = model.Country;
                entity.TotalRuns = model.TotalRuns;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCricketer(int cricketerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cricketerss
                    .Single(e => e.CricketerId == cricketerId && e.UserId == _userId);

                ctx.Cricketerss.Remove(entity);

                return ctx.SaveChanges() == 1;


            }
        }
    }
}


