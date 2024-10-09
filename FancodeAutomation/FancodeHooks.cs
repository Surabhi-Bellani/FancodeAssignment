using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow.Infrastructure;
namespace FancodeSDETAssignment
{
    [Binding]
    public class Hooks
    {
        private static ExtentReports _extent = new ExtentReports();
        private static ExtentTest _test;
        public static ExtentTest scenario;
        public static ExtentTest featureName;
        private static string ProjectFolder = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public static DateTime currentLocalTime = DateTime.Now.ToLocalTime();

        public static string ResetPathToRoot()
        {
            return ProjectFolder.Replace(@"bin\Debug", string.Empty);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // _extent = new ExtentReports();
            var htmlReporter = new ExtentSparkReporter(ResetPathToRoot() + "TestResults/" + $"ExecutionResults{currentLocalTime.Hour}{currentLocalTime.Minute}{currentLocalTime.Second}{currentLocalTime.Millisecond}.html");
            _extent.AttachReporter(htmlReporter);
        }


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }


        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {

            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext, ISpecFlowOutputHelper livingDocReportHelper)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            {
                if (scenarioContext.TestError == null)
                {
                    if (stepType == "When")
                    {
                       
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Log(Status.Pass, "Step Passed");
                        
                      
                    }
                    else if (stepType == "Then")
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Log(Status.Pass, "Step Passed");
                       
                    }
                    else if (stepType == "And")
                    {
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Log(Status.Pass, "Step Passed");
                    }
                }
                else if (scenarioContext.TestError != null)
                {
                    if (stepType == "Given")
                    {
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.StackTrace);
                       
                    }
                    else if (stepType == "When")
                    {
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.StackTrace);
                       
                    }
                    else if (stepType == "Then")
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.StackTrace);
                       
                    }
                    else if (stepType == "And")
                    {
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.StackTrace);
                       
                    }
                }
            }
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();
        }

    }
}
