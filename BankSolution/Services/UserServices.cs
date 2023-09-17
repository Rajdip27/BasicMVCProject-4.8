using BankSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BankSolution.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<UserInfo> GetUserById(int id)
        {
            return Task.FromResult(_repository.GetUserById(id));
        }

    }
}