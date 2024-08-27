using System.Collections.Generic;
using System.Linq;
using GrindChat.Library.Models;
using GrindChat.Library.Services;
using Microsoft.EntityFrameworkCore;

namespace GrindChat.API.Data
{
    public class UserRepository : IUserRepository
    {
        //        private readonly GrindChatDb _context;

        //        public UserRepository(GrindChatDb context)
        //        {
        //            _context = context;
        //        }

        //        public IEnumerable<User> GetAll()
        //        {
        //            return _context.Users.ToList();
        //        }

        //        public User GetById(int id)
        //        {
        //            return _context.Users.Find(id);
        //        }

        //        public User Add(User user)
        //        {
        //            _context.Users.Add(user);
        //            _context.SaveChanges();
        //            return user;
        //        }

        //        public User Update(User user)
        //        {
        //            _context.Entry(user).State = EntityState.Modified;
        //            _context.SaveChanges();
        //            return user;
        //        }

        //        public void Delete(int id)
        //        {
        //            var user = _context.Users.Find(id);
        //            if (user != null)
        //            {
        //                _context.Users.Remove(user);
        //                _context.SaveChanges();
        //            }
        //        }
        //    }
        //}
        private readonly IFreeSql _db;

        public UserRepository()
        {
            _db = FreesqlManager.HsjFreeSQL;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Select<User>().IncludeMany(u => u.UserTeams).ToList();


        }

        public User GetById(int id)
        {
            return _db.Select<User>().IncludeMany(u => u.UserTeams).Where(u => u.Id == id).First();
        }

        public User Add(User user)
        {
            _db.Insert(user).ExecuteAffrows();
            return user;
        }

        public User Update(User user)
        {
            _db.Update<User>().SetSource(user).ExecuteAffrows();
            return user;
        }

        public void Delete(int id)
        {
            _db.Delete<User>().Where(u => u.Id == id).ExecuteAffrows();
        }
    }
}