using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TraineeFront.Service;
namespace TraineeFront.Pages.Enrollment
{
    public class EnrollmentListModel : PageModel
    {
        private readonly EnrollmentService _enrollmentService;
        private readonly TraineeService _traineeService;
        private readonly CourseService _courseService;
        public EnrollmentListModel(EnrollmentService enrollmentService, TraineeService traineeService, CourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _traineeService = traineeService;
            _courseService = courseService;
        }
        public List<Models.Enrollment> Enrollments { get; set; }
        //public Task<List<Models.Trainee>> TraineeList { get; set; }
        public async Task OnGetAsync()
        {
            var enrollments = await _enrollmentService.GetEnrollmentsAsync();
            var trainees = await _traineeService.GetTrainees();
            var courses = await _courseService.GetCourses();
            foreach (var e in enrollments)
            {
                e.TraineeName = e.TraineeName ?? trainees.FirstOrDefault(t => t.Id == e.TraineeId)?.Name;
                e.CourseName = e.CourseName ?? courses.FirstOrDefault(c => c.CourseId == e.CourseId)?.CourseName;

            }
            Enrollments= enrollments;
        }

    }
}