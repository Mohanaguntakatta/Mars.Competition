using ExcelDataReader;
using Mars.Competition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Competition.Pages
{
    public class AddSkill : CommonDriver
    {
        public bool skillAdded = false;

        private IExcelDataReader reader;
        private string filePath, Title, Description, TagBox;
        private FileStream fileStream;
        public DataSet dataSet;
        private DataTable dataTable;

        public static ExtentTest test;

        public static ExtentReports extent = new ExtentReports();
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

        public void ExcelReadDataForAddSkills()
        {
            //Path to the excel file 
            filePath = @"C:\Mars.Competition\Mars.Competition\Mars.Competition\Addskills.xlsx";
            //Encoding excel file stream
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Reading from excel file to add title, description and tagbox
            fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            //Getting the excel file as a dataset
            dataSet = reader.AsDataSet();
            //reader.DataSEt
            //Since only 1 sheet is in the excel file, index 0 is taken
            dataTable = dataSet.Tables[0];
            Title = dataTable.Rows[1][0].ToString();
            Description = dataTable.Rows[1][1].ToString();
            TagBox = dataTable.Rows[1][2].ToString();
        }
       
        public void AddSkills()
        {
            ExcelReadDataForAddSkills();

            var htmlreporter = new ExtentHtmlReporter(@"C:\Mars.Competition\Mars.Competition\Mars.Competition\Extent Reports\Add skill\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);

            //test = null;
            test = extent.CreateTest("Test add skills");

            //Identify share skill button and click
            shareSkillButton.Click();
            test.Log(Status.Pass, "Identified share skill button");

            //Identify title text box and enter valid input
            titleTextBox.SendKeys(Title);
            test.Log(Status.Pass, "Title added in skill page");

            // screnshot1 for add skills
            Screenshot screenshot1 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath1 = @"C:\Mars.Competition\Mars.Competition\Mars.Competition\Screenshot\screenshot1.png";
            screenshot1.SaveAsFile(screenshotPath1);


            //Identify description box and enter valid input         
            descriptionBox.SendKeys(Description);
            test.Log(Status.Pass, "Description added in skill page");

            //Identify select category dropdown and select            
            addCategory.SelectByText("Programming & Tech");
            test.Log(Status.Pass, "Skill selected in skill page");

            //Identify select sub category dropdown and select the sub category          
            subCategory.SelectByText("QA");
            test.Log(Status.Pass, "Sub category added in skill page");

            //Identify tag box and enter valid input          
            AddTagBox.SendKeys(TagBox);
            AddTagBox.SendKeys(Keys.Enter);
            test.Log(Status.Pass, "Tags added in skill page");

            //Identify service type and slect hourly basis service
            serviceType.Click();
            test.Log(Status.Pass, "Hours added in skill page");

            //Identify location type and select on site
            locationType.Click();
            test.Log(Status.Pass, "location added in skill page");

            //Identify available days and select Monday
            availableDays.Click();
            test.Log(Status.Pass, "Days added in skill page");

            //Identify start time and enter valid input
            startTime.SendKeys("0800A");
            test.Log(Status.Pass, "Start time added in skill page");
            // screnshot2 for add skills
            Screenshot screenshot2 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath2 = @"C:\Mars.Competition\Mars.Competition\Mars.Competition\Screenshot\screenshot2.png";
            screenshot2.SaveAsFile(screenshotPath2);
            
            //Identify end time and enter valid input
            endTime.SendKeys("0500P");
            test.Log(Status.Pass, "End time added in skill page");

            //Identify skill trade and select credit           
            skillTrade.Click();
            test.Log(Status.Pass, "Skill trade added in skill page");

            //Identify credit colum and enter valid input          
            creditColum.SendKeys("10");
            test.Log(Status.Pass, "Credit colum added in skill page");

            //Identify save button and save
            selectSave.Click();
            test.Log(Status.Pass, "All skills saved");

            skillAdded = true;
            // screnshot3 for add skills
            Screenshot screenshot3 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath3 = @"C:\Mars.Competition\Mars.Competition\Mars.Competition\Screenshot\screenshot3.png";
            screenshot3.SaveAsFile(screenshotPath3);
            extent.Flush();


        }

    }
}
