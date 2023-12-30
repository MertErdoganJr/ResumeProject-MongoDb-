using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using MongoDB.Driver;
using Newtonsoft.Json;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IMongoCollection<Experience> _experinceCollection;
        public ExperienceController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _experinceCollection = database.GetCollection<Experience>(_databaseSettings.ExperienceCollectionName);
        }
        public IActionResult Index()
        {          
            return View();
        }


        public async Task<IActionResult> ExperienceList()
        {
            var values = await _experinceCollection.Find(x => true).ToListAsync();
            var jsonExperince = JsonConvert.SerializeObject(values);
            return Json(jsonExperince);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExperience(Experience experience)
        {
            await _experinceCollection.InsertOneAsync(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);

        }
    }
}
