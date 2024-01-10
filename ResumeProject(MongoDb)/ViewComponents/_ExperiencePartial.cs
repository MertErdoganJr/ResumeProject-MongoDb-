using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _ExperiencePartial : ViewComponent
    {
        private readonly IMongoCollection<Experience> _experienceCollection;
        public _ExperiencePartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _experienceCollection = database.GetCollection<Experience>(_databaseSettings.ExperienceCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var values = _experienceCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
