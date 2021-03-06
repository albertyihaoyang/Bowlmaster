﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest
{
    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]
    public void Setup(){
        pinFalls = new List<int>();
    }


    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03Bowl28SpareReturnsEndTurn()
    {
        int[] rolls = { 8, 2 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    //[Test]
    //public void T05CheckResetAtStrikeInLastFrame()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    actionMaster.Bowl(1);
    //    Assert.AreEqual(reset, actionMaster.Bowl(9));
    //}

    //[Test]
    //public void T07EndInEndGame()
    //{
    //    int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    actionMaster.Bowl(1);
    //    Assert.AreEqual(endGame, actionMaster.Bowl(9));
    //}

    //[Test]
    //public void T08GameEndsAtBowl20()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(endGame, actionMaster.Bowl(1));
    //}

    //[Test]
    //public void T09()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(tidy, actionMaster.Bowl(5));
    //}

    //[Test]
    //public void T10()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(tidy, actionMaster.Bowl(0));
    //}

    [Test]
    public void T11()
    {
        int[] rolls = { 0, 10, 5, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    //[Test]
    //public void T12()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
    //    foreach (int roll in rolls)
    //    {
    //        actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(reset, actionMaster.Bowl(10));
    //    Assert.AreEqual(reset, actionMaster.Bowl(10));
    //    Assert.AreEqual(endGame, actionMaster.Bowl(10));
    //}
}
