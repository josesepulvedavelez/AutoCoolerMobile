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
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;
        private UserLoginDto _user;

        public UserLoginDto User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public UserViewModel()
        {
            _userService = new UserService();
            User = new UserLoginDto();
        }

        public async Task Login(LoginRequest loginRequest)
        {
            User = await _userService.Login(loginRequest);

            if (User == null)
            {
                throw new Exception("Login failed. Please check your credentials.");
            }

            Session.UserCurrent = User;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
