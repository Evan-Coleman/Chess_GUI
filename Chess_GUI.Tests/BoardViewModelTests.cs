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


            // Valid.ValidInputCheck consists of a (char,int,char,int)
            Assert.IsTrue(target.ValidInputCheck("a2a4"));

            // Lower bound test
            Assert.IsTrue(target.ValidInputCheck("a1a2"));

            // Upper bound test
            Assert.IsTrue(target.ValidInputCheck("h8h7"));
        }

        [TestMethod]
        public void InValidInput()
        {
            var target = new BoardViewModel();

            // Paramaters must be (char,int,char,int)
            Assert.IsFalse(target.ValidInputCheck("aaaa"));
            Assert.IsFalse(target.ValidInputCheck("1234"));
            Assert.IsFalse(target.ValidInputCheck("123d"));
            Assert.IsFalse(target.ValidInputCheck("12d1"));
            Assert.IsFalse(target.ValidInputCheck("1d11"));
            Assert.IsFalse(target.ValidInputCheck("d111"));
            Assert.IsFalse(target.ValidInputCheck("dd11"));
            Assert.IsFalse(target.ValidInputCheck("1dd1"));
            Assert.IsFalse(target.ValidInputCheck("11dd"));

            // Valid.ValidInputCheck's chars can only consist of letters up to the letter "H"
            Assert.IsFalse(target.ValidInputCheck("z1z2"));
            Assert.IsFalse(target.ValidInputCheck("z1a2"));
            Assert.IsFalse(target.ValidInputCheck("i1a2"));

            // Valid.ValidInputCheck's ints can only consist of numbers from 1 to 8
            Assert.IsFalse(target.ValidInputCheck("a1a9"));
            Assert.IsFalse(target.ValidInputCheck("a9a1"));
            Assert.IsFalse(target.ValidInputCheck("a9a9"));
            Assert.IsFalse(target.ValidInputCheck("a9a0"));
            Assert.IsFalse(target.ValidInputCheck("a0a9"));
            Assert.IsFalse(target.ValidInputCheck("a0a0"));

            // Valid.ValidInputCheck has a length of 4
            Assert.IsFalse(target.ValidInputCheck("a1a"));
            Assert.IsFalse(target.ValidInputCheck("a1a2a"));

        }

        //        [TestMethod]
        //        public void DiableButtons()
        //        {
        //            var target = new BoardViewModel();
        //
        //            // We only disable a button if it is already selected (if it equals the MoveText already in the viewmodel
        //            Assert.IsTrue(target.Canexecute(null));
        //            Assert.IsTrue(target.Canexecute("a1"));
        //            Assert.IsTrue(target.Canexecute("a1"));
        //            Assert.IsTrue(target.Canexecute("a1aaa"));
        //
        //
        //            target = new BoardViewModel();
        //            // In order to simulate a selection, we call Move on target with the piece a1
        //            target.Move((object)"a1");
        //            // The move a1 has already been entered, so the button should be greyed out
        //            Assert.IsFalse(target.Canexecute("a1"));
        //        }

        [TestMethod]
        public void TestCommands()
        {
            var target = new BoardViewModel();

            var moveCommand = target.MoveCommand;
            Assert.IsInstanceOfType(moveCommand, typeof(RelayCommand));

            // Tests a valid move (knight moves)
            moveCommand.Execute("B1C3");
            //Assert.AreNotEqual("", target.Board.MBoard[5][2]);

            // Tests invalid move
            moveCommand.Execute("BB1C3");

            // Sequence for a king take (will break when turn checking is implemented)
            moveCommand.Execute("C3B5");
            moveCommand.Execute("B5D6");
            moveCommand.Execute("D6E8");
            Assert.AreEqual(1, target.WonGame);



            // Needs null handling
            Assert.IsTrue(moveCommand.CanExecute(null));
        }
    }
}
