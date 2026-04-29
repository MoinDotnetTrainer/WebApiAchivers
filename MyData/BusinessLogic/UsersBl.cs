using Microsoft.EntityFrameworkCore;
using MyData.Interface;
using MyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.BusinessLogic
{
    public class UsersBl : IUsers
    {
        private readonly AppDb _db;
        public UsersBl(AppDb db)
        {
            _db = db;
        }
        public async Task<List<Users>> GetAllUsers()
        {
            return await _db.Users.AsNoTracking().ToListAsync();
        }
          public async Task AddUsers(Models.Users data)
          {
              await _db.Users.AddAsync(data);
              await _db.SaveChangesAsync();
          }
          public async Task<Users> GetUserByID(int ID)
          {
              var res = await (from s in _db.Users select s).AsNoTracking().FirstOrDefaultAsync(x => x.ID == ID);
              return res;
          }
          public async Task EditUsers(Users data)
          {
              var res = await _db.Users.Where(x => x.ID == data.ID).AsNoTracking().FirstOrDefaultAsync();
              // is now tracked by ef core
              var newrec = new Users
              {
                  ID = res.ID,
                  Name = data.Name,
                  Email = data.Email,
                  Password = data.Password,
                  Dob = data.Dob
              };
              _db.Users.Update(newrec);
              await _db.SaveChangesAsync();
          }
          public async Task DeleteUser(int ID)
          {
              var res = await _db.Users.FindAsync(ID);
              if (res != null)
              {
                  _db.Users.Remove(res);// await
                  await _db.SaveChangesAsync();
              }
          }
        
    }
}
