
namespace SimpleCombatSystem
{
    public class TeamAlreadyRestedViolation : Violation
    {
        public override string GetCause()
        {
            return "A fighter of the team already rested";
        }
    }
}