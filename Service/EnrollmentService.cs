using System.Net.Http;
using System.Net.Http.Json;
using TraineeFront.Models;

namespace TraineeFront.Service
{
    public class EnrollmentService
    {
        private readonly HttpClient _httpClient;

        public EnrollmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7086/api/");
        }

        // Get all enrollments
        public async Task<List<Enrollment>> GetEnrollmentsAsync()
        {
            var enrollments = await _httpClient.GetFromJsonAsync<List<Enrollment>>("Enrollment");
            return enrollments ?? new List<Enrollment>();
        }

        // Get single enrollment by id
        public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Enrollment>($"Enrollment/{id}");
        }

        // Create enrollment
        public async Task<bool> AddEnrollmentAsync(Enrollment enrollment)
        {
            var response = await _httpClient.PostAsJsonAsync("Enrollment", enrollment);
            return response.IsSuccessStatusCode;
        }

        // Update enrollment
        public async Task<bool> UpdateEnrollmentAsync(int id, Enrollment enrollment)
        {
            var response = await _httpClient.PutAsJsonAsync($"Enrollment/{id}", enrollment);
            return response.IsSuccessStatusCode;
        }

        // Delete enrollment
        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Enrollment/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
