using ExpeditionFuelsHub.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Contracts.Admin
{
    public interface IUserService
    {
       //  Task<string> UserFullName(string userId);

        Task<IEnumerable<UserServiceModel>> All();

         Task<IEnumerable<UserServiceModel>> AssignRole();

        Task AssignToRole(string iserid);

          Task<bool> Forget(string userId);
    }
}
