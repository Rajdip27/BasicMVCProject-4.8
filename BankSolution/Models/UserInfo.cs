using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSolution.Models
{
    public class UserInfo
    {
        public string Name { get; set; }
        public int Id { get; internal set; }
    }

    public class UserRepository : IUserRepository
    {
        private static List<UserInfo> _users = new List<UserInfo>() { new UserInfo{Id=1,Name="Madan" } };

        public UserInfo GetUserById(int Id)
        {
            return _users.FirstOrDefault(f => f.Id == Id);
        }
        public List<UserInfo> GetUses()
        {
            return _users;
        }

        public void Insert(UserInfo user) =>
             _users.Add(user);

        public void Update(UserInfo user, int id)
        {
            var tmpUser = GetUserById(id);

            if (tmpUser != null)
            {
                tmpUser.Name = user.Name;
            }

        }
        public void Delete(UserInfo user)
        {
            _users.Remove(user);

        }
        public void Delete(int id)
        {
            var tmpUser = GetUserById(id);

            if (tmpUser != null)
            {
                Delete(tmpUser);
            }

        }
    }
}