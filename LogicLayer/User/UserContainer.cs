using InterfaceLayer;

namespace LogicLayer;
public class UserContainer
{
    private IUserContainer _IUserContainer;

    public UserContainer(IUserContainer iUserContainer)
    {
        _IUserContainer = iUserContainer;
    }

    public UserDTO GetUserByMail(string mail)
    {
        UserDTO dto = _IUserContainer.GetUserByMail(mail);
        return dto;
    }

    public UserDTO GetUserByID(string id)
    {
        UserDTO dto = _IUserContainer.GetUserByMail(id);
        return dto;     
    }
}