using EmployeeMvc.Models;
using Newtonsoft.Json;
using System.Text;

namespace EmployeeMvc.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateEmployee(EmployeeCreateDtos employee)
        {
            //Creating HttpClient
            HttpClient httpClient = _httpClientFactory.CreateClient();

            //instantiate the HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7194/api/employee");

            //Convert the EmployeeCreateDtos object into a json string
            string jsonBody = JsonConvert.SerializeObject(employee);

            //instantiate the stringContent using the json string and encoding as this provides HtppContent based on a string
            StringContent body = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

            //Assign the body as the value to the property content of the HttpRequestMessage instance
            request.Content = body;

            //Send the request which returns back an HttpResponseMessage
            HttpResponseMessage response = await httpClient.SendAsync(request);

            //Check the status code of the response
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            //Read the response returned from the API as a string
            string content = await response.Content.ReadAsStringAsync();

            if (content is not "Successful")
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            //Create HttpClient
            HttpClient httpClient = _httpClientFactory.CreateClient();

            // instantiate the HttpMessagerequest
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7194/api/employee/{id}");

            HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7194/api/employee/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
            
        }

        public Task<EmployeeGetDtos?> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeGetDtos>> GetAll()

        {  //Create HttpClient
            HttpClient httpClient = _httpClientFactory.CreateClient();

            // instantiate the HttpMessageRequest
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7194/api/employee");

            //Send the Request which returns back an HttpMessageResponse 
            HttpResponseMessage response = await httpClient.SendAsync(request);

            //check the status Code of the response
            if(!response.IsSuccessStatusCode)
            {
                return new List<EmployeeGetDtos>();
            }

            //Read the response returned from the API as a string
            string content = await response.Content.ReadAsStringAsync();

            //Convert the json string into a List<EmployeeGetDto> object
            List<EmployeeGetDtos>? employees = JsonConvert.DeserializeObject<List<EmployeeGetDtos>>(content);

            return employees ?? new List<EmployeeGetDtos>();


        }

        public async Task<bool> UpdateAsync(int id, EmployeeCreateDtos employee)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            // Convert employee object to JSON
            var jsonContent = JsonConvert.SerializeObject(employee);

            // Wrap it in a request body
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // instantiate the HttpMessagerequest
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7194/api/employee/{id}");


            HttpResponseMessage response = await httpClient.PutAsync($"https://localhost:7194/api/employee/{id}", content);

            return response.IsSuccessStatusCode;


        }
    }
    
}
