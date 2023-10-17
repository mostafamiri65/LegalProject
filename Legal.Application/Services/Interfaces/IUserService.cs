using Legal.Application.DTOs.Users;

namespace Legal.Application.Services.Interfaces
{
    public interface IUserService
    {
        #region List User Role
        Task<List<UsersListDto>> GetUsers(long? userId);
        Task<List<RolesListDto>> GetRoles();
        #endregion
        #region Login
        Task<UserLoginedDto> GetUserForLogin(string username, string password);
        Task<UserLoginedDto> GetUserFullnameById(long id);
        #endregion
        #region Create User
        Task<bool> CreateUser(CreateUserDto create, long userId);
        Task<bool> CanAddUser(long userId);
        #endregion
        #region EditUser
        Task<UserDto> GetUserById(long id);
        Task<bool> CanEditUser(long userId);
        Task<bool> UpdateUser(UserDto edit, long userId);
        Task ChangePassword(ChangePasswordDto changePassword);
        #endregion



    }
}
