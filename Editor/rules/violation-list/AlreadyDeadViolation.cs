
namespace SimpleCombatSystem
{
    public class AlreadyDeadViolation : Violation
    {
        public override string GetCause()
        {
            return "The fighter is already dead";
        }
    }
}