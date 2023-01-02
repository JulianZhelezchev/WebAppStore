using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Models;

namespace WebAppStore.Service
{
    public interface IUserService
    {
        Task Create(UserDto userDto);
        Task<UserDto> GetByUsernameAndPassword(string username, string password);
        Task<bool> Exist(string username, string password);
    }
}
