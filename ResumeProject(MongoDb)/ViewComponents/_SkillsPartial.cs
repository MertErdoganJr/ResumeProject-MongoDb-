using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _SkillsPartial : ViewComponent
    {
        private readonly IMongoCollection<Skill> _skillCollection;
        public _SkillsPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _skillCollection = database.GetCollection<Skill>(_databaseSettings.SkillCollectionName);
        }
        public IViewComponentResult Invoke() 
        {
            var values = _skillCollection.Find(x => true).ToList();           
            return View(values); 
        }
    }
}
