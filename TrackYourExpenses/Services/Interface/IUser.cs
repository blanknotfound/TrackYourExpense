using TrackYourExpenses.Model;

namespace TrackYourExpenses.Services.Interface
{
    public interface IUser
    {
        bool Login(User user);
    }
}