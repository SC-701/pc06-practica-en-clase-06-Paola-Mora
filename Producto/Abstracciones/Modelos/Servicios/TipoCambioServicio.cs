using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Servicios
{
    using Abstracciones.Interfaces.Servicios;
    using Microsoft.Extensions.Configuration;
    using System.Net.Http.Headers;
    using System.Text.Json;

    public class TipoCambioServicio : ITipoCambioServicio
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TipoCambioServicio(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<decimal> ObtenerTipoCambioVentaAsync()
        {
            var urlBase = _configuration["BancoCentralCR:UrlBase"];
            var token = _configuration["BancoCentralCR:BearerToken"];

            var fecha = DateTime.Now.ToString("yyyy/MM/dd");

            var url = $"{urlBase}?fechaInicio={fecha}&fechaFin={fecha}&idioma=ES";

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error consultando el tipo de cambio");

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var resultado = JsonSerializer.Deserialize<BCCRResponse>(content, options);

            var tipoCambio = resultado?
                .Datos?.FirstOrDefault()?
                .Indicadores?.FirstOrDefault()?
                .Series?.FirstOrDefault()?
                .ValorDatoPorPeriodo ?? 0;

            return tipoCambio;
        }
    }

}
