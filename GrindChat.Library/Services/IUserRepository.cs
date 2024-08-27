using System.Collections.Generic;
using GrindChat.Library.Models;

namespace GrindChat.Library.Services
{

    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Add(User user);
        User Update(User user);
        void Delete(int id);
    }
}
