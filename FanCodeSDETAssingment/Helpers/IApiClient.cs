using System.Collections.Generic;

public interface IApiClient
{
    List<User> GetUsers();
    List<Todo> GetTodos(int userId);
}