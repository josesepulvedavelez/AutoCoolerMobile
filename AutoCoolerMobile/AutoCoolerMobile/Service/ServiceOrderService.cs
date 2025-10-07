using AutoCoolerMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoolerMobile.Service
{
    public class ServiceOrderService
    {
        private readonly HttpClient _httpClient;

        public ServiceOrderService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(AppConfig.ApiBaseUrl) };
        }

        ///
        public async Task<List<ServiceOrderForTechnicianDto>> GetServiceOrdersByTechnician(int technicianId)
        {
            var response = await _httpClient.GetAsync($"api/ServiceOrder/GetServiceOrdersByTechnician/{technicianId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ServiceOrderForTechnicianDto>>(content);
            }
            else
            {
                throw new Exception("Failed to retrieve service orders");
            }
        }

        public async Task<ServiceOrderForTechnicianDto> GetServiceOrderById(int serviceOrderId)
        {
            var response = await _httpClient.GetAsync($"api/ServiceOrder/GetServiceOrderById/{serviceOrderId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ServiceOrderForTechnicianDto>(content);
            }
            else
            {
                throw new Exception("Failed to retrieve service order detail");
            }
        }

    }
}
