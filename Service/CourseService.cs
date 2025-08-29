using System.Text.Json;
using TraineeFront.Models;
namespace TraineeFront.Service
{
    public class CourseService
    {
        private HttpClient _httpClient;
        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7086/api/");
        }
        public async Task<List<Models.Course>> GetCourses()
        {
            await using Stream stream = await _httpClient.GetStreamAsync("Course");
            var courses = await JsonSerializer.DeserializeAsync<List<Course>>(stream);
            return courses;
        }
        public async Task<Course> AddCourse(Course course)
        {
            var response = await _httpClient.PostAsJsonAsync("Course",course);
            response.EnsureSuccessStatusCode();
            var createdcourse = await response.Content.ReadFromJsonAsync<Course>();
            return createdcourse;
        }
        public async Task<bool> DeleteCourse(int id)
        {
            var res = await _httpClient.DeleteAsync($"Course/{id}");
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateCourse(int id, Course course)
        {
            var res = await _httpClient.GetAsync($"Course{id}");
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        
        public async Task<Course> GetCourseById(int courseid)
        {
            var response = await _httpClient.GetAsync($"Course/{courseid}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Course>();
            }
            return null;
        }
    }
}
