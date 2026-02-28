
namespace SimpleCombatSystem
{
    public class TurnAlreadyStartedViolation : Violation
    {
        public override string GetCause()
        {
            return "Turns system already started";
        }
    }
}
