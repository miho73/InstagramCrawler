using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading;

namespace InstagramCrawling
{
    public class Crawler
    {
        public ChromeDriver driver;
        public ChromeOptions options = new ChromeOptions();
        public Crawler()
        {
            options.AddArgument("headless");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.instagram.com/");
        }
        public void Login(string id, string pwd, string loopback)
        {
            Thread.Sleep(500);
            var idField = driver.FindElementByXPath(@"//*[@id='loginForm']/div/div[1]/div/label/input");
            var pwdField = driver.FindElementByXPath(@"//*[@id='loginForm']/div/div[2]/div/label/input");
            var submit = driver.FindElementByXPath("//*[@id=\"loginForm\"]/div/div[3]/button");
            idField.SendKeys(id);
            pwdField.SendKeys(pwd);
            submit.Click();
            Thread.Sleep(4000);
            driver.Navigate().GoToUrl(loopback);
        }
        public List<string> GetPhotoUrl()
        {
            List<string> ret = new List<string>();
            while(true)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> hrefs = driver.FindElementsByClassName("v1Nh3");
                    driver.FindElementByClassName("By4nA");
                    foreach (IWebElement ele in hrefs)
                    {
                        string lnk = ele.FindElement(By.TagName("a")).GetAttribute("href");
                        if (!ret.Contains(lnk))
                        {
                            ret.Add(lnk);
                        }
                    }
                    driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                } catch(Exception)
                {
                    break;
                }
                Thread.Sleep(300);
            }
            ReadOnlyCollection<IWebElement> hrefsx = driver.FindElementsByClassName("v1Nh3");
            foreach (IWebElement ele in hrefsx)
            {
                string lnk = ele.FindElement(By.TagName("a")).GetAttribute("href");
                if (!ret.Contains(lnk))
                {
                    ret.Add(lnk);
                }
            }
            return ret;
        }
        public List<string> GetFrom(string url)
        {
            List<string> ret = new List<string>();
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            try
            {
                driver.ExecuteScript("document.getElementsByClassName('Z666a')[0].remove();");
            }
            catch { }
            ReadOnlyCollection<IWebElement> eles = driver.FindElementsByClassName("FFVAD");
            foreach(IWebElement ele in eles)
            {
                ret.Add(ele.GetAttribute("src"));
            }
            return ret;
        }
        public void SaveAs(string url, string path, int cnt)
        {
            if (url == null) return;
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(50);
            Screenshot ss = driver.GetScreenshot();
            ss.SaveAsFile(path + "\\" + cnt + ".png");
        }
    }
}