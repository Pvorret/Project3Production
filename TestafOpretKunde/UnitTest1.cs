using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project3ProductionLtd;

namespace TestafOpretKunde
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            bool expectedResult = true;
            string navn = "Peter";
            string Adresse = "Bøgevej 34";
            string Tlf = "25257777";
            string Email = "peter@peter.dk";
            bool actualResult = Controller.EnterCustomerInfomation(navn, Adresse, Tlf,Email);
            
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
