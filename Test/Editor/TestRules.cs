
using SimpleCombatSystem;
using System.Collections.Generic;
using NUnit.Framework;
using System;

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
            Action action = new AttackAction(new List<object>() { atk, def });
            Action action2 = new AttackAction(new List<object>() { atk, atk });

            // Valid
            atkTeam.AddStatus(TeamStatus.InTurn);
            Assert.True(rule.IsSatisfied(action));
            Assert.IsEmpty(rule.GetViolations(action));

            // Invalid | Friendly fire
            Assert.False(rule.IsSatisfied(action2));
            Assert.AreEqual(1, rule.GetViolations(action2).Count);

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
            Action action = new PassTurnAction(new List<object>() { currentTeam, otherTeam });

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
            Action action = new StartTurnAction(new List<object>() { currentTeam, otherTeam });

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

        
        [Test]
        public void RestRuleTest()
        {
            Fighter fighter1 = new Fighter("fighter1", new HitPoints(10));
            Fighter fighter2 = new Fighter("fighter2", new HitPoints(10));
            Team selfTeam = new Team("team-self");
            selfTeam.AddFighter(fighter1);
            selfTeam.AddFighter(fighter2);

            Rule rule = new RestRule();
            Action action = new RestAction(new List<object>() { fighter1 });

            // Valid
            selfTeam.AddStatus(TeamStatus.InTurn);
            Assert.True(rule.IsSatisfied(action));
            Assert.IsEmpty(rule.GetViolations(action));

            int expectedViolations = 1;

            // Invalid | + Not in turn
            selfTeam.RemoveStatus(TeamStatus.InTurn);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Fight over
            selfTeam.AddStatus(TeamStatus.Winner);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Already dead
            fighter1.AddStatus(FighterStatus.Dead);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Cannot act
            fighter1.AddStatus(FighterStatus.Attacked);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
            expectedViolations += 1;

            // Invalid | + Someone rested already
            fighter2.AddStatus(FighterStatus.Rested);
            Assert.False(rule.IsSatisfied(action));
            Assert.AreEqual(expectedViolations, rule.GetViolations(action).Count);
        }
    }
}
