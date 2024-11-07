using CalcApp.Server.Models;
using CalcApp.Server.Repositories;
using Microsoft.AspNetCore.Identity;

namespace CalcApp.Server.Services
{
    public class UserService(UserRepository userRepository, JWTService jwtService)
    {
        //регистрация пользователя
        public void Register(string name, string login, string password)
        {
            var userModel = new UserModel
            {
                Name = name,
                Login = login
            };
            var passwordHash = new PasswordHasher<UserModel>().HashPassword(userModel, password);
            userModel.Password = passwordHash;
        }
        //аутентификация пользователя
        public string Login(string username, string password)
        {
            var account = userRepository.GetByUsername(username);
            var result = new PasswordHasher<UserModel>().VerifyHashedPassword(account, account.Password, password);
            if (result == PasswordVerificationResult.Success)
            {
                return jwtService.GenerateToken(account);
            }
            else
            {
                throw new Exception("Unathorized");
            }
        }
    }
}
