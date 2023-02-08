using Mars.Competition.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Competition.Pages
{
    public class DeleteSkill : CommonDriver
    {
        IWebElement manageListing => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        IWebElement yesButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]/i"));

        public void DeleteSkills(string SkillTitleDelete) 
        {
            //Identify manage listings button and click
            manageListing.Click();

            //Identify delete button and click           
            deleteButton.Click();

            //select yes button            
            yesButton.Click();

        }
    }
}
