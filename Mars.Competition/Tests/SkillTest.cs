using Mars.Competition.Pages;
using Mars.Competition.Utilities;
using System.Reflection;
using System.Security.Cryptography;

namespace Mars.Competition.Tests
{
    public class Tests 
    {
        CommonDriver driver;

        public Tests()
        {
            driver= new CommonDriver();
        }

        [SetUp]
        public void LoginSteps()
        {
            // Login page object initialization and definition
            LoginToPortal loginpageObj = new LoginToPortal();
            loginpageObj.CreateLogin();
          
        }

        [TestCase("Automation Tester","QA", "Selenium"), Order(1)]
        public void AddSkill(string p0,string p1,string p2)
        {
            AddSkill Addskillobj = new AddSkill();
            Addskillobj.AddSkills(p0,p1,p2);
        }

        [TestCase("Tester", "QA Intern", ".net"), Order(2)]
        public void EditSkill(string p0,string p1,string p2) 
        {
            EditSkill Editskillobj = new EditSkill();
            Editskillobj.EditSkills(p0,p1,p2);
        }

        [TestCase("Tester"), Order(3)]
        public void DeleteSkill(string deleteSkillTitle)
        {
            DeleteSkill Deleteskillobj = new DeleteSkill();
            Deleteskillobj.DeleteSkills(deleteSkillTitle);
        }

        [TearDown]
        public void quit ()
        {
            driver.shutDown();
        }
    }
}