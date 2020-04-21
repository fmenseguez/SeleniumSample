using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Create Chrome instance using Selenium
            // Make sure the HttpWatch extension is enabled in the Selenium Chrome session by referencing the CRX file
            // e.g. C:\Program Files (x86)\HttpWatch\HttpWatchForChrome.crx
            // The HttpWatchCRXFile property returns the installed location of the CRX file
            var options = new ChromeOptions();
            // Start the Chrome browser session
            var driver = new ChromeDriver(options);
            // Goto blank start page so that HttpWatch recording can be started
            driver.Navigate().GoToUrl("https://prenotaonline.esteri.it/Login.aspx?cidsede=100018&returnUrl=%2f%2f");



            driver.FindElementByName("BtnLogin").Click();

            //GET into login page
            driver.FindElementByName("UserName").SendKeys("Federico.menseguez@gmail.com");
            driver.FindElementByName("Password").SendKeys("Fede2807");
            driver.FindElementByName("loginCaptcha").SendKeys("");

            // By byName = driver.element ("captchaLogin");


            //= "captcha/default.aspx?pos=2&amp;vers=92309646"
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(
                (d) =>
            {
                return d.FindElement(By.Name("loginCaptcha")).GetAttribute("value").Length == 4; // here you can use any locator that identifies a successful / failed login
            });
            driver.FindElementByName("BtnConfermaL").Click();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //once logged in
            wait.Until(
               (d) =>
               {
                   var soliciteTurnoElement = d.FindElement(By.Name("ctl00$repFunzioni$ctl00$btnMenuItem"));
                   var result = soliciteTurnoElement.Displayed && soliciteTurnoElement.GetAttribute("value").ToUpper().Contains("SU TURNO");
                   if (result)
                   {
                       soliciteTurnoElement.Click();
                       soliciteTurnoElement.Click();
                   }
                   return result; // here you can use any locator that identifies a successful / failed login
               });

            //first container 
            wait.Until(
              (d) =>
              {
                  var seleccioneOficina = d.FindElement(By.Name("ctl00$ContentPlaceHolder1$rpServizi$ctl02$btnNomeServizio"));
                  var result = seleccioneOficina.Displayed && seleccioneOficina.GetAttribute("value").ToUpper().Contains("CIUDADANÍA");
                  if (result)
                  {
                      seleccioneOficina.Click();
                  }
                  return result; // here you can use any locator that identifies a successful / failed login
              });

            //WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            wait.Until(
               (d) =>
               {
                   var tipoDeTramite = d.FindElement(By.Name("ctl00$ContentPlaceHolder1$rpServizi$ctl04$btnNomeServizio"));
                   var result = tipoDeTramite.Displayed && (tipoDeTramite.GetAttribute("value").ToUpper().Contains("IURE") || tipoDeTramite.GetAttribute("value").ToUpper().Contains("SANGUINIS"));
                   if (result)
                   {
                       tipoDeTramite.Click();
                   }
                   return result; // here you can use any locator that identifies a successful / failed login
               });

            //completar datos

            var table =driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_acc_datiAddizionali1_tblDatiAdd"));
            var rows = table.FindElements(By.TagName("tr"));
            var rowsToComplete = rows.Where(x => x.FindElements(By.TagName("td")).Count() > 1);
            foreach (var row in rowsToComplete)
            {
                if (row.Text.Contains(""))
                {
                }

            }

            //    driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol1").SendKeys("543513104918");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol2").SendKeys("S");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol3").SendKeys("ESPINOSA NEGRETE 442");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol4").SendKeys("0");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol5").SendKeys("ANALISTA EN SISTEMAS DE COMPUTACION");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol6").SendKeys("INFORMATICO");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol7").SendKeys("S");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol8").SendKeys("S");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol9").SendKeys("DOMENICO MICHELE BONETTO");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol10").SendKeys("LUSERNETTA");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol11").SendKeys("01011866");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol12").SendKeys("01111921");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol13").SendKeys("");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol14").SendKeys("JUAN BONETTO");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol15").SendKeys("SANTA FE");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol16").SendKeys("24081895");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol17").SendKeys("13041964");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol18").SendKeys("18011960");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol19").SendKeys("CORDOBA");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol20").SendKeys("CORDOBA");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol21").SendKeys("TATARANIETO");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol22").SendKeys("MARIA AMELIA ABACA");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol23").SendKeys("MARIO DANTE MENSEGUEZ");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$mycontrol24").SendKeys("FEDERICO.MENSEGUEZ@GMAIL.COM");
            //driver.FindElementByName("ctl00$ContentPlaceHolder1$acc_datiAddizionali1$btnContinua").Click();



            //mes sigueinte 
            //ctl00$ContentPlaceHolder1$acc_Calendario1$myCalendario1$ctl03
            //WebDriverWait waitCalendar = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            //waitCalendar.Until(
            //   (d) =>
            //   {
            //      // IWebElement element2 = d.FindElement(By.Id("ctl00_ContentPlaceHolder1_acc_Calendario1_myCalendario1"));
            //       var disponibles = d.FindElements(By.ClassName("calendarCellOpen"));
            //       var medios = d.FindElements(By.ClassName("calendarCellMed"));
            //       if (!(disponibles.Count > 0  || medios.Count > 0))
            //       {
            //           d.FindElement(By.Id("ctl00$ContentPlaceHolder1$acc_Calendario1$myCalendario1$ctl03")).Click();
            //       };
            //       return (disponibles.Displayed || medios.Displayed); // here you can use any locator that identifies a successful / failed login
            //   });

            //            table.calendario.calendarCellOpen input
            //{
            //            color:#208020 !important;	/*Disponibilità alta*/
            //	font - weight:bold;
            //            }
            //
            //            table.calendario.calendarCellRed
            //{
            //            color: Red!important;   /*Disponibilità nulla*/
            //                font - weight:bold;
            //            }
            //
            //            table.calendario.calendarCellMed input
            //{
            //            color:#F09643 !important;	/*Disponibilità media*/
            //	font - weight:bold;
            //            }




            //ctl00$ContentPlaceHolder1$rpServizi$ctl04$btnNomeServizio


            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            //wait.Until(                
            //    (d) =>
            //{
            //    return d.FindElement(By.Name("loginCaptcha")).Text.Length==4; // here you can use any locator that identifies a successful / failed login
            //});


            // Set a unique title on the first tab so that HttpWatch can attach to it
            //var uniqueTitle = Guid.NewGuid().ToString();
            //driver.ExecuteScript("document.title = '" + uniqueTitle + "'");

            //// Attach HttpWatch to the instance of Chrome created through Selenium
            //Plugin plugin = control.AttachByTitle(uniqueTitle);
            //// Goto to the URL and wait for the page to be loaded
            //driver.Navigate().GoToUrl(url);
        }

        //[TestMethod]
        //public void TestMethod2()
        //{

        //    IWebDriver driver = new RemoteWebDriver(new System.Uri("https://prenotaonline.esteri.it/default.aspx"), new ChromeOptions());

        //}
    }
}
