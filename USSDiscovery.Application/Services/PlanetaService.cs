using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using USSDiscovery.Application.Interfaces;

namespace USSDiscovery.Application.Services
{
    public class PlanetaService : IPlanetaService
    {
        public void cross()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.dev/api/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("planets/2/").Result;
            if (response.IsSuccessStatusCode)
            {
                var ListaPlanetas = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
