using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TraineeFront.Pages
{
    public class CreateModel : PageModel
    {
        private TraineeService _service;
        public CreateModel(TraineeService service)
        {
            _service = service;
        }
        [BindProperty]
        public Trainee Trainee {  get; set; }

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Re-render page with validation messages
            }

            await _service.AddTrainee(Trainee);
            return RedirectToPage("TraineeList"); // Go back to list page
        }
    }
}
