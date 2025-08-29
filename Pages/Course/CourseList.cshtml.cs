using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TraineeFront.Service;

namespace TraineeFront.Pages.Course
{
    public class CourseListModel : PageModel
    {
        private readonly CourseService _service;
        public CourseListModel(CourseService service)
        {
            _service = service;
        }
     
        public Task<List<Models.Course>> CourseList { get; set; }

        public void OnGet()
        {
            CourseList= _service.GetCourses();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _service.DeleteCourse(id);
            return RedirectToPage();
        }
    }
}
