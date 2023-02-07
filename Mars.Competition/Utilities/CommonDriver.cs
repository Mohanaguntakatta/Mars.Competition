using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Competition.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        
        public void shutDown()
        {
            driver.Quit();
        }

    }

}
