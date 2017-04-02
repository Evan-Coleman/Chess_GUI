using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_GUI;
using Chess_GUI.Models;
using Chess_GUI.ViewModels;


namespace Chess_GUI.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void ValidMoves()
        {
            var target = new BoardViewModel();

            Assert.IsTrue(target.ValidInputCheck("1234"));
        }
    }
}
