using NUnit.Framework;

namespace ItisDeBestTests
{
    [TestFixture]
    public class LoginTests: TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Login(user);
            app.Auth.Logout();
        }

        [Test]
        public void LoginWithInvalidData()
        {
            AccountData user = new AccountData("test.@gmail.com", "lolitsinvaliddata");
            app.Auth.Login(user);
        }
    }
}