using System.Collections.Generic;

public interface IUserService
{
    List<User> GetUsers();
    bool IsUserFromFancodeCity(User user);
    double GetCompletedTaskPercentage(User user);

}


