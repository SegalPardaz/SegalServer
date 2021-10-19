using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Segal.Data.Models;

namespace Segal.Services.Interfaces
{
   public interface IAuthService
   {
       Task<User> Login(string username, string password);
       Task<bool> Register(User user, string password);
  

   }
}
