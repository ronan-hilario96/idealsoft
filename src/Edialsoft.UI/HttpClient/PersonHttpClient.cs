using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Edialsoft.UI.ViewModel;
using Newtonsoft.Json;

namespace Edialsoft.UI.HttpClient
{
    public static class PersonHttpClient
    {
        private static readonly string URL = "http://localhost:3698/api/v1/Person/";
        // private static readonly string URL = "https://localhost:44367/api/v1/Person/";

        public static async Task<List<PersonViewModel>> Get()
        {
            string uri = URL;

            List<PersonViewModel> response = new List<PersonViewModel>();

            using (System.Net.Http.HttpClient cliente = new System.Net.Http.HttpClient())
            using (HttpResponseMessage resposta = await cliente.GetAsync(uri))
            using (HttpContent conteudo = resposta.Content)
            {
                // ... Lendo a string
                string resultado = await conteudo.ReadAsStringAsync();
                // ... Exibe o resutlado

                response = JsonConvert.DeserializeObject<List<PersonViewModel>>(resultado);
            }

            return response;
        }

        public static async Task Post(PersonViewModel person)
        {
            var jsonContent = JsonConvert.SerializeObject(person);

            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using (System.Net.Http.HttpClient cliente = new System.Net.Http.HttpClient())
            using (HttpResponseMessage resposta = await cliente.PostAsync(URL, contentString))
            using (HttpContent conteudo = resposta.Content)
            {
                // ... Lendo a string
                string resultado = await conteudo.ReadAsStringAsync();
                // ... Exibe o resutlado

                if (resultado != null && resultado.Length >= 150)
                {
                    Console.WriteLine(resultado.Substring(0, 150) + "...");
                }
            }
        }

        public static async Task Delete(int id)
        {
            string uri = URL + id;

            using (System.Net.Http.HttpClient cliente = new System.Net.Http.HttpClient())
            using (HttpResponseMessage resposta = await cliente.DeleteAsync(uri))
            using (HttpContent conteudo = resposta.Content)
            {
                // ... Lendo a string
                string resultado = await conteudo.ReadAsStringAsync();
                // ... Exibe o resutlado

                if (resultado != null && resultado.Length >= 150)
                {
                    Console.WriteLine(resultado.Substring(0, 150) + "...");
                }
            }
        }
    }
}
