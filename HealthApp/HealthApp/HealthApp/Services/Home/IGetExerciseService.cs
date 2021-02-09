using HealthApp.Models.Home;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthApp.Services.Home
{
    public  interface IGetExerciseService
    {
      Task<List<Exercise>> GetExcerceseInfo(int Id);
    }
}
