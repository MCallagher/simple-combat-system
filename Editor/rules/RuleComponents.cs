using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class RuleComponents
    {
        public static List<Violation> IsTeamInTurn(ITeam team)
        {
            if (!team.HasStatus(TeamStatus.InTurn))
            {
                return new() { new NotTeamTurnViolation() };
            }
            return new();
        }

        public static List<Violation> IsTheFightOver(ITeam teamA, ITeam teamB)
        {
            if (
                teamA.HasStatus(TeamStatus.Winner) ||
                teamA.HasStatus(TeamStatus.Defeated) ||
                teamB.HasStatus(TeamStatus.Winner) ||
                teamB.HasStatus(TeamStatus.Defeated)
            )
            {
                return new() { new FightOverViolation() };
            }
            return new();
        }

        public static List<Violation> IsAlreadyDead(IFighter fighter)
        {
            if (fighter.HasStatus(FighterStatus.Dead))
            {
                return new() { new AlreadyDeadViolation() };
            }
            return new();
        }

        public static List<Violation> CanFighterAct(IFighter fighter)
        {
            if (fighter.HasStatus(FighterStatus.Attacked) || fighter.HasStatus(FighterStatus.Rested))
            {
                return new() { new CannotActViolation() };
            }
            return new();
        }


        public static List<Violation> IsAnyoneRested(ITeam team)
        {
            foreach (var fighter in team.GetFighters())
            {
                if (fighter.HasStatus(FighterStatus.Rested))
                {
                    return new() { new TeamAlreadyRestedViolation() };
                }
            }
            return new();
        }

        public static List<Violation> IsSomeoneTurn(ITeam teamA, ITeam teamB)
        {
            if (
                teamA.HasStatus(TeamStatus.InTurn) ||
                teamB.HasStatus(TeamStatus.InTurn)
            )
            {
                return new() { new TurnAlreadyStartedViolation() };
            }
            return new();
        }

        public static List<Violation> AreInDifferentTeams(IFighter fighterA, IFighter fighterB)
        {
            if (fighterA.GetTeam() == fighterB.GetTeam())
            {
                return new() { new SameTeamViolation() };
            }
            return new();
        }

        public static List<Violation> IsFighterResting(IFighter fighter)
        {
            if (fighter.HasStatus(FighterStatus.Rested))
            {
                return new() { new FighterIsRestingViolation() };
            }
            return new();
        }

        public static List<Violation> AreThereTwoVigilantFighters(ITeam team)
        {
            int vigilantCount = 0;
            foreach (IFighter fighter in team.GetFighters())
            {
                if (!fighter.HasStatus(FighterStatus.Rested) && !fighter.HasStatus(FighterStatus.Dead))
                {
                    vigilantCount++;
                }
            }
            if (vigilantCount < 2)
            {
                return new() { new NoVigilantFighterInTeam() };
            }
            return new();
        }
    }
}

