using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using ResumeProject_MongoDb_.DAL.Entities;
using ResumeProject_MongoDb_.DAL.Settings;

namespace ResumeProject_MongoDb_.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IMongoCollection<Project> _projectCollection;
        public ProjectController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _projectCollection = database.GetCollection<Project>(_databaseSettings.ProjectCollectionName);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProjectList()
        {
            var values = await _projectCollection.Find(x=>true).ToListAsync();
            var jsonProject = JsonConvert.SerializeObject(values);
            return Json(jsonProject);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            await _projectCollection.InsertOneAsync(project);
            var values = JsonConvert.SerializeObject(project);
            return Json(values);
        }

        public async Task<IActionResult> GetProject(string ProjectId)
        {
            var valeus = await _projectCollection.Find(x => x.ProjectID == ProjectId).FirstOrDefaultAsync();
            var jsonValues = JsonConvert.SerializeObject(valeus);
            return Json(jsonValues);
        }

        public async Task<IActionResult> DeleteProject(string id)
        {
            await _projectCollection.DeleteOneAsync(x=>x.ProjectID == id);
            return NoContent();
        }

        public async Task<IActionResult> UpdateProject(Project project)
        {
            var values = await _projectCollection.FindOneAndReplaceAsync(x=>x.ProjectID == project.ProjectID, project);
            return NoContent();
        }

    }
}
