using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _SpinnerPartial : ViewComponent
    {
        private readonly IMongoCollection<About> _aboutCollection;
        public _SpinnerPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var values = _aboutCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
