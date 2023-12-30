using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.Controllers
{
    public class SkillController : Controller
    {
        private readonly IMongoCollection<Skill> _skillCollection;
        public SkillController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _skillCollection = database.GetCollection<Skill>(_databaseSettings.SkillCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var valeus = await _skillCollection.Find(x=>true).ToListAsync();
            return View(valeus);
        }

        [HttpGet]
        public IActionResult CreateSkills()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkills(Skill skill)
        {
            await _skillCollection.InsertOneAsync(skill);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSkill(string id)
        {
           await _skillCollection.DeleteOneAsync(x=>x.SkillID == id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSkill(string id)
        {
            var values = await _skillCollection.Find(x=>x.SkillID == id).FirstOrDefaultAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            await _skillCollection.FindOneAndReplaceAsync(x=>x.SkillID == skill.SkillID, skill);
            return RedirectToAction("Index");
        }
    }
}
