using Microsoft.AspNetCore.Mvc;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _ContactPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
