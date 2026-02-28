
namespace SimpleCombatSystem
{
    public class NotTeamTurnViolation : Violation
    {
        public override string GetCause()
        {
            return "It is not the turn of the team of the active fighter";
        }
    }
}