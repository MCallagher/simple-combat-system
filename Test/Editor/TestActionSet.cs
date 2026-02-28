
using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleCombatSystem.Test
{
    [TestFixture]
    public class TestActionSet
    {
        [Test]
        public void AttackActionBuildTest()
        {
            AttackAction action = new(new List<object>(){
            new Fighter("test-fighter-1", new HitPoints(10)),
            new Fighter("test-fighter-2", new HitPoints(10))
        });

            Assert.AreEqual(ActionType.Attack, action.GetActionType());
            Assert.AreEqual(ActionMode.Fighter2x, action.GetMode());
            Assert.AreEqual("test-fighter-1", action.fighter1.GetName());
            Assert.AreEqual("test-fighter-2", action.fighter2.GetName());
        }

        [Test]
        public void StartTurnActionBuildTest()
        {
            StartTurnAction action = new(new List<object>(){
            new Team("test-team-1"),
            new Team("test-team-2"),
        });

            Assert.AreEqual(ActionType.StartTurn, action.GetActionType());
            Assert.AreEqual(ActionMode.Team2x, action.GetMode());
            Assert.AreEqual("test-team-1", action.team1.GetName());
            Assert.AreEqual("test-team-2", action.team2.GetName());
        }

        [Test]
        public void PassTurnActionBuildTest()
        {
            PassTurnAction action = new(new List<object>(){
            new Team("test-team-1"),
            new Team("test-team-2"),
        });

            Assert.AreEqual(ActionType.PassTurn, action.GetActionType());
            Assert.AreEqual(ActionMode.Team2x, action.GetMode());
            Assert.AreEqual("test-team-1", action.team1.GetName());
            Assert.AreEqual("test-team-2", action.team2.GetName());
        }
    }
}
