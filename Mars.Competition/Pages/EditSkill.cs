using ExcelDataReader;
using Mars.Competition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Competition.Pages
{
    public class EditSkill: CommonDriver
    {
        public bool editedSkills = false;

        private IExcelDataReader reader;
        private string filePath, EditTitle, EditDescription, EditTagBox;
        private FileStream fileStream;
        public DataSet dataSet;
        private DataTable dataTable;

        IWebElement manageListing => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
        IWebElement editToolTextBox => driver.FindElement(By.Name("title"));
        IWebElement editDescriptionBox => driver.FindElement(By.Name("description"));
        SelectElement editCategory => new SelectElement(driver.FindElement(By.Name("categoryId")));
        SelectElement editSubCategory => new SelectElement(driver.FindElement(By.Name("subcategoryId")));
        IWebElement editTagBox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        IWebElement editServiceType => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
        IWebElement editLocationType => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
        IWebElement editAvailableDays => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[1]/div/input"));
        IWebElement startTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[2]/input"));
        IWebElement endTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[3]/input"));
        IWebElement skillTrade => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
        IWebElement creditColum => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));

        public void ExcelReadDataForEditSkills()
        {
            //Path to the excel file 
            filePath = @"C:\Mars.Competition\Mars.Competition\Mars.Competition\Editskills.xlsx";
            //Encoding excel file stream
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Reading from excel file to edit title, description and tagbox
            fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            //Getting the excel file as a dataset
            dataSet = reader.AsDataSet();
            //reader.DataSEt
            //Since only 1 sheet is in the excel file, index 0 is taken
            dataTable = dataSet.Tables[0];
            EditTitle = dataTable.Rows[1][0].ToString();
            EditDescription = dataTable.Rows[1][1].ToString();
            EditTagBox = dataTable.Rows[1][2].ToString();
        }
        public void EditSkills()
        {
            ExcelReadDataForEditSkills();

            //Identify manage listings button and click          
            manageListing.Click();

            //Identify edit button and click
            editButton.Click();

            //Identify tool text box and edit input     
            editToolTextBox.Clear();
            editToolTextBox.SendKeys(EditTitle);

            //Identify description box and edit input         
            editDescriptionBox.Clear();
            editDescriptionBox.SendKeys(EditDescription);

            //Identify select category dropdown and select 
            editCategory.SelectByText("Programming & Tech");

            //Identify select sub category dropdown and select the sub category
            editSubCategory.SelectByText("Web & Mobile App");

            //Identify tag box and enter valid input           
            editTagBox.SendKeys(EditTagBox);
            editTagBox.SendKeys(Keys.Enter);

            //Identify service type and slect hourly one off service            
            editServiceType.Click();

            //Identify location type and select online             
            editLocationType.Click();                                  

            //Identify available days and select tuesday           
            editAvailableDays.Click();

            //Identify start time and edit input           
            startTime.SendKeys("0900A");

            //Identify end time and edit input
            endTime.SendKeys("0600P");

            //Identify skill trade and select Skill-exchange
            skillTrade.Click();

            //Identify credit colum and enter valid input
            creditColum.SendKeys("Selenum");

            //Identify save button and save
            saveButton.Click();

            editedSkills = true;

        }
    }
}
