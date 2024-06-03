using MvcCoreConciertos.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreConciertos.Services
{
    public class ServiceConciertos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceConciertos(keysModel keys)
        {
            this.UrlApi = keys.ApiConciertos;

            this.header = new MediaTypeWithQualityHeaderValue
                ("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "/api/Conciertos";
            List<Evento> data =
                await this.CallApiAsync<List<Evento>>(request);
            return data;
        }

        public async Task<List<Evento>>
            GetEventosByCategoriaAsync(int idcategoria)
        {
            string request = "/api/Conciertos/" + idcategoria;
            List<Evento> data =
                await this.CallApiAsync<List<Evento>>(request);
            return data;
        }

        public async Task<List<Categoria>>
            GetCategoriaAsync()
        {
            string request = "/api/Conciertos/Categorias";
            List<Categoria> data =
                 await this.CallApiAsync<List<Categoria>>(request);
            return data;
        }

    }
}
