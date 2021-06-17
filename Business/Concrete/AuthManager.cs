//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Business.Abstract;
//using Core.Security;
//using Entity.Concrete;
//using Entity.DTOs;

//namespace Business.Concrete
//{
//    public class AuthManager : IAuthService
//    {
//        IAdminService _adminService;

//        public AuthManager(IAdminService adminService)
//        {
//            _adminService = adminService;
//        }

//        public bool Login(LoginDto loginDto)
//        {
//            using (var hmac = new System.Security.Cryptography.HMACSHA512())
//            {
//                var userNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.AdminUserName));
//                var user = _adminService.GetAll();
//                foreach (var item in user)
//                {
//                    if (HashingHelper.VerifyPasswordHash(loginDto.AdminUserName, loginDto.AdminPassword, item.AdminUserName, item.AdminPasswordHash, item.AdminPasswordSalt))
//                    {
//                        return true;
//                    }
//                }
//                return false;
//            }
//        }

//        public void Register(string userName, string password)
//        {
//            byte[] userNameHash, passwordHash, passwordSalt;
//            HashingHelper.CreatePasswordHash(userName, password, out userNameHash, out passwordHash, out passwordSalt);
//            var admin = new Admin
//            {
//                AdminUserName = userNameHash,
//                AdminPasswordHash = passwordHash,
//                AdminPasswordSalt = passwordSalt,
//                AdminRole = "A"
//            };
//            _adminService.Add(admin);
//        }
//    }
//}

