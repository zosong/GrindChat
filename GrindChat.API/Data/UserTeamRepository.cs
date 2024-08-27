using System.Collections.Generic;
using System.Linq;
using GrindChat.Library.Models;
using GrindChat.Library.Services;
using Microsoft.EntityFrameworkCore;

namespace GrindChat.API.Data
{
    public class UserTeamRepository : IUserTeamRepository
    {
        //        private readonly GrindChatDb _context;

        //        public UserTeamRepository(GrindChatDb context)
        //        {
        //            _context = context;
        //        }

        //        public IEnumerable<UserTeam> GetAll()
        //        {
        //            return _context.UsersTeam.Include(ut => ut.User)
        //                                     .Include(ut => ut.Team)
        //                                     .ToList();
        //        }

        //        public UserTeam GetById(int id)
        //        {
        //            return _context.UsersTeam.Include(ut => ut.User)
        //                                     .Include(ut => ut.Team)
        //                                     .FirstOrDefault(ut => ut.Id == id);
        //        }

        //        public UserTeam Add(UserTeam userTeam)
        //        {
        //            _context.UsersTeam.Add(userTeam);
        //            _context.SaveChanges();
        //            return userTeam;
        //        }

        //        public UserTeam Update(UserTeam userTeam)
        //        {
        //            _context.Entry(userTeam).State = EntityState.Modified;
        //            _context.SaveChanges();
        //            return userTeam;
        //        }

        //        public void Delete(int id)
        //        {
        //            var userTeam = _context.UsersTeam.Find(id);
        //            if (userTeam != null)
        //            {
        //                _context.UsersTeam.Remove(userTeam);
        //                _context.SaveChanges();
        //            }
        //        }
        //    }
        //}


        private readonly IFreeSql _db;

        public UserTeamRepository()
        {
            _db = FreesqlManager.HsjFreeSQL;
        }

        public IEnumerable<UserTeam> GetAll()
        {
            return _db.Select<UserTeam>().ToList();
        }

        public UserTeam GetById(int id)
        {
            return _db.Select<UserTeam>().Where(ut => ut.Id == id).First();
        }

        public UserTeam Add(UserTeam userTeam)
        {
            _db.Insert(userTeam).ExecuteAffrows();
            return userTeam;
        }

        public UserTeam Update(UserTeam userTeam)
        {
            _db.Update<UserTeam>().SetSource(userTeam).ExecuteAffrows();
            return userTeam;
        }

        public void Delete(int id)
        {
            _db.Delete<UserTeam>().Where(ut => ut.Id == id).ExecuteAffrows();
        }
    }
}