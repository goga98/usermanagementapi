using Microsoft.AspNetCore.Identity;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using UserManagement.Service.IServices;
using UserManagement.Shared.Models.UserDtos;

namespace UserManagement.Service
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task InsertUser(InsertDto model)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = new User
                {
                    Username = model.User.Username,
                    Password = model.User.Password
                };
                await _unitOfWork.UserRepository.InsertAsync(user);
                await _unitOfWork.SaveChangesAsync();

                var userRole = new UserRole
                {
                    Role=model.UserRoles.Role,
                    User = user
                };
                await _unitOfWork.UserRoleRepository.InsertAsync(userRole);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task UpdateUser(UpdateUser model)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var userProfile = _unitOfWork.UserRoleRepository.GetUserWithProfile(model.UserRoleId).Result;
                userProfile!.Role = model.UserRoles!.Role;

                var user = await _unitOfWork.UserRepository.GetByIdAsync(userProfile.User!.UserId);
                user.Username = model.User.Username;

                _unitOfWork.UserRoleRepository.Update(userProfile);
                _unitOfWork.UserRepository.Update(user);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public bool IsExist(LoginDto model)
        {
            return _unitOfWork.UserRepository.GetByCondition(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault() != null ? true : false;
        }
        public async Task InitializeRoles(UserManager<UserDto> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminRole = "Admin";
            string clientRole = "Client";

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (!await roleManager.RoleExistsAsync(clientRole))
            {
                await roleManager.CreateAsync(new IdentityRole(clientRole));
            }
        }
    }
}
