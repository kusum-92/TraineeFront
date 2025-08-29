using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TraineeFront.Service;

namespace TraineeFront.Pages.Course
{
    public class CreateModel : PageModel
    {
        private readonly CourseService _service;
        public CreateModel(CourseService service)
        {
            _service = service;
        }
        [BindProperty]
        public Models.Course Course { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _service.AddCourse(Course);
            return RedirectToPage("CourseList");

        }
    }
}
