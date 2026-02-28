
using System.Collections.Generic;
using System;

namespace SimpleCombatSystem
{
    public class CombatSystem
    {
        private Ruleset ruleset;

        public CombatSystem(Ruleset ruleset)
        {
            this.ruleset = ruleset;
        }

        public bool IsValidAction(Action action)
        {
            return ruleset.AreRulesSatisfied(action);
        }

        public List<Violation> GetActionViolation(Action action)
        {
            return ruleset.GetRulesViolations(action);
        }

        public void PerformAction(Action action)
        {
            if (!IsValidAction(action))
            {
                List<Violation> violations = GetActionViolation(action);
                foreach (Violation violation in violations)
                {
                    Console.WriteLine(violation.GetCause());
                }
                return;
            }
            action.Perform();
        }
    }
}
