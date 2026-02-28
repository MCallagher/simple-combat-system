
namespace SimpleCombatSystem
{
    public class FightOverViolation : Violation
    {
        public override string GetCause()
        {
            return "The fighter is already terminated";
        }
    }
}
