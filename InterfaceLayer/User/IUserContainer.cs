namespace InterfaceLayer;

public interface IUserContainer
{ 
    UserDTO GetUserByMail(string mail);
}