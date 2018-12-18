using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace WeatherAppAutomation
{
    public class TestBase
    {
        protected IWebDriver driver = new ChromeDriver();

        //Finds elements using XPath - used XPath finder Google Chrome extension to get path
        public void FindElementByXPath(string xPath)
        {
            try
            {
                var Btn = driver.FindElement(By.XPath(xPath));
                Btn.Click();
            }
            catch
            {
                Assert.Fail();
            }
        }

        //Finds the field, clears it and enters the text provided
        public void EnterText(string field, string text)
        {
            try
            {
                //Find and Update field
                var editField = driver.FindElement(By.Id(field));
                editField.Clear();

                //Check to make sure field has been cleared
                string textValue = editField.GetAttribute("value");
                Assert.AreEqual("", textValue);

                editField.SendKeys(text);
            }
            catch
            {
            }
        }

        //Finds the field and presses enter
        public void PressEnter(string field)
        {
            try
            {
                //Find field
                var editField = driver.FindElement(By.Id(field));

                editField.SendKeys(Keys.Return);
            }
            catch
            {
            }
        }

        //Closes the driver
        public void CloseDriver()
        {
            driver.Quit();
        }






        ////Logs user in to BadgerNet config using credentials provided
        //public void LogIn (string URL, string username, string password)
        //{
        //    //Writing to log file
        //    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() +": Logging in" + Environment.NewLine);
            
        //    // Go to the home page
        //    driver.Navigate().GoToUrl(URL);

        //    //Switch to iFrame to access Elements inside it
        //    driver.SwitchTo().Frame(driver.FindElement(By.Id("frameGateway")));

        //    //Find Elements
        //    var usrField = driver.FindElement(By.Id("UserName"));
        //    var pwdField = driver.FindElement(By.Id("password"));
        //    var logInBtn = driver.FindElement(By.Id("submit"));

        //    //Enter credentials and log in
        //    usrField.SendKeys(username);
        //    pwdField.SendKeys(password);
        //    logInBtn.Click();

        //    //Writing to log file
        //    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Logged in" + Environment.NewLine);
        //}

        ////Finds elements using ID - tries every second for 5 seconds
        //public void FindElementById (string idElement)
        //{
        //    //Writing to log file
        //    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Checking for element by ID - " + idElement + Environment.NewLine);
            
        //    //Check every second for 5 seconds if page has loaded
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Thread.Sleep(1000);

        //        try
        //        {
        //            var Btn = driver.FindElement(By.Id(idElement));
        //            Btn.Click();
        //            //Writing to log file
        //            File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element found by ID - " + idElement + Environment.NewLine);

        //            if (i == 3)
        //            {
        //                //Writing to log file
        //                File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Today.ToString() + ": Failed to find element by ID - " + idElement + Environment.NewLine);
        //                Assert.Fail();
        //            }
        //            break;
        //        }
        //        catch
        //        {
        //            Assert.Fail();
        //        }
        //        break;
        //    }
        //}

        ////Finds elements of type 'Span' - tries every second for 5 seconds
        //public void FindElementBySpan (string spanElement)
        //{
        //    //Writing to log file
        //    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Checking for element of type Span - " + spanElement + Environment.NewLine);

        //    //Check every second for 5 seconds if page has loaded
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Thread.Sleep(1000);

        //        try
        //        {

        //            //Looks through all span elements for relevant text
        //            var allSpanElements = driver.FindElements(By.TagName("data-test"));
        //            int count = 0;

        //            foreach (var element in allSpanElements)
        //            {
        //                count++;

        //                if (element.Text == spanElement)
        //                {
        //                    element.Click();

        //                    //Writing to log file
        //                    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element of type Span found - " + spanElement + Environment.NewLine);
        //                    break;
        //                }

        //                if (count == allSpanElements.Count)
        //                {
        //                    //Writing to log file
        //                    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element of type Span not found - " + spanElement + Environment.NewLine);
        //                    Assert.Fail();
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            Assert.Fail();
        //        }
        //        break;
        //    }
        //}

        ////Finds elements of type button - tries every second for 5 seconds
        //public void FindElementByButton (string buttonElement)
        //{
        //    //Writing to log file
        //    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Checking for element of type Button - " + buttonElement + Environment.NewLine);

        //    //Check every second for 5 seconds if page has loaded
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Thread.Sleep(1000);
        //        try
        //        {
        //            //Looks through all button elements for relevant text
        //            var allButtonElements = driver.FindElements(By.TagName("button"));

        //            int count = 0;

        //            foreach (var element in allButtonElements)
        //            {
        //                count++;

        //                if (element.Text == buttonElement)
        //                {
        //                    element.Click();

        //                    //Writing to log file
        //                    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element of type Button found - " + buttonElement + Environment.NewLine);
        //                    break;
        //                }

        //                if (count == allButtonElements.Count)
        //                {
        //                    //Writing to log file
        //                    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element of type Button not found - " + buttonElement + Environment.NewLine);
        //                    Assert.Fail();
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            Assert.Fail();
        //        }
        //        break;
        //    }
        //}

        ////Finds elements of type 'Div' - tries every second for 5 seconds
        //public void FindElementByDiv(string divElement)
        //{
        //    //Writing to log file
        //    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Checking for element of type Div - " + divElement + Environment.NewLine);

        //    //Check every second for 5 seconds if page has loaded
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Thread.Sleep(1000);

        //        try
        //        {
        //            //Looks through all div elements for relevant text
        //            var allDivElements = driver.FindElements(By.TagName("div"));
        //            foreach (var element in allDivElements)
        //            {
        //                int count = 0;
        //                count++;

        //                if (element.Text == divElement)
        //                {
        //                    element.Click();

        //                    //Writing to log file
        //                    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element of type Div found - " + divElement + Environment.NewLine);
        //                    break;
        //                }

        //                if (count == allDivElements.Count)
        //                {
        //                    //Writing to log file
        //                    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element of type Div not found - " + divElement + Environment.NewLine);
        //                    Assert.Fail();
        //                }
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        break;
        //    }
        //}


        ////Finds elements of type 'Span' that contain the text provided - tries every second for 5 seconds
        //public void FindElementContainsBySpan (string spanElement)
        //{
        //    //Writing to log file
        //    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Checking for element of type Span - " + spanElement + Environment.NewLine);

        //    //Check every second for 5 seconds if page has loaded
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Thread.Sleep(1000);

        //        try
        //        {
        //            //Looks through all span elements for relevant text
        //            var allSpanElements = driver.FindElements(By.TagName("span"));
        //            foreach (var element in allSpanElements)
        //            {
        //                int count = 0;

        //                if (element.Text.Contains(spanElement))
        //                {
        //                    element.Click();
                            
        //                    //Writing to log file
        //                    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element of type Span found using contains method - " + spanElement + Environment.NewLine);
        //                    break;
        //                }

        //                //if (count == allSpanElements.Count)
        //                //{
        //                //    //Writing to log file
        //                //    File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": Element of type Span not found using contains method - " + spanElement + Environment.NewLine);
        //                //    Assert.Fail();
        //                //}
        //            }
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}

        ////Finds the field and compares the value provided against what is in it
        //public void VerifyText (string field, string expectedText)
        //{
        //    //Check every second for 5 seconds if page has loaded
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Thread.Sleep(1000);

        //        IWebElement textfield = driver.FindElement(By.Id(field));
        //        string textValue = textfield.GetAttribute("value");

        //        if (textValue != "")
        //        {
        //            //Checks the contents of the fields against what is expected
        //            Assert.AreEqual(expectedText, textValue);

        //            //Writing to log file
        //            File.AppendAllText(@"C:\Users\Amir.Iftikhar\Desktop\Small Programs\NeuroAutomation\logging.txt", DateTime.Now.ToString() + ": " + field + " field contains the expected text - " + expectedText + Environment.NewLine);
        //            break;
        //        }
        //    }
        //}
    }
}
