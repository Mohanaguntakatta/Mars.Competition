using Mars.Competition.Pages;
using Mars.Competition.Utilities;

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

        [Test, Order(1)]
        public void AddSkill()
        {
            AddSkill Addskillobj = new AddSkill();
            Addskillobj.AddSkills();
        }

        [Test, Order(2)]
        public void EditSkill() 
        {
            EditSkill Editskillobj = new EditSkill();
            Editskillobj.EditSkills();
        }
        [Test, Order(3)]
        public void DeleteSkill()
        {
            DeleteSkill Deleteskillobj = new DeleteSkill();
            Deleteskillobj.DeleteSkills();
        }

        [TearDown]
        public void quit ()
        {
            driver.shutDown();
        }
    }
}