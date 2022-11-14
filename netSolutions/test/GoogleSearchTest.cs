using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace test;

public class GoogleTestSearch
{
    [Test]
    public void SearchJourney()
    {
        IWebDriver driver = InitialiseWebDriver();

        OpenGoogleSearchPage(driver);
        EnterSearchText(driver, "Selenium");
        ClickSearchButton(driver);
        ViewSearchResultsPage(driver, "Selenium");

        driver.Quit();
    }

    private static IWebDriver InitialiseWebDriver()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        return driver;
    }

    private static void OpenGoogleSearchPage(IWebDriver driver)
    {
        driver.Navigate().GoToUrl("https://www.google.com");
        var title = driver.Title;
        Assert.That(title, Is.EqualTo("Google"));
    }

    private static void EnterSearchText(IWebDriver driver, string text)
    {
        var searchField = driver.FindElement(By.Name("q"));
        searchField.SendKeys(text);
    }

    private static void ClickSearchButton(IWebDriver driver)
    {
        var searchButton = driver.FindElement(By.Name("btnK"));
        searchButton.Click();
    }

    private static void ViewSearchResultsPage(IWebDriver driver, string text)
    {
        var title = driver.Title;
        Assert.That(title, Is.EqualTo(text + " - Google Search"));
    }
}