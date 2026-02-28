
using SimpleCombatSystem;
using System.Collections.Generic;
using NUnit.Framework;
using System.Data;

namespace SimpleCombatSystem.Test
{
    [TestFixture]
    public class TestCombat
    {
        #nullable enable
        private Fighter? aFighter;
        private Fighter? bFighter;
        private Fighter? cFighter;
        private Fighter? zFighter;
        private Fighter? wFighter;
        private Team? alphaTeam;
        private Team? zetaTeam;
        private Ruleset? ruleset;
        private CombatSystem? cs;
        #nullable disable

        [SetUp]
        public void SetUp()
        {
            aFighter = new Fighter("a", new(15));
            bFighter = new Fighter("b", new(15));
            cFighter = new Fighter("c", new(15));
            zFighter = new Fighter("z", new(4));
            wFighter = new Fighter("w", new(1));
            alphaTeam = new Team("alpha", new List<IFighter>() { aFighter, bFighter, cFighter });
            zetaTeam = new Team("zeta", new List<IFighter>() { zFighter, wFighter });
            ruleset = new Ruleset(new List<Rule>(){
           new AttackRule(),
           new StartTurnRule(),
           new PassTurnRule()
        });
            cs = new CombatSystem(ruleset);
            alphaTeam.AddStatus(TeamStatus.InTurn);
        }

        [Test]
        public void AttackTest()
        {
            SimpleCombatSystem.Action action = new AttackAction(new List<object>() { aFighter, zFighter });
            Assert.True(cs.IsValidAction(action));

            cs.PerformAction(action);
            Assert.AreEqual(1, zFighter.GetHealth().CumulativeValue());
            Assert.True(aFighter.HasStatus(FighterStatus.Attacked));
        }

        [Test]
        public void AttackAndKillTest()
        {
            SimpleCombatSystem.Action action = new AttackAction(new List<object>() { aFighter, wFighter });
            Assert.True(cs.IsValidAction(action));

            cs.PerformAction(action);
            Assert.AreEqual(0, wFighter.GetHealth().CumulativeValue());
            Assert.True(aFighter.HasStatus(FighterStatus.Attacked));
            Assert.True(wFighter.HasStatus(FighterStatus.Dead));
        }

        [Test]
        public void AttackAndWinTest()
        {
            cs.PerformAction(new AttackAction(new List<object>() { aFighter, zFighter }));
            cs.PerformAction(new AttackAction(new List<object>() { bFighter, zFighter }));
            cs.PerformAction(new AttackAction(new List<object>() { cFighter, wFighter }));

            Assert.True(alphaTeam.HasStatus(TeamStatus.Winner));
            Assert.True(zetaTeam.HasStatus(TeamStatus.Defeated));
        }

        [Test]
        public void PassTurnTest()
        {
            SimpleCombatSystem.Action action = new PassTurnAction(new List<object>() { alphaTeam, zetaTeam });
            Assert.True(cs.IsValidAction(action));

            cs.PerformAction(action);
            Assert.False(alphaTeam.HasStatus(TeamStatus.InTurn));
            Assert.True(zetaTeam.HasStatus(TeamStatus.InTurn));
        }

        [Test]
        public void StartTurnTest()
        {
            alphaTeam.RemoveStatus(TeamStatus.InTurn);
            SimpleCombatSystem.Action action = new StartTurnAction(new List<object>() { alphaTeam, zetaTeam });
            Assert.True(cs.IsValidAction(action));

            cs.PerformAction(action);
            Assert.True(alphaTeam.HasStatus(TeamStatus.InTurn));
            Assert.False(zetaTeam.HasStatus(TeamStatus.InTurn));
        }
    }
}
