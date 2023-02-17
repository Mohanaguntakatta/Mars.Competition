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

            //Identify share skill button and click
            shareSkillButton.Click();

            //Identify title text box and enter valid input          
            titleTextBox.SendKeys(Title);         

            //Identify description box and enter valid input         
            descriptionBox.SendKeys(Description);

            //Identify select category dropdown and select            
            addCategory.SelectByText("Programming & Tech");

            //Identify select sub category dropdown and select the sub category          
            subCategory.SelectByText("QA");

            //Identify tag box and enter valid input          
            AddTagBox.SendKeys(TagBox);
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
