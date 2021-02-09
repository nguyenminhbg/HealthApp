using HealthApp.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Services.Home
{
    public class GetAccountSevice : IGetAccountService
    {
        public Task<AccountInfo> GetAccountInfo(string Id)
        {
            var account = new AccountInfo()
            {
                UrlAvarata = "AvartaStatus.png",
                FullName = "Williana",
                Address = "26 Years, London",
                Status = 1,
                Goal = 68,
                Height = 5.11,
                Weight = 74,
            };
            return Task.FromResult(account);

        }
    }
}
