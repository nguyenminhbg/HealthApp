using HealthApp.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Services.Home
{
   public interface IGetAccountService
    {
        Task<AccountInfo> GetAccountInfo(string Id);
    }
}
