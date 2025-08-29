using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraineeFront.Models;
using TraineeFront.Service;

namespace TraineeFront.Pages.Enrollment
{
    public class CreateModel : PageModel
    {
        private readonly EnrollmentService _enrollmentService;
        private readonly TraineeService _traineeService;
        private readonly CourseService _courseService;

        public CreateModel(EnrollmentService enrollmentService, TraineeService traineeService, CourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _traineeService = traineeService;
            _courseService = courseService;
        }

        [BindProperty]
        public Models.Enrollment Enrollment { get; set; } = default!;

        public SelectList Trainees { get; set; } = default!;
        public SelectList Courses { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var trainees = await _traineeService.GetTrainees();
            var courses = await _courseService.GetCourses();

            Trainees = new SelectList(trainees, "Id", "Name");
            Courses = new SelectList(courses, "CourseId", "CourseName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var success = await _enrollmentService.AddEnrollmentAsync(Enrollment);
            if (!success)
            {
                ModelState.AddModelError("", "Failed to create enrollment.");
                return Page();
            }

            return RedirectToPage("EnrollmentList");
        }
    }
}
