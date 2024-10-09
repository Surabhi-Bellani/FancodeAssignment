using RestSharp;
using System.Collections.Generic;

public class ApiClient : IApiClient
{
    private readonly RestClient _client;

    public ApiClient()
    {
        var config = Config.LoadConfig();
        _client = new RestClient(config.Uri);
    }

    public List<User> GetUsers()
    {
        var request = new RestRequest("users", Method.Get);
        var response = _client.Execute<List<User>>(request);
        return response.Data;
    }

    public List<Todo> GetTodos(int userId)
    {
        var request = new RestRequest("todos", Method.Get);
        request.AddParameter("userId", userId);
        var response = _client.Execute<List<Todo>>(request);
        return response.Data;
    }



}
