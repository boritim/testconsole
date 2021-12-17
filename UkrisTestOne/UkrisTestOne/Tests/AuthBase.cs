using NUnit.Framework;

namespace ItisDeBestTests
{
    public class AuthBase: TestBase 
    {
        [SetUp]
        public void SetupTest()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Login(user);
        }
        
    }
}