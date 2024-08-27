using System.Collections.Generic;
using GrindChat.Library.Models;

namespace GrindChat.Library.Services
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        Team GetById(int id);
        Team Add(Team team);
        Team Update(Team team);
        void Delete(int id);
    }
}
