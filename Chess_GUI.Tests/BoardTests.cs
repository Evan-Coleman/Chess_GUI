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

            // Valid move consists of a (char,int,char,int)
            Assert.IsTrue(target.ValidInputCheck("a2a4"));
        }

        [TestMethod]
        public void InValidMoves()
        {
            var target = new BoardViewModel();

            Assert.IsFalse(target.ValidInputCheck("aaaa"));
            Assert.IsFalse(target.ValidInputCheck("1234"));
            Assert.IsFalse(target.ValidInputCheck("123d"));
            Assert.IsFalse(target.ValidInputCheck("12d1"));
            Assert.IsFalse(target.ValidInputCheck("1d2d"));

            // Valid move's chars can only consist of letters up to the letter "H"
            Assert.IsFalse(target.ValidInputCheck("z1z2"));
            Assert.IsFalse(target.ValidInputCheck("z1a2"));
            Assert.IsFalse(target.ValidInputCheck("i1a2"));

            // Valid move's ints can only consist of numbers from 1 to 8
            Assert.IsFalse(target.ValidInputCheck("a1a9"));
            Assert.IsFalse(target.ValidInputCheck("a1a1"));
        }
    }
}
