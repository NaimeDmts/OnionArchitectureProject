using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.AppUserDTOs;
using KatmanliSinavProject.BLL.Utilities;
using KatmanliSinavProject.Core.Entities.Concretes;
using KatmanliSinavProject.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.BLL.Services.AppUserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            user.DeleteDate = DateTime.Now;
            user.Status = Status.Passive;
            IdentityResult result = await _userManager.UpdateAsync(user);
            return result;

        }

        public async Task<AppUserDTO> GetById(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                AppUserDTO appUserDTO = _mapper.Map<AppUserDTO>(user);
                return appUserDTO;
            }
            else
            {
                throw new Exception("Id ye ait user Bulunamamıştır");
            }
        }

        public async Task<bool> Login(LoginDTO loginDTO)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user != null)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, true, false);
                if (result.Succeeded)
                {
                    return true;
                }

                else
                {
                    throw new Exception("Hatalı Giriş");
                }
            }
            else
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO registerDTO)
        {
            var email = UserIslem.IsValidEmailFormat(registerDTO.Email);
            if (email)
            {
                var user = await _userManager.FindByEmailAsync(registerDTO.Email);
                if (user == null)
                {
                    var appUser = _mapper.Map<AppUser>(registerDTO);

                    appUser.FirstName = UserIslem.AdFromEmail(appUser.Email);
                    appUser.LastName = UserIslem.SoyadFromEmail(appUser.Email);
                    var result = await _userManager.CreateAsync(appUser, registerDTO.Password);
                    return result;
                }
                else
                {
                    throw new Exception("Bu Mail adresi bulunmaktadır. ");
                }

            }
            else
            {
                throw new Exception("Mail Formatı Yanlış");
            }
            
            
        }
        public async Task<IdentityResult> UpdateUser(AppUserUpdateDTO updateDTO)
        {
            AppUser user = await _userManager.FindByIdAsync(updateDTO.Id);

            if (user.FirstName != updateDTO.FirstName)
            {
                user.FirstName = updateDTO.FirstName;
            }

            if (user.LastName != updateDTO.LastName)
            {
                user.LastName = updateDTO.LastName;
            }

            if (user.Email != updateDTO.Email)
            {
                user.Email = updateDTO.Email;
            }

            if (user.PhoneNumber != updateDTO.PhoneNumber)
            {
                user.PhoneNumber = updateDTO.PhoneNumber;
            }
            user.ModifiedDate = DateTime.Now;
            user.Status = Status.Modified;
            IdentityResult result = await _userManager.UpdateAsync(user);

            return result;

        }
    }
}
