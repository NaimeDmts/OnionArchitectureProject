using KatmanliSinavProject.BLL.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.Services.AppUserService
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterDTO registerDTO);
        Task<IdentityResult> DeleteUser(string Id);
        Task<AppUserDTO> GetById (string Id);
        Task<IdentityResult> UpdateUser(AppUserUpdateDTO updateDTO);
        Task<bool> Login(LoginDTO loginDTO);
        Task LogOut();
    }
}
