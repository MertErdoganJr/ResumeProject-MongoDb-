using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _EducationPartial : ViewComponent
    {
        private readonly IMongoCollection<Education> _educationCollection;
        public _EducationPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _educationCollection = database.GetCollection<Education>(_databaseSettings.EducationCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var values = _educationCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
