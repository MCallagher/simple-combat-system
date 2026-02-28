
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class StartTurnRule : Rule
    {
        public override List<Violation> GetViolations(Action action)
        {
            List<Violation> violations = new();
            if(action.GetActionType() == ActionType.StartTurn)
            {
                if(action.GetMode() == ActionMode.Team2x)
                {
                    List<object> parameters = action.GetParams();
                    ITeam team = (ITeam) parameters[0];
                    ITeam otherTeam = (ITeam) parameters[1];

                    violations.AddRange(RuleComponents.IsSomeoneTurn(team, otherTeam));
                    violations.AddRange(RuleComponents.IsTheFightOver(team, otherTeam));
                }
            }
            return violations;
        }
    }
}
