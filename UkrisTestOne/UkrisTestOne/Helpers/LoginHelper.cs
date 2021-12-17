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
    public class LoginHelper: HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
            
        }

        public bool IsLoggedIn()
        {
            string text = driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a")).Text;
            return text != "Sign in";
        }

        public bool IsLoggedIn(string username)
        {
            string text = driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a")).Text;
            return text == username;
        }
        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }
                Logout();
            }
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(user.Username);
            driver.FindElement(By.Id("passwd")).Clear();
            driver.FindElement(By.Id("passwd")).SendKeys(user.Password);
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']/span")).Click();
        }
        
        public void Logout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => driver.FindElement(By.LinkText("Sign out"))).Click();
        }
    }
}