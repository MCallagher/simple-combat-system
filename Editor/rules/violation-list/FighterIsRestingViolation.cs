
namespace SimpleCombatSystem
{
    public class FighterIsRestingViolation : Violation
    {
        public override string GetCause()
        {
            return "The target fighter is resting";
        }
    }
}