using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumTestSirona
{
    [TestFixture]
    public class BaseTest
    {
        private AndroidDriver<AndroidElement> _driver;

        [SetUp]
        public void BeforeAll()
        {

            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName,"Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformVersion,"12");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            driverOption.AddAdditionalCapability("appPackage", "com.companyname.realestateapp");
            driverOption.AddAdditionalCapability("appActivity", "crc6487c6afeb28c0d00b.MainActivity");

            _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            _driver.LaunchApp();
        }

        [Test]
        public void InitTest()
        {
            //var a = _driver.FindElementByAccessibilityId("test");
            //var b = _driver.FindElementById("test");
            //var c = _driver.FindElementByClassName("test");
            //var d = _driver.FindElementByCssSelector("test");
            //var e = _driver.FindElementByName("test");

            var a = _driver.PageSource;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.CloseApp();
            _driver?.Dispose();
        }
    }
}
