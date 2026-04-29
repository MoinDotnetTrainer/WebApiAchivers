using MyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Interface
{
    public interface IUsers
    {
        Task<List<Users>> GetAllUsers();  // collection all records
        Task AddUsers(Users data);// abs method
        Task<Users> GetUserByID(int ID);// all data , we are gettig row data by id
        Task EditUsers(Users data);
        Task DeleteUser(int ID);

    }
}
