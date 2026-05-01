
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class RestRule : Rule
    {
        public override List<Violation> GetViolations(Action action)
        {
            List<Violation> violations = new();
            if(action.GetActionType() == ActionType.Rest)
            {
                if(action.GetMode() == ActionMode.Fighter1x)
                {
                    List<object> parameters = action.GetParams();
                    IFighter rester = (IFighter) parameters[0];

                    violations.AddRange(RuleComponents.IsTheFightOver(rester.GetTeam(), rester.GetTeam()));
                    violations.AddRange(RuleComponents.IsTeamInTurn(rester.GetTeam()));
                    violations.AddRange(RuleComponents.IsAlreadyDead(rester));
                    violations.AddRange(RuleComponents.CanFighterAct(rester));
                    violations.AddRange(RuleComponents.IsAnyoneRested(rester.GetTeam()));
                    violations.AddRange(RuleComponents.AreThereTwoVigilantFighters(rester.GetTeam()));
                }
            }
            return violations;
        }
    }
}
