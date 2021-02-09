using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HealthApp.Models.Account
{
    public class AccountInfo: BindableBase
    {
        public string Id { set; get; }
        public string UrlAvarata { set; get; }
        public string FullName { set; get; }
        public string Address { set; get; }
        public int Status { set; get; }
        public double Weight { set; get; }
        public double Height { set; get; }
        public double Goal { set; get; }
    }

}
