using DataAccess.Services.Interface;
using DataModel.Model;
using TrackYourExpenses.Model.Abstraction;

namespace DataAccess.Services
{
    public class UserService : UserBase, IUser
    {
        private List<User> _users;

        public const string SeedUsername = "sams";
        public const string SeedPassword = "sams";

        public UserService()
        {
            _users = LoadUsers();
            if (!_users.Any())
            {
                _users.Add(new User { UserName = SeedUsername, Password = SeedPassword });
                SaveUsers(_users);
            }

        }
        public bool Login(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return false; // Invalid input.
            }

            // Check if the username and password match any user in the list.
            return _users.Any(u => u.UserName == user.UserName && u.Password == user.Password);
        }

        public int getBalanceamt()
        {
            User user = _users.FirstOrDefault();
            return user.BalanceAmt;
        }

        public bool updateBalanceAmt(int balanceamt)
        {
            if (_users == null)
            {
                throw new Exception("user not found.");
            }
            User user = _users.FirstOrDefault();
            user.BalanceAmt = balanceamt;
            SaveUsers(_users);
            return true;

        }

    }
}
