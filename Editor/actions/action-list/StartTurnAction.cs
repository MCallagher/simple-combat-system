
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class StartTurnAction : ActionTeam2x
    {
        public StartTurnAction(List<object> actionParams) : base(ActionType.StartTurn, actionParams) { }

        public override void Perform()
        {
            ITeam starting = team1;
            ITeam other = team2;

            starting.AddStatus(TeamStatus.InTurn);
        }
    }
}
