using Mars.Competition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Competition.Pages
{
    public class AddSkill : CommonDriver
    {
        public bool skillAdded = false;

        IWebElement shareSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
        IWebElement titleTextBox => driver.FindElement(By.Name("title"));
        IWebElement descriptionBox => driver.FindElement(By.Name("description"));
        SelectElement addCategory => new SelectElement(driver.FindElement(By.Name("categoryId")));
        SelectElement subCategory => new SelectElement(driver.FindElement(By.Name("subcategoryId")));
        IWebElement AddTagBox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        IWebElement serviceType => driver.FindElement(By.Name("serviceType"));
        IWebElement locationType => driver.FindElement(By.Name("locationType"));
        IWebElement availableDays => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));
        IWebElement startTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
        IWebElement endTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));
        IWebElement skillTrade => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
        IWebElement creditColum => driver.FindElement(By.Name("charge"));
        IWebElement selectSave => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));

        public void AddSkills(string p0,string p1,string p2)
        {
            //Identify share skill button and click
            shareSkillButton.Click();

            //Identify title text box and enter valid input          
            titleTextBox.SendKeys(p0);         

            //Identify description box and enter valid input         
            descriptionBox.SendKeys(p1);

            //Identify select category dropdown and select            
            addCategory.SelectByText("Programming & Tech");

            //Identify select sub category dropdown and select the sub category          
            subCategory.SelectByText("QA");

            //Identify tag box and enter valid input          
            AddTagBox.SendKeys(p2);
            AddTagBox.SendKeys(Keys.Enter);

            //Identify service type and slect hourly basis service
            serviceType.Click();

            //Identify location type and select on site
            locationType.Click();

            //Identify available days and select Monday
            availableDays.Click();

            //Identify start time and enter valid input
            startTime.SendKeys("0800A");

            //Identify end time and enter valid input
            endTime.SendKeys("0500P");

            //Identify skill trade and select credit           
            skillTrade.Click();

            //Identify credit colum and enter valid input          
            creditColum.SendKeys("10");

            //Identify save button and save
            selectSave.Click();

            skillAdded = true;
            
        }

    }
}
