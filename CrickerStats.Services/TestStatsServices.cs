using CricketerStats.Data;
using CricketerStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrickerStats.Services
{
    public class TestStatsServices

    {
        private readonly Guid _userId;

        public TestStatsServices(Guid userId)
        {
            _userId = userId;
        }

        //Create OneDayStats
        public bool CreateTestStats(TestStatsCreate model)
        {
            var ctx = new ApplicationDbContext();
            var Cricketer = ctx.Cricketerss.Find(model.CricketerId);
            if (Cricketer != null)
            {
                var entity =
                new TestStats()
                {
                    UserId = _userId,
                    DoubleCenturyTest = model.DoubleCenturyTest,
                    HalfCenturyTest = model.HalfCenturyTest,
                    CricketerId = Cricketer.CricketerId

                };

                using (ctx)
                {
                    ctx.TestStatss.Add(entity);
                    return ctx.SaveChanges() == 1;
                }

            }
            return false;

        }

        //Get Cricketers

        public IEnumerable<TestStatsList> GetTestStats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TestStatss
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new TestStatsList
                                {
                                    TestId = e.TestId,
                                    CricketerId = e.CricketerId,
                                    DoubleCenturyTest = e.DoubleCenturyTest,
                                    HalfCenturyTest = e.HalfCenturyTest
                                    

                                }
                        );

                return query.ToArray();
            }
        }


        public IEnumerable<TestStatsList> GetTestStatsByCricketer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TestStatss
                        .Where(e => e.CricketerId == id && e.UserId == _userId)
                        .Select(
                            e =>
                                new TestStatsList
                                {
                                    TestId = e.TestId,
                                    CricketerId = e.CricketerId,
                                    DoubleCenturyTest = e.DoubleCenturyTest,
                                    HalfCenturyTest = e.HalfCenturyTest

                                }
                        );

                return query.ToArray();
            }
        }

        //public OneDayStatsDetails GetOneDayStatsById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .OneDayStatss
        //                .Single(e => e.CricketerId == id);

        //        return
        //            new OneDayStatsDetails
        //            {

        //                WicketOneDayInt = entity.WicketOneDayInt,
        //                CenturyOneDayInt = entity.CenturyOneDayInt,
        //                CricketerId = entity.CricketerId,
        //                HatrickOneDayInt = entity.HatrickOneDayInt

        //            };
        //    }

        //}


        public TestStatsEdit GetTestStatsEditById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TestStatss
                        .Single(e => e.TestId == id);

                return
                    new TestStatsEdit
                    {

                        DoubleCenturyTest = entity.DoubleCenturyTest,
                        HalfCenturyTest = entity.HalfCenturyTest,
                        TestId = entity.TestId,
                        CricketerId = entity.CricketerId

                    };
            }

        }

        public bool UpdateTestStats(TestStatsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TestStatss
                    .Single(e => e.TestId == model.TestId && e.UserId == _userId);

                entity.DoubleCenturyTest = model.DoubleCenturyTest;
                entity.HalfCenturyTest = model.HalfCenturyTest;
                

                return ctx.SaveChanges() == 1;
            }
        }



        public bool DeleteTestStats(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TestStatss
                    .Single(e => e.TestId == id && e.UserId == _userId);

                ctx.TestStatss.Remove(entity);

                return ctx.SaveChanges() == 1;


            }
        }
    }
}

