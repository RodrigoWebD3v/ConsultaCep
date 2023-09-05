using ConsultaCep.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsultaCep.Services
{
    public class CepService : ICepService
    {
        HttpClient _httpClient;
        JsonSerializerOptions _serializerOptions;

        public CepService()
        {
            _httpClient = new HttpClient();

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }
        public async Task<Cep> GetCep(int cep)
        {
            Cep cepRequest = null;

            try
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");


                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    cepRequest = await JsonSerializer.DeserializeAsync<Cep>(responseStream, _serializerOptions);
                }

                if (cepRequest.cep == null)
                {
                    throw new Exception("Cep Inexistente.");
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            return cepRequest;

        }
    }
}
