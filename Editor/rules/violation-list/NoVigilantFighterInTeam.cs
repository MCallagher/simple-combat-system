
namespace SimpleCombatSystem
{
    public class NoVigilantFighterInTeam : Violation
    {
        public override string GetCause()
        {
            return "At least one fighter on the team must be vigilant";
        }
    }
}