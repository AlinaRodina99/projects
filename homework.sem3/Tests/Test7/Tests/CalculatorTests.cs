using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test7;

namespace Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private ViewModel viewModel;

        [TestInitialize]
        public void TestMethod1()
        {
            viewModel = new ViewModel();
        }

        [TestMethod]
        public void CheckAdd()
        {
            viewModel.BoxForFirstNumber = "1";
            viewModel.BoxForSecondNumber = "2";
            viewModel.GetAdd.Execute(viewModel);

            Assert.AreEqual("3", viewModel.Answer);
        }
        [TestMethod]
        public void CheckDivision()
        {
            viewModel.BoxForFirstNumber = "2";
            viewModel.BoxForSecondNumber = "2";
            viewModel.GetDivision.Execute(viewModel);

            Assert.AreEqual("1", viewModel.Answer);
        }

        [TestMethod]
        public void CheckSubtraction()
        {
            viewModel.BoxForFirstNumber = "1";
            viewModel.BoxForSecondNumber = "2";
            viewModel.GetSubtraction.Execute(viewModel);

            Assert.AreEqual("-1", viewModel.Answer);
        }

        [TestMethod]
        public void CheckMultiplication()
        {
            viewModel.BoxForFirstNumber = "1";
            viewModel.BoxForSecondNumber = "2";
            viewModel.GetMultiplication.Execute(viewModel);

            Assert.AreEqual("2", viewModel.Answer);
        }
    }
}
