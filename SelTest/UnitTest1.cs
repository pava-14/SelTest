using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelTest;

public class Tests
{
    private WebDriver? _driver;
    private string _siteUrl = string.Empty;
    private int _defaultTimeout = 10;

    [SetUp]
    public void Setup()
    {
        _siteUrl = "https://www.google.com";
        
        _driver = new ChromeDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_defaultTimeout);
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        if (_driver != null)
        {
            _driver.Url = _siteUrl;

            var inputBox = _driver.FindElement(By.Name("q"));
            inputBox.SendKeys("c# selenium tutorials");

            var btnOk = _driver.FindElement(By.Name("btnK"));
            btnOk.Click();
        }

        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        Console.Write("test case ended");
    }
}