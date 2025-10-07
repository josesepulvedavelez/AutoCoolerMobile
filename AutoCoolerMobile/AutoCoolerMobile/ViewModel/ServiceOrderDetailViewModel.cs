using AutoCoolerMobile.Model;
using AutoCoolerMobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoolerMobile.ViewModel
{
    public class ServiceOrderDetailViewModel : INotifyPropertyChanged
    {
        private readonly ServiceOrderService _serviceOrderService;
        private ServiceOrderForTechnicianDto _order;

        public ServiceOrderForTechnicianDto Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        public ServiceOrderDetailViewModel()
        {
            _serviceOrderService = new ServiceOrderService();
        }

        public async Task GetServiceOrderById(int serviceOrderId)
        {
            var result = await _serviceOrderService.GetServiceOrderById(serviceOrderId);
            if (result != null)
            {
                Order = result;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
