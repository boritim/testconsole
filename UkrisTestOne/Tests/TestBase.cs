using System;
using System.Linq;
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
    public class TestBase
    {
        protected ApplicationManager app;
        private static Random random = new Random();

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
        }

        public static string GetRandomString(int number)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, number)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomNumberString(int number)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, number)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GetRandomNumber()
        {
            return random.Next(1, 50);
        }
    }
}