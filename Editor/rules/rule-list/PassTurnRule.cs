
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class PassTurnRule : Rule
    {
        public override List<Violation> GetViolations(Action action)
        {
            List<Violation> violations = new();
            if(action.GetActionType() == ActionType.PassTurn)
            {
                if(action.GetMode() == ActionMode.Team2x)
                {
                    List<object> parameters = action.GetParams();
                    ITeam team = (ITeam) parameters[0];
                    ITeam otherTeam = (ITeam) parameters[1];

                    violations.AddRange(RuleComponents.IsTeamInTurn(team));
                    violations.AddRange(RuleComponents.IsTheFightOver(team, otherTeam));
                }
            }
            return violations;
        }
    }
}
