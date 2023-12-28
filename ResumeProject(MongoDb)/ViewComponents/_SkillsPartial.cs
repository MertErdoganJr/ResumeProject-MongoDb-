using Microsoft.AspNetCore.Mvc;

namespace ResumeProject_MongoDb_.ViewComponents
{
    public class _SkillsPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
