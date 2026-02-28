
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class AttackRule : Rule
    {
        public override List<Violation> GetViolations(Action action)
        {
            List<Violation> violations = new();
            if(action.GetActionType() == ActionType.Attack)
            {
                if(action.GetMode() == ActionMode.Fighter2x)
                {
                    List<object> parameters = action.GetParams();
                    IFighter atkFighter = (IFighter) parameters[0];
                    IFighter defFighter = (IFighter) parameters[1];
                    
                    violations.AddRange(RuleComponents.IsTheFightOver(atkFighter.GetTeam(), defFighter.GetTeam()));
                    violations.AddRange(RuleComponents.IsTeamInTurn(atkFighter.GetTeam()));
                    violations.AddRange(RuleComponents.IsAlreadyDead(atkFighter));
                    violations.AddRange(RuleComponents.IsAlreadyDead(defFighter));
                    violations.AddRange(RuleComponents.CanFighterAct(atkFighter));
                }
            }
            return violations;
        }
    }
}
