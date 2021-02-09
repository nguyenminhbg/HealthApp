using HealthApp.Models.Home;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthApp.Services.Home
{
    public class GetExerciseService : IGetExerciseService
    {
        public Task<List<Exercise>> GetExcerceseInfo(int Id)
        {
            return Task.FromResult(new List<Exercise>()
                {
                    new Exercise()
                    {
                        Url="Shoes.png",
                        GoalKcal=5,
                        CompletedKcal=2,
                        CompletedTime=200,
                        GoalTime=300,
                        CompletedRate=47
                    },
                     new Exercise()
                    {
                        Url="Weights.png",
                        GoalKcal=5,
                        CompletedKcal=2,
                        CompletedTime=200,
                        GoalTime=300,
                        CompletedRate=47
                    },
                       new Exercise()
                    {
                        Url="Bike.png",
                        GoalKcal=5,
                        CompletedKcal=2,
                        CompletedTime=200,
                        GoalTime=300,
                        CompletedRate=47
                    },
                           new Exercise()
                    {
                        Url="Fruit.png",
                        GoalKcal=5,
                        CompletedKcal=2,
                        CompletedTime=200,
                        GoalTime=300,
                        CompletedRate=47
                    },
                });
        }
    }
}
