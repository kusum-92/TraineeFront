using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TraineeFront.Models;
using TraineeFront.Service;

namespace TraineeFront.Pages.Trainee
{
    public class CreateModel : PageModel
    {
        private TraineeService _service;
        public CreateModel(TraineeService service)
        {
            _service = service;
        }
        [BindProperty]
        public Models.Trainee Trainee {  get; set; }

        
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
            return RedirectToPage("List"); // Go back to list page
        }
    }
}
