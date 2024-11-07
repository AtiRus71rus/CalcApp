
using CalcApp.Server.Models;

namespace CalcApp.Server.Repositories
{
    public class UserRepository
    {
        private static IDictionary<string, UserModel> accounts = new Dictionary<string, UserModel>();
        public void AddUser(UserModel model)
        {
            accounts[model.Name] = model;
        }
        public UserModel? GetByUsername(string name)
        {
            return accounts.TryGetValue(name, out var account) ? account : throw new Exception("There's no account with this login");
        }
    }
}
