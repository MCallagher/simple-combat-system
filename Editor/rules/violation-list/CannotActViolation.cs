
namespace SimpleCombatSystem
{
    public class CannotActViolation : Violation
    {
        public override string GetCause()
        {
            return "The fighter cannot act";
        }
    }
}
