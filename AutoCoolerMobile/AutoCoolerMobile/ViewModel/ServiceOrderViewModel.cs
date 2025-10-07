using AutoCoolerMobile.Model;
using AutoCoolerMobile.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoolerMobile.ViewModel
{
    public class ServiceOrderViewModel : INotifyPropertyChanged
    {
        private readonly ServiceOrderService _serviceOrderService;
        public ObservableCollection<ServiceOrderForTechnicianDto> ServiceOrders { get; set; } = new();

        public ServiceOrderViewModel()
        {
            _serviceOrderService = new ServiceOrderService();
        }

        public async Task LoadServiceOrdersAsync(int technicianId)
        { 
            var data = await _serviceOrderService.GetServiceOrdersByTechnician(technicianId);
            ServiceOrders.Clear();
            
            foreach (var order in data)
            {
                ServiceOrders.Add(order);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
