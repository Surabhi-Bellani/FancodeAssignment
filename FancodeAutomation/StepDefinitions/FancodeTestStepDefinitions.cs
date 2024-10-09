using NUnit.Framework;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class FancodeTestStepDefinitions
{
    private readonly IUserService _userService;
    private readonly IApiClient apiClient;
    private List<User> _users;
    private User _currentUser;

    public FancodeTestStepDefinitions()
    {
         apiClient = new ApiClient();
        _userService = new UserService(apiClient);
    }

    [Given(@"User belongs to FanCode city")]
    public void GivenUserBelongsToFanCodeCity()
    {
        _users = _userService.GetUsers();
    }


    [When(@"user fetches their todo tasks")]
    public void WhenUserFetchesTheirTodoTasks()
    {
        foreach (var user in _users)
        {
            if (_userService.IsUserFromFancodeCity(user))
            {
                _currentUser = user;
                _currentUser.Todos = apiClient.GetTodos(user.Id);
                break;
            }
        }
    }


    [Then(@"User Completed task percentage should be greater than (.*)%")]
    public void ThenUserCompletedTaskPercentageShouldBeGreaterThan(int percentage)
    {
        var completedPercentage = _userService.GetCompletedTaskPercentage(_currentUser);
        Assert.IsTrue(completedPercentage > percentage, $"User {_currentUser.Name} has less than {percentage}% tasks completed.");
    }
}
