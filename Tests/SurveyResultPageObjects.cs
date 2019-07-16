using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System.IO;
using System.Reflection;
using System.Data;
using System.Transactions;

namespace Tests
{
    [TestClass]
    public class SurveyResultPageObjects
    {
        private static IWebDriver webDriver;

        [TestInitialize]
        public void TestInit()
        {
            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            webDriver.Navigate().GoToUrl(Helper.URL);
        }

        [TestMethod]
        public void elements_can_be_found_by_id()
        {
            IWebElement divOne = webDriver.FindElement(By.Id("YNP"));

            Assert.IsNotNull(divOne);
            
           
        }

        [TestMethod]
        public void single_elements_can_be_found_by_tag_name()
        {
            IWebElement div = webDriver.FindElement(By.TagName("div"));
            
            Assert.IsNotNull(div);
            
        }

        [TestMethod]
        public void pages_can_be_navigated_by_clicking_on_links()
        {
            // Link elements (i.e. <a> tags) can be found based on their text
            IWebElement detailLink = webDriver.FindElement(By.CssSelector("a[href='/home/parkdetail/YNP']")); // <a href="www.whatever.com"> THIS IS THE LINK TEXT</a>
            detailLink.Click();

            // The .Title returns the value of the page title
            IWebElement h2 = webDriver.FindElement(By.TagName("h2"));
            Assert.AreEqual("Park Information", h2.Text);
            IWebElement pic = webDriver.FindElement(By.Id("picsAndDetails"));
            Assert.IsNotNull(pic);
        }

        //        *  - By.className(String className) .
        //*  - By.cssSelector(String selector)
        //*  - By.id(String id)  #
        //*  - By.linkText(String linkText)
        //*  - By.name(String name) name = 'whatever'
        //* -By.tagName(String name) < tag >

        [TestMethod]
        public void forms_can_be_edited_and_submitted()
        {
            IWebElement surveyLink = webDriver.FindElement(By.LinkText("Survey")); // <a href="www.whatever.com"> THIS IS THE LINK TEXT</a>
            surveyLink.Click();


            // To interact with a <select> element, wrap the WebElement in a Select object
            SelectElement termField = new SelectElement(webDriver.FindElement(By.Id("parksDropdown")));
            termField.SelectByText("Everglades National Park");

            IWebElement interestField = webDriver.FindElement(By.Id("enterEmail"));
            interestField.SendKeys("foo@bar.net");

            SelectElement stateTermField = new SelectElement(webDriver.FindElement(By.Id("statesDropdown")));
            stateTermField.SelectByText("Maine");

            SelectElement activityTermField = new SelectElement(webDriver.FindElement(By.Id("activityLevels")));
            activityTermField.SelectByText("Active");

            IWebElement submitButton = webDriver.FindElement(By.Id("submitButton"));
            submitButton.Click();

            /* Elements without an id can be found using an xPath expression.
             * However, finding elements by xPath should generally be avoided 
             * as it is slow and makes for brittle tests. */
            IWebElement park = webDriver.FindElement(By.Id("ENP"));
            Assert.IsNotNull(park);


        }

        [TestCleanup]
        public void CleanUp()
        {
            webDriver.Close();
        }
    }
}
