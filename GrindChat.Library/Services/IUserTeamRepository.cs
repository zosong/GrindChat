using GrindChat.Library.Models;

namespace GrindChat.Library.Services
{
    public interface IUserTeamRepository
    {
        IEnumerable<UserTeam> GetAll();
        UserTeam GetById(int id);
        UserTeam Add(UserTeam userTeam);
        UserTeam Update(UserTeam userTeam);
        void Delete(int id);
    }
}
