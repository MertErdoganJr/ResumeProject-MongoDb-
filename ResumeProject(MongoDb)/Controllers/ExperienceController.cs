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

        public async Task<IActionResult> GetExperience(string ExperienceId)
        {
            var values = await _experinceCollection.Find(x=>x.ExperienceID == ExperienceId).FirstOrDefaultAsync();
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public async Task<IActionResult> DeleteExperience(string id)
        {
            await _experinceCollection.DeleteOneAsync(x=>x.ExperienceID == id);
            return NoContent();
        }

        public async Task<IActionResult> UpdateExperience(Experience experience)
        {
            var values = await _experinceCollection.FindOneAndReplaceAsync(x => x.ExperienceID == experience.ExperienceID, experience);
            return NoContent();
        }
    }
}
