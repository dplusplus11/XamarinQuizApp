using Newtonsoft.Json;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterUserAsync(
            string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                "http://localhost:56408/api/Account/Register", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


    }
}
