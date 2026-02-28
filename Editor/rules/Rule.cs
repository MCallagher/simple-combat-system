
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public abstract class Rule
    {
        public bool IsSatisfied(Action action)
        {
            return GetViolations(action).Count == 0;
        }

        public abstract List<Violation> GetViolations(Action action);
    }
}
