using DataModel.Model;

namespace DataAccess.Services.Interface
{
    public interface IUser
    {
        bool Login(User user);

        int getBalanceamt();
        bool updateBalanceAmt(int balanceamt);
    }
}