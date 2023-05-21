using System.Data.SqlClient;
using DataAccessLayer;
using InterfaceLayer;

namespace LogicLayer;

    public class User
{
    public int ID { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Password { get; set; }
    public string Mail { get; set; }
    public  int Role { get; set; }

    private IUser _iuser;

    public User(int userid, string username, string password, string mail, int role, IUser iuser)
    {
        ID = userid;
        UserName = username;
        Password = password;
        Mail = mail;
        Role = role;
        _iuser = iuser;
    }

    public User(string userName, string mail, string password, int role , IUser iuser)
    {
        UserName = userName;
        Mail = mail;
        Password = password;
        Role = role;
        _iuser = iuser;
    }

    public User(string mail, string password, IUser iuser)
    {
        Mail = mail;
        Password = password;
        _iuser = iuser;
    }

    /// <summary>
    /// 1. hashes the password using the mail a secret
    /// 2. saves the passwordhash, username and mail to the database
    /// </summary>
    /// <returns>
    /// return true when save was succesfull 
    /// return false when save failed
    /// </returns>
    public bool RegisterUser()
    {
        Hashing hashing = new Hashing();
        PasswordHash = hashing.HashPassword(Password, Mail);
        return _iuser.Save(ToDTO());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public UserDTO VerifyLogin()
    {
        Hashing hashing = new Hashing();
        UserContainer userContainer = new UserContainer(new UserDAL());
        UserDTO userDto = userContainer.GetUserByMail(Mail);
        if (userDto.Mail == null)
        {
            return userDto;
        }
        else
        {
            if (hashing.VerifyPassword(passwordHash: userDto.PasswordHash, password: Password, secret: Mail))
            {
                return userDto;
            }
            else
            {
                return new UserDTO();
            }
        }
    }

    public int validatePassword()
    {
        int passwordLength = Password.Length;
        if (passwordLength >= 5)
        {
            foreach (char var in Password)
            {
                if (var.ToString() == char.ToUpper(var).ToString())
                {
                    return 1;
                }

                return 2;
            }
        }

        return 3;
    }

    public UserDTO ToDTO()
    {
        UserDTO dto = new UserDTO();
        dto.UserName = UserName;
        dto.PasswordHash = PasswordHash;
        dto.Mail = Mail;
        dto.Role = Role;
        return dto;
    }
}