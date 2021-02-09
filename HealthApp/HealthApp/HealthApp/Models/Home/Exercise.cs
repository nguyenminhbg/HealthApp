using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApp.Models.Home
{
    public class Exercise : BindableBase
    {
        public int Id { set; get; }
        public string Url { set; get; }
        public int GoalTime { set; get; }
        public double CompletedTime { set; get; }
        public int GoalKcal { set; get; }
        public double CompletedKcal { set; get; }
        public int CompletedRate { set; get; }
        public bool IsSelectedEx { set; get; }

    }
    public class DailyExcercise : BindableBase
    {
        public string Name { set; get; }
        public bool SelectedDate { set; get; }
    }
}
