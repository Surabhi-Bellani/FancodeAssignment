using FanCodeSDETAssingment.TestData;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

public class UserService : IUserService
{
    private readonly IApiClient _apiClient;

    public UserService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public List<User> GetUsers()
    {
        return _apiClient.GetUsers();
    }

    public bool IsUserFromFancodeCity(User user)
    {
        double lat = user.Address.Geo.Lat;
        double lng = user.Address.Geo.Lng;
        return lat > TestData.LAT_MIN && lat < TestData.LAT_MAX && lng > TestData.LNG_MIN && lng < TestData.LNG_MAX;
    }

    public double GetCompletedTaskPercentage(User user)
    {
        int totalTasks = user.Todos.Count;
        int completedTasks = user.Todos.Count(todo => todo.Completed);
        double f = (double)completedTasks / totalTasks * 100;
        return (double)completedTasks / totalTasks * 100;
    }

}