using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TraineeFront.Models;
using TraineeFront.Service;

namespace TraineeFront.Pages.Trainee
{
    public class EditModel : PageModel
    {
        private readonly TraineeService _service;
        public EditModel(TraineeService service)
        {
            _service = service;
        }
        [BindProperty]
        public Models.Trainee Trainee { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Trainee=await _service.GetTraineeById(id);
            if(Trainee == null)
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
            await _service.UpdateTrainee(Trainee.Id, Trainee);
            return RedirectToPage("TraineeList");
        }
    }
}
