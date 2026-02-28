
using SimpleCombatSystem;
using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleCombatSystem.Test
{
    [TestFixture]
    public class TestRules
    {
        [Test]
        public void AttackRuleTest()
        {
            Fighter atk = new Fighter("attacker", new HitPoints(10));
            Fighter def = new Fighter("defender", new HitPoints(10));
            Team atkTeam = new Team("team-atk");
            Team defTeam = new Team("team-def");
            atkTeam.AddFighter(atk);
            defTeam.AddFighter(def);

            Rule rule = new AttackRule();
            SimpleCombatSystem.Action action = new AttackAction(new List<object>() { atk, def });

            // Valid
            atkTeam.AddStatus(TeamStatus.InTurn);
            Assert.True(rule.IsSatisfied(action));
            Assert.IsEmpty(rule.GetViolations(action));

            int expectedViolations = 1;

            // Invalid | + Fight over
            atkTeam.AddStatus(TeamStatus.Winner);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Not in turn
            atkTeam.RemoveStatus(TeamStatus.InTurn);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Dead attacker
            atk.AddStatus(FighterStatus.Dead);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Dead defender
            def.AddStatus(FighterStatus.Dead);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Already attacked
            atk.AddStatus(FighterStatus.Attacked);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
        }

        [Test]
        public void PassTurnRuleTest()
        {
            Team currentTeam = new Team("cur-team");
            Team otherTeam = new Team("oth-team");

            Rule rule = new PassTurnRule();
            SimpleCombatSystem.Action action = new PassTurnAction(new List<object>() { currentTeam, otherTeam });

            // Valid
            currentTeam.AddStatus(TeamStatus.InTurn);
            Assert.True(rule.IsSatisfied(action));
            Assert.IsEmpty(rule.GetViolations(action));

            int expectedViolations = 1;

            // Invalid | + Fight over
            currentTeam.AddStatus(TeamStatus.Winner);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Not in turn
            currentTeam.RemoveStatus(TeamStatus.InTurn);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
        }

        [Test]
        public void StartTurnRuleTest()
        {
            Team currentTeam = new Team("cur-team");
            Team otherTeam = new Team("oth-team");

            Rule rule = new StartTurnRule();
            SimpleCombatSystem.Action action = new StartTurnAction(new List<object>() { currentTeam, otherTeam });

            // Valid
            Assert.True(rule.IsSatisfied(action));
            Assert.IsEmpty(rule.GetViolations(action));

            int expectedViolations = 1;

            // Invalid | + Already someone turn
            currentTeam.AddStatus(TeamStatus.InTurn);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Fight over
            currentTeam.AddStatus(TeamStatus.Winner);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
        }
    }
}
