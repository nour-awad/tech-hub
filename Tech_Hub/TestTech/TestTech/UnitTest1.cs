using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestTech
{
	public class UnitTest1
	{
		[Fact]

		public void ProductButton()
		{
			string URL = "http://localhost:8080/";
			ChromeDriver driver = new ChromeDriver();

			driver.Navigate().GoToUrl(URL);

			IWebElement PrductName = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div/div[1]/div/div/div[8]/div[2]/h3/a"));
			string Name = PrductName.Text;
			PrductName.Click();

			IWebElement ProductTitle = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/div/h2"));
			Assert.Equal(Name, ProductTitle.Text);

			driver.Close();


		}
			[Fact]
		public void Checkout()
		{
			string URL = "http://localhost:8080/";
			ChromeDriver driver = new ChromeDriver();

			driver.Navigate().GoToUrl(URL);


			IWebElement cart = driver.FindElement(By.XPath("/html/body/header/div/div/div/div[3]/div/div[2]/a/i"));
			cart.Click();

			IWebElement Checkout = driver.FindElement(By.XPath("/html/body/header/div/div/div/div[3]/div/div[2]/div/div[3]/a[2]"));
			string Name = Checkout.Text.ToUpper();
			Checkout.Click();

			IWebElement CHECKOUT = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/h3"));
			Assert.Equal(Name, CHECKOUT.Text);

			driver.Close();

		}
	}
}