using System.Collections.Generic;
using System.Linq;
using GrindChat.Library.Models;
using GrindChat.Library.Services;
using GrindChat.API.Data;
using Microsoft.EntityFrameworkCore;

namespace GrindChat.API.Data
{
    //public class TeamRepository : ITeamRepository
    //{
    //private readonly GrindChatDb _context;

    //public TeamRepository(GrindChatDb context)
    //{
    //    _context = context;
    //}

    //public IEnumerable<Team> GetAll()
    //{
    //    return _context.Teams.ToList();
    //}

    //public Team GetById(int id)
    //{
    //    return _context.Teams.Find(id);
    //}

    //public Team Add(Team team)
    //{
    //    _context.Teams.Add(team);
    //    _context.SaveChanges();
    //    return team;
    //}

    //public Team Update(Team team)
    //{
    //    _context.Entry(team).State = EntityState.Modified;
    //    _context.SaveChanges();
    //    return team;
    //}

    //public void Delete(int id)
    //{
    //    var team = _context.Teams.Find(id);
    //    if (team != null)
    //    {
    //        _context.Teams.Remove(team);
    //        _context.SaveChanges();
    //    }
    //}
    // }
    public class TeamRepository : ITeamRepository
    {
    

        private readonly IFreeSql _db;



        public TeamRepository()
        {
            _db = FreesqlManager.HsjFreeSQL;
        }

        public IEnumerable<Team> GetAll()
        {
            return _db.Select<Team>()
                        .Include(t => t.Admin)
                        .IncludeMany(t => t.UserTeams)
                        .ToList();

        }

        public Team GetById(int id)
        {
            return _db.Select<Team>()
             .Include(t => t.Admin)
             .IncludeMany(t => t.UserTeams)
             .Where(t => t.Id == id)
             .First();

        }

        public Team Add(Team team)
        {

            var ret = _db.Insert(team).ExecuteInserted(); 
            return ret.FirstOrDefault();

        }

        public Team Update(Team team)
        {
            _db.Update<Team>().SetSource(team).ExecuteAffrows();
            return team;
        }

        public void Delete(int id)
        {
            _db.Delete<Team>().Where(t => t.Id == id).ExecuteAffrows();
        }
    }
}