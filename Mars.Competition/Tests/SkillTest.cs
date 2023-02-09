global using AventStack.ExtentReports.Reporter;
global using AventStack.ExtentReports;
using Mars.Competition.Pages;
using Mars.Competition.Utilities;
using System.Reflection;
using System.Security.Cryptography;



namespace Mars.Competition.Tests
{
    [TestFixture]
    public class Tests 
    {

        CommonDriver driver;

         public static ExtentTest test;

        public static ExtentReports extent = new ExtentReports();

        //public CommonDriver Driver { get => driver; set => driver = value; }

        public Tests()
        {
            driver= new CommonDriver();
        }

        [SetUp]
        public void LoginSteps()
        {
            // extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\Mars.Competition\Mars.Competition\Mars.Competition" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);

            // Login page object initialization and definition
            LoginToPortal loginpageObj = new LoginToPortal();
            loginpageObj.CreateLogin();
          
        }

        [TestCase("Automation Tester","QA", "Selenium"), Order(1)]
        public void AddSkill(string p0,string p1,string p2)
        {
            test = null;
            test = extent.CreateTest("Test add skills");
            AddSkill Addskillobj = new AddSkill();
            Addskillobj.AddSkills(p0,p1,p2);
            test.Log(Status.Info, "Skills added in Manage listing");
        }

        [TestCase("Tester", "QA Intern", ".net"), Order(2)]
        public void EditSkill(string p0,string p1,string p2) 
        {

            test = null;
            test = extent.CreateTest("Test edit skills");
            EditSkill Editskillobj = new EditSkill();
            Editskillobj.EditSkills(p0,p1,p2);
            test.Log(Status.Info, "Skills edited in Manage listing");
        }

        [TestCase("Tester"), Order(3)]
        public void DeleteSkill(string deleteSkillTitle)
        {
            test = null;
            test = extent.CreateTest("Test Delete skills");
            DeleteSkill Deleteskillobj = new DeleteSkill();
            Deleteskillobj.DeleteSkills(deleteSkillTitle);
            test.Log(Status.Info, "Skills deleted in Manage listing");
        }

        [TearDown]
        public void quit ()
        {
            driver.shutDown();
            extent.Flush();
        }
    }
}