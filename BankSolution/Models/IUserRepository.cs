using System.Collections.Generic;

namespace BankSolution.Models
{
    public interface IUserRepository
    {
        void Delete(int id);
        void Delete(UserInfo user);
        UserInfo GetUserById(int Id);
        List<UserInfo> GetUses();
        void Insert(UserInfo user);
        void Update(UserInfo user, int id);
    }
}