using ExcelDataReader;
using Mars.Competition.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Competition.Pages
{
    public class DeleteSkill : CommonDriver
    {   
        public bool deletedSkills = false;

        public static ExtentTest test;

        public static ExtentReports extent = new ExtentReports();

        IWebElement manageListing => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        IWebElement yesButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]/i"));

        public void DeleteSkills(string SkillTitleDelete) 
        {
            var htmlreporter = new ExtentHtmlReporter(@"C:\Mars.Competition\Mars.Competition\Mars.Competition\Extent Reports\Delete skill\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);

            test = extent.CreateTest("Test deleted skills");

            //Identify manage listings button and click
            manageListing.Click();
            test.Log(Status.Pass, "Clicked manage listing button");

            // screnshot7 for delete skills
            Screenshot screenshot7 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath7 = @"C:\Mars.Competition\Mars.Competition\Mars.Competition\Screenshot\screenshot7.png";
            screenshot7.SaveAsFile(screenshotPath7);
            extent.Flush();

            //Identify delete button and click           
            deleteButton.Click();
            test.Log(Status.Pass, "Clicked delete button");

            //select yes button            
            yesButton.Click();
            test.Log(Status.Pass, "Deleted skills in manage listing");

            deletedSkills = true;
            // screnshot1 for deleted skills
            Screenshot screenshot8 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath8 = @"C:\Mars.Competition\Mars.Competition\Mars.Competition\Screenshot\screenshot8.png";
            screenshot8.SaveAsFile(screenshotPath8);
            extent.Flush();
        }
    }
}
