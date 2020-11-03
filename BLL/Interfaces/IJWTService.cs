using BLL;

namespace BLL.Interfaces
{
    public interface IJWTService
    {
        string Login(UserDTO user);
    }
}
