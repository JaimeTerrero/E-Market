using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Login(LoginViewModel loginVm)
        {
            User user = await _userRepository.LoginAsync(loginVm);

            if(user == null)
            {
                return null;
            }

            UserViewModel userVm = new();
            userVm.Id = user.Id;
            userVm.Name = user.Name;
            userVm.LastName = user.LastName;
            userVm.Email = user.Email;
            userVm.Phone = user.Phone;
            userVm.UserName = user.UserName;
            userVm.Password = user.Password;

            return userVm;
        }

        public async Task Update(SaveUserViewModel vm)
        {
            User user = new();
            user.Id = vm.Id;
            user.Name = vm.Name;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.Phone = vm.Phone;
            user.UserName = vm.UserName;
            user.Password = vm.Password;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            User user = new();
            user.Name = vm.Name;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.Phone = vm.Phone;
            user.UserName = vm.UserName;
            user.Password = vm.Password;

            user = await _userRepository.AddAsync(user);

            SaveUserViewModel userVm = new();
            userVm.Id = user.Id;
            userVm.Name = user.Name;
            userVm.LastName = user.LastName;
            userVm.Email = user.Email;
            userVm.Phone = user.Phone;
            userVm.UserName = user.UserName;
            userVm.Password = user.Password;

            return userVm;
        }

        public async Task Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
        }

        public async Task<SaveUserViewModel> GetByIdSaveViewModel(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            SaveUserViewModel vm = new();
            vm.Id = user.Id;
            vm.Name = user.Name;
            vm.LastName = user.LastName;
            vm.Email = user.Email;
            vm.Phone = user.Phone;
            vm.UserName = user.UserName;
            vm.Password = user.Password;

            return vm;
        }

        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var userList = await _userRepository.GetAllWithIncludeAsync(new List<string> {"Products" });

            return userList.Select(user => new UserViewModel
            {
                Name = user.Name,
                LastName = user.LastName,
                Id = user.Id,
                Email = user.Email,
                Phone = user.Phone,
                UserName = user.UserName,
                Password = user.Password
            }).ToList();
        }
    }
}
