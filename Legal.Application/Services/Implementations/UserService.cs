using Legal.Application.DTOs.Users;
using Legal.Application.Security;
using Legal.Application.Services.Interfaces;
using Legal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Legal.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Ctor
        private LowDbContext _context;
        public UserService(LowDbContext context)
        {
            _context = context;
        }


        #endregion
        #region Login Methods
        public async Task<UserLoginedDto> GetUserForLogin(string username, string password)
        {
            string pass = HashEncode.GetHashCode(HashEncode.GetHashCode(password));
            var user = await _context.TbUsers.SingleOrDefaultAsync(u => u.Username == username
            && u.Password == pass);
            UserLoginedDto dto = new UserLoginedDto();
            if (user != null)
            {
                dto.Id = user.Id;
                dto.Fullname = user.FullName;
                dto.Mobile = user.Mobile;
            }
            return dto;
        }

        public async Task<UserLoginedDto> GetUserFullnameById(long id)
        {
            var user = await _context.TbUsers.SingleAsync(u => u.Id == id);
            UserLoginedDto dto = new UserLoginedDto()
            {
                Id = user.Id,
                Fullname = user.FullName,
                Mobile = user.Mobile
            };
            return dto;
        }
        #endregion
        #region List User & Role
        public async Task<List<UsersListDto>> GetUsers(long? userId)
        {
            if (userId != null)
                userId = 1;

            var loginUser = await _context.TbUsers.SingleAsync(u => u.Id == userId);
            var roleLogin = await _context.TbUserRoles.SingleAsync(u => u.UserId == userId);
            var develeperRole = await _context.TbRoles.SingleAsync(u => u.HasDeveloperAccess);
            var headRoles = await _context.TbRoles.Where(r => r.IsHeadquarters)
                .Select(r => r.Id).ToListAsync();
            var regionRoles = await _context.TbRoles.Where(r => r.HasRegionAccess == true)
                .Select(r => r.Id).ToListAsync();
            var ostanRoles = await _context.TbRoles.Where(r => r.HasOstanAccess)
                .Select(r => r.Id).ToListAsync();

            List<UsersListDto> list = new List<UsersListDto>();
            var users = await _context.TbUsers.ToListAsync();

            if (roleLogin.Id == develeperRole.Id || headRoles.Contains(roleLogin.Id))
            {
                users = users.OrderBy(u => u.Id).ToList();
            }
            else if (regionRoles.Contains(roleLogin.Id))
            {
                users = users.Where(u => u.RegionId == loginUser.RegionId).ToList();
            }
            else if (ostanRoles.Contains(roleLogin.Id))
            {
                users = users.Where(u => u.OstanId == loginUser.OstanId).ToList();
            }
            else
            {
                users = users.Where(u => u.ShahrestanId == loginUser.ShahrestanId).ToList();
            }
            foreach (var user in users)
            {
                var userRole = await _context.TbUserRoles.SingleAsync(u => u.UserId == user.Id);
                var role = await _context.TbRoles.SingleAsync(r => r.Id == userRole.RoleId);
                var ostan = await _context.TbOstans.SingleOrDefaultAsync(r => r.Id == user.OstanId);
                var region = await _context.TbRegions.SingleOrDefaultAsync(r => r.Id == user.RegionId);
                var shahr = await _context.TbShahrestans.
                     SingleOrDefaultAsync(r => r.Id == user.ShahrestanId);
                UsersListDto dto = new UsersListDto()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Mobile = user.Mobile,
                    OstanTitle = ostan?.Title,
                    RegionTitle = region?.Name + " " + region?.Last,
                    ShahrestanTitle = shahr?.Title,
                    RoleTitle = role.Title,
                    Username = user.Username
                };
                list.Add(dto);
            }

            return list;
        }
        public async Task<List<RolesListDto>> GetRoles()
        {
            var roles = await _context.TbRoles.ToListAsync();
            List<RolesListDto> list = new List<RolesListDto>();
            foreach (var role in roles)
            {
                RolesListDto dto = new RolesListDto()
                {
                    Id = Convert.ToInt32(role.Id),
                    Title = role.Title
                };
                list.Add(dto);
            }
            return list;
        }
        #endregion
        #region Create User
        public async Task<bool> CreateUser(CreateUserDto create, long userId)
        {
            var mobile = await _context.TbUsers.AnyAsync(u => u.Mobile == create.Mobile);
            if (mobile)
                return false;
            var username = await _context.TbUsers.AnyAsync(u => u.Username == create.Username);
            if (username)
                return false;
            string pass = HashEncode.GetHashCode(HashEncode.GetHashCode(create.Password));
            TbUser user = new TbUser()
            {
                FullName = create.FullName,
                Password = pass,
                Username = create.Username,
                RegionId = create.RegionId,
                Mobile = create.Mobile,
                CreateBy = userId,
                CreateDate = DateTime.Now,
                OstanId = create.OstanId,
                ShahrestanId = create.ShahrestanId
            };
            await _context.TbUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            TbUserRole userRole = new TbUserRole()
            {
                UserId = user.Id,
                RoleId = create.RoleId,
                CreateDate = DateTime.Now,
                CreateBy = userId
            };
            await _context.TbUserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CanAddUser(long userId)
        {
            var admin = await _context.TbRoles.SingleAsync(r => r.HasDeveloperAccess);
            var userRole = await _context.TbUserRoles.SingleAsync(u => u.UserId == userId);
            if (admin.Id == userRole.RoleId)
                return true;
            return false;
        }


        #endregion
        #region Edit User
        public async Task<UserDto> GetUserById(long id)
        {
            var users = await _context.TbUsers.SingleAsync(u => u.Id == id);
            UserDto user = new UserDto()
            {
                Id = users.Id,
                FullName = users.FullName,
                Username = users.Username,
                Mobile = users.Mobile,
                OstanId = users.OstanId,
                RegionId = users.RegionId,
                ShahrestanId = users.ShahrestanId
            };

            var role = await _context.TbUserRoles.SingleAsync(e => e.UserId == id);
            user.RoleId = role.RoleId;
            return user;
        }

        public async Task<bool> CanEditUser(long userId)
        {
            var admin = await _context.TbRoles.SingleAsync(r => r.HasDeveloperAccess);
            var userRole = await _context.TbUserRoles.SingleAsync(u => u.UserId == userId);
            if (admin.Id == userRole.RoleId)
                return true;
            return false;
        }

        public async Task<bool> UpdateUser(UserDto edit, long userId)
        {
            try
            {
                var user = await _context.TbUsers.SingleAsync(u => u.Id == edit.Id);
                user.Mobile = edit.Mobile;
                user.FullName = edit.FullName;
                user.Username = edit.Username;
                user.RegionId = edit.RegionId;
                user.OstanId = edit.OstanId;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = userId;
                user.ShahrestanId = edit.ShahrestanId;
                _context.TbUsers.Update(user);
                var userRole = await _context.TbUserRoles.SingleAsync(r => r.UserId == user.Id);
                userRole.RoleId = edit.RoleId;
                userRole.ModifiedDate = DateTime.Now;
                userRole.ModifiedBy = userId;
                _context.TbUserRoles.Update(userRole);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
         
        }

        public async Task ChangePassword(ChangePasswordDto changePassword)
        {

            var user = await _context.TbUsers.SingleAsync(y => y.Id == changePassword.Id);
            string pass = HashEncode.GetHashCode(HashEncode.GetHashCode(changePassword.Password));
            user.Password = pass;
            _context.TbUsers.Update(user);
            await _context.SaveChangesAsync();
        }


        #endregion

    }
}
