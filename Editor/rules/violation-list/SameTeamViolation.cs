
namespace SimpleCombatSystem
{
    public class SameTeamViolation : Violation
    {
        public override string GetCause()
        {
            return "The fighters are on the same team";
        }
    }
}