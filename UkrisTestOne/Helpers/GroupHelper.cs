using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ItisDeBestTests
{
    public class GroupHelper: HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            :base(manager)
        {
            
        }
        public void AddNewAddress(AddressData addressData)
        {
            driver.FindElement(By.XPath("//div[@id='center_column']/div[2]/a/span")).Click();
            driver.FindElement(By.Id("firstname")).Click();
            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys(addressData.FirstName);
            driver.FindElement(By.Id("lastname")).Click();
            driver.FindElement(By.Id("lastname")).Clear();
            driver.FindElement(By.Id("lastname")).SendKeys(addressData.LastName);
            driver.FindElement(By.Id("address1")).Click();
            driver.FindElement(By.Id("address1")).Clear();
            driver.FindElement(By.Id("address1")).SendKeys(addressData.Address);
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys(addressData.City);
            driver.FindElement(By.Id("id_state")).Click();
            driver.FindElement(By.Id("phone")).Click();
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys(addressData.MobileNumber);
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByValue($"{ addressData.State }");
            driver.FindElement(By.Id("postcode")).Click();
            driver.FindElement(By.Id("postcode")).Clear();
            driver.FindElement(By.Id("postcode")).SendKeys(addressData.PostCode);
            driver.FindElement(By.Id("other")).Click();
            driver.FindElement(By.Id("alias")).Click();
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys(addressData.Title);
            driver.FindElement(By.XPath("//button[@id='submitAddress']/span")).Click();
        }

        public void UpdateAddress(AddressData updateAddress)
        {
            driver.FindElement(By.XPath("//div[@id='center_column']/div/div/div[2]/ul/li[9]/a/span")).Click();
            driver.FindElement(By.Id("address1")).Click();
            driver.FindElement(By.Id("address1")).Clear();
            driver.FindElement(By.Id("address1")).SendKeys(updateAddress.Address);
            driver.FindElement(By.XPath("//div[@id='center_column']/div")).Click();
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys(updateAddress.City);
            driver.FindElement(By.Id("id_state")).Click();
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByValue($"{updateAddress.State}");
            driver.FindElement(By.XPath("//div[@id='center_column']/div")).Click();
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys(updateAddress.MobileNumber);
            driver.FindElement(By.XPath("//button[@id='submitAddress']/span")).Click();
        }

        public AddressData GetCreatedGroupDate()
        {
            string groupName = driver.FindElement(By.Id("alias")).GetAttribute("value");
            string firstName = driver.FindElement(By.Id("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Id("lastname")).GetAttribute("value");
            string company = driver.FindElement(By.Id("company")).GetAttribute("value");
            string address = driver.FindElement(By.Id("address1")).GetAttribute("value");
            string city = driver.FindElement(By.Id("city")).GetAttribute("value");
            string state = driver.FindElement(By.XPath("//*[@id='id_state']")).GetAttribute("value");
            string postCode = driver.FindElement(By.Id("postcode")).GetAttribute("value");
            string country = driver.FindElement(By.XPath("//*[@id='uniform-id_country']/span")).Text;
            string phoneNumber = driver.FindElement(By.Id("phone")).GetAttribute("value");
            if (phoneNumber.Length == 0)
            {
                phoneNumber = driver.FindElement(By.Id("phone_mobile")).GetAttribute("value");
            }

            return new AddressData()
            {
                FirstName = firstName, LastName = lastName, Address = address, City = city,
                State = Convert.ToInt32(state), PostCode = postCode, Country = country, MobileNumber = phoneNumber,
                Title = groupName
            };
        }

        public void SelectLastCreatedGroup()
        {
            var js = (IJavaScriptExecutor) driver;
            js.ExecuteScript("scroll(0, 400)");
            int index = 0;
            int size = driver.FindElements(By.ClassName("address")).Count;
            index = size;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => driver.FindElement(By.XPath($"//*[@id='center_column']/div[1]/div/div[{index}]/ul/li[9]/a[1]"))).Click();
        }

        public void DeleteCreatedGroup()
        {
            driver.FindElement(By.XPath("//div[@id='center_column']/div/div/div[2]/ul/li[9]/a[2]/span")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Are you sure[\\s\\S]$"));
        }
        
    }
}