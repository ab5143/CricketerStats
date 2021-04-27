using CricketerStats.Data;
using CricketerStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrickerStats.Services
{
    public class OneDayStatsServices

    {
        private readonly Guid _userId;

        public OneDayStatsServices(Guid userId)
        {
            _userId = userId;
        }

        //Create OneDayStats
        public bool CreateOneDayStats(OneDayStatsCreate model)
        {
            var ctx = new ApplicationDbContext();
            var Cricketer = ctx.Cricketerss.Find(model.CricketerId);
            if (Cricketer != null)
            {
                var entity =
                new OneDayStats()
                {
                    UserId = _userId,
                    WicketOneDayInt = model.WicketOneDayInt,
                    CenturyOneDayInt = model.CenturyOneDayInt,
                    HatrickOneDayInt = model.HatrickOneDayInt,
                    CricketerId = Cricketer.CricketerId

                };

                using (ctx)
                {
                    ctx.OneDayStatss.Add(entity);
                    return ctx.SaveChanges() == 1;
                }

            }
            return false;

        }

        //Get Cricketers

        public IEnumerable<OneDayStatsList> GetOneDayStats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .OneDayStatss
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new OneDayStatsList
                                {
                                    WicketOneDayInt = e.WicketOneDayInt,
                                    CricketerId = e.CricketerId,
                                    CenturyOneDayInt = e.CenturyOneDayInt,
                                    HatrickOneDayInt = e.HatrickOneDayInt,
                                    OneDayIntId = e.OneDayIntId

                                }
                        );

                return query.ToArray();
            }
        }


        public IEnumerable<OneDayStatsList> GetOneDayStatsByCricketer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .OneDayStatss
                        .Where(e => e.CricketerId == id && e.UserId == _userId)
                        .Select(
                            e =>
                                new OneDayStatsList
                                {
                                    WicketOneDayInt = e.WicketOneDayInt,
                                    CricketerId = e.CricketerId,
                                    CenturyOneDayInt = e.CenturyOneDayInt,
                                    HatrickOneDayInt = e.HatrickOneDayInt,
                                    OneDayIntId = e.OneDayIntId

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


        public OneDayStatsEdit GetOneDayStatsEditById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OneDayStatss
                        .Single(e => e.OneDayIntId == id);

                return
                    new OneDayStatsEdit
                    {

                        WicketOneDayInt = entity.WicketOneDayInt,
                        CenturyOneDayInt = entity.CenturyOneDayInt,
                        HatrickOneDayInt = entity.HatrickOneDayInt,
                        OneDayIntId = entity.OneDayIntId,
                        CricketerId = entity.CricketerId

                    };
            }

        }

        public bool UpdateOneDayStats(OneDayStatsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .OneDayStatss
                    .Single(e => e.OneDayIntId == model.OneDayIntId && e.UserId == _userId);

                entity.WicketOneDayInt = model.WicketOneDayInt;
                entity.CenturyOneDayInt = model.CenturyOneDayInt;
                entity.HatrickOneDayInt = model.HatrickOneDayInt;




                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOneDayStats(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .OneDayStatss
                    .Single(e => e.OneDayIntId == id && e.UserId == _userId);

                ctx.OneDayStatss.Remove(entity);

                return ctx.SaveChanges() == 1;


            }
        }
    }
}





