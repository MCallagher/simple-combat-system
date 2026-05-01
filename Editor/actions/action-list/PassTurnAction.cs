
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class PassTurnAction : ActionTeam2x
    {
        public PassTurnAction(List<object> actionParams) : base(ActionType.PassTurn, actionParams) { }

        public override void Perform()
        {
            ITeam current = team1;
            ITeam other = team2;

            // Perform action
            current.RemoveStatus(TeamStatus.InTurn);
            other.AddStatus(TeamStatus.InTurn);

            // Update status at turn start
            foreach (IFighter fighter in other.GetFighters())
            {
                fighter.RemoveStatus(FighterStatus.Rested);
            }

            // Update status at turn end
            foreach (IFighter fighter in current.GetFighters())
            {
                fighter.RemoveStatus(FighterStatus.Attacked);
            }
        }
    }
}
