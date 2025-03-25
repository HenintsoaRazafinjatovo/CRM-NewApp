
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using newApp.Models;

namespace newApp.Service
{
    public class LoginService
    {
        public async Task<User> IsValid(string Username, string Password)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", Username),
                    new KeyValuePair<string, string>("password", Password)
                });

                 var response = await client.PostAsync("http://localhost:8080/api/login", content);
                 var options = new JsonSerializerOptions
                {
                     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  // Utilisation de la casse camel pour les noms de propriétés
                     PropertyNameCaseInsensitive = true                  // Ignorer la casse lors de la désérialisation
                };

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("leo bee"+result);
                // Désérialisation de la réponse JSON en objet User avec System.Text.Json
                var user = JsonSerializer.Deserialize<User>(result,options);
                return user!;  // Retourne l'objet User
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
                return null;  // Retourne null si la réponse échoue
            }
            }
        }
    }
}
