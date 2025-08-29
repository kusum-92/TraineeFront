using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TraineeFront.Service;

namespace TraineeFront.Pages.Course
{
    public class EditModel : PageModel
    {
        private readonly CourseService _service;
        public EditModel(CourseService service)
        {
            _service = service;
        }
        [BindProperty]
        public Models.Course Course { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Course = await _service.GetCourseById(id);
            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _service.UpdateCourse(Course.CourseId, Course);
            return RedirectToPage("CourseList");
        }
        public void OnGet()
        {
        }
    }
}
