using BankSolution.Models;
using System.Threading.Tasks;

namespace BankSolution.Services
{
    public interface IUserServices
    {
        Task<UserInfo> GetUserById(int id);
    }
}