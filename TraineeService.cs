using System.Net.Http;
using System.Text.Json;
namespace TraineeFront
{
    public class TraineeService
    {
        private readonly HttpClient _httpClient;
        public TraineeService() { }
        public TraineeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7086/api/");
        }

        public async Task<List<Trainee>> GetTrainees()
        {
            //HttpClient client = new HttpClient();
            await using Stream stream = await _httpClient.GetStreamAsync("Trainee");
            var trainees = await JsonSerializer.DeserializeAsync<List<Trainee>>(stream);
            return trainees;
        }
        public async Task<Trainee> AddTrainee(Trainee trainee)
        {
            //HttpClient client=new HttpClient();
            var response = await _httpClient.PostAsJsonAsync("Trainee",trainee);
            response.EnsureSuccessStatusCode();
            var createdtrainee = await response.Content.ReadFromJsonAsync<Trainee>();
            return createdtrainee;

        }
        public async Task<bool> DeleteTrainee(int id)
        {
            //HttpClient client=new HttpClient();
            var response = await _httpClient.DeleteAsync($"Trainee/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }
        public async Task<bool> UpdateTrainee(int id,Trainee trainee)
        {
            var response = await _httpClient.PutAsJsonAsync($"Trainee/{id}", trainee);
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<Trainee> GetTraineeById(int id)
        {
            var response = await _httpClient.GetAsync($"Trainee/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Trainee>();
            }
            return null;
        }

        
    }
}
