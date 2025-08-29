using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TraineeFront.Pages
{
    public class TraineeListModel : PageModel

    {
        private readonly TraineeService _service;
        public TraineeListModel(TraineeService service)
        {
            _service = service;
        }
        public Task<List<Trainee>> TraineeList { get; set; } 
        public void OnGet()
        {
            TraineeList = _service.GetTrainees();

        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _service.DeleteTrainee(id);
            return RedirectToPage();
        }
    }
}
