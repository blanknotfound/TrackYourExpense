using DataModel.Model;

namespace DataAccess.Services.Interface
{
    public interface IUser
    {
        bool Login(User user);
    }
}