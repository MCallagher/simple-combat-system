
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public abstract class ActionTeam2x : Action
    {
        public ITeam team1 { get; }
        public ITeam team2 { get; }
        public ActionTeam2x(ActionType actionType, List<object> actionParams) : base(actionType, ActionMode.Team2x, actionParams)
        {
            team1 = (ITeam)actionParams[0];
            team2 = (ITeam)actionParams[1];
        }
    }
}
