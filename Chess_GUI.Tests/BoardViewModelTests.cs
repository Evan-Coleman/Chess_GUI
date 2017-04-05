using System;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_GUI;
using Chess_GUI.Models;
using Chess_GUI.ViewModels;
using Chess_GUI.ViewModels.Commands;


namespace Chess_GUI.Tests
{
    [TestClass]
    public class BoardViewModelTests
    {
        [TestMethod]
        public void ValidInput()
        {
            var target = new BoardViewModel();

            // Valid move consists of a (char,int,char,int)
            Assert.IsTrue(target.Move("a2a4"));

            // Lower bound test
            Assert.IsTrue(target.Move("a1a2"));

            // Upper bound test
            Assert.IsTrue(target.Move("h8h7"));
        }

        [TestMethod]
        public void InValidInput()
        {
            var target = new BoardViewModel();

            // Paramaters must be (char,int,char,int)
            Assert.IsFalse(target.Move("aaaa"));
            Assert.IsFalse(target.Move("1234"));
            Assert.IsFalse(target.Move("123d"));
            Assert.IsFalse(target.Move("12d1"));
            Assert.IsFalse(target.Move("1d11"));
            Assert.IsFalse(target.Move("d111"));
            Assert.IsFalse(target.Move("dd11"));
            Assert.IsFalse(target.Move("1dd1"));
            Assert.IsFalse(target.Move("11dd"));

            // Valid move's chars can only consist of letters up to the letter "H"
            Assert.IsFalse(target.Move("z1z2"));
            Assert.IsFalse(target.Move("z1a2"));
            Assert.IsFalse(target.Move("i1a2"));

            // Valid move's ints can only consist of numbers from 1 to 8
            Assert.IsFalse(target.Move("a1a9"));
            Assert.IsFalse(target.Move("a9a1"));
            Assert.IsFalse(target.Move("a9a9"));
            Assert.IsFalse(target.Move("a9a0"));
            Assert.IsFalse(target.Move("a0a9"));
            Assert.IsFalse(target.Move("a0a0"));

            // Valid move has a length of 4
            Assert.IsFalse(target.Move("a1a"));
            Assert.IsFalse(target.Move("a1a2a"));

        }

        [TestMethod]
        public void DiableButtons()
        {
            var target = new BoardViewModel();

            // We only disable a button if it is already selected (if it equals the MoveText already in the viewmodel
            Assert.IsTrue(target.Canexecute(null));
            Assert.IsTrue(target.Canexecute("a1"));
            Assert.IsTrue(target.Canexecute("a1"));
            Assert.IsTrue(target.Canexecute("a1aaa"));


            target = new BoardViewModel();
            // In order to simulate a selection, we call Move on target with the piece a1
            target.Move((object)"a1");
            // The move a1 has already been entered, so the button should be greyed out
            Assert.IsFalse(target.Canexecute("a1"));
        }

        [TestMethod]
        public void TestCommands()
        {
            var target = new BoardViewModel();

            var moveCommand = target.MoveCommand;
            Assert.IsInstanceOfType(moveCommand, typeof(RelayCommand));

            moveCommand.Execute("a1");
            moveCommand.Execute("a1");
            moveCommand.Execute("a1asdsad");
            moveCommand.Execute("a1");
            moveCommand.Execute("a2");
            moveCommand.Execute(null);

            moveCommand.CanExecute("a1");
        }
    }
}
