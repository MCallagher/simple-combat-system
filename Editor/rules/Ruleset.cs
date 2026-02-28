
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class Ruleset
    {
        protected List<Rule> rules;

        public Ruleset(List<Rule> rules)
        {
            this.rules = rules;
        }

        public bool AreRulesSatisfied(Action action)
        {
            return GetRulesViolations(action).Count == 0;
        }

        public List<Violation> GetRulesViolations(Action action)
        {
            List<Violation> violations = new();
            foreach (Rule rule in rules)
            {
                violations.AddRange(rule.GetViolations(action));
            }
            return violations;
        }
    }
}
