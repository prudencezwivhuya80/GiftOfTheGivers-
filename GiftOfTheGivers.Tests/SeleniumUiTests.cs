using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace GiftOfTheGivers.Tests
{
    [Trait("Category", "UI")]
    public class SeleniumUiTests
    {
        string baseUrl = "https://localhost:7297";

        IWebDriver StartBrowser()
        {
            var options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;

            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        [Fact]
        public void AnonymousDonation_ShowsThankYouPage()
        {
            using var driver = StartBrowser();
            driver.Navigate().GoToUrl(baseUrl + "/Home/Donate");

            driver.FindElement(By.Name("Amount")).SendKeys("150");
            driver.FindElement(By.CssSelector(".donate-page button[type='submit']")).Click();

            Assert.Contains("Thank you for your Donation", driver.PageSource);
            Assert.Contains("Anonymous", driver.PageSource);
        }

        [Fact]
        public void QuickAmountButton_FillsTheAmountBox()
        {
            using var driver = StartBrowser();
            driver.Navigate().GoToUrl(baseUrl + "/Home/Donate");

            driver.FindElement(By.XPath("//button[text()='R500']")).Click();

            string amount = driver.FindElement(By.Id("donationAmount")).GetAttribute("value");
            Assert.Equal("500", amount);
        }

        [Fact]
        public void Donation_EmptyAmount_StaysOnTheForm()
        {
            using var driver = StartBrowser();
            driver.Navigate().GoToUrl(baseUrl + "/Home/Donate");

            driver.FindElement(By.CssSelector(".donate-page button[type='submit']")).Click();

            Assert.Contains("Make a Donation", driver.PageSource);
        }

        [Fact]
        public void VolunteerSubmitButton_IsLockedUntilTermsAreTicked()
        {
            using var driver = StartBrowser();
            driver.Navigate().GoToUrl(baseUrl + "/Home/Volunteer");

            IWebElement submit = driver.FindElement(By.Id("volunteerSubmit"));
            Assert.False(submit.Enabled);

            driver.FindElement(By.Id("agreeTerms")).Click();
            Assert.True(submit.Enabled);
        }

        [Fact]
        public void VolunteerRegistration_SubmitsTheForm()
        {
            using var driver = StartBrowser();
            driver.Navigate().GoToUrl(baseUrl + "/Home/Volunteer");

            driver.FindElement(By.Name("FullName")).SendKeys("Selenium Tester");
            driver.FindElement(By.Name("Skills")).SendKeys("First aid, driving");
            driver.FindElement(By.Name("Availability")).SendKeys("Weekends");
            driver.FindElement(By.Id("agreeTerms")).Click();
            driver.FindElement(By.Id("volunteerSubmit")).Click();

            // waits until the thank you heading shows up on the success page
            IWebElement heading = driver.FindElement(By.XPath("//h1[contains(text(), 'Thank you for volunteering')]"));
            Assert.Contains("Thank you for volunteering", heading.Text);
        }
    }
}