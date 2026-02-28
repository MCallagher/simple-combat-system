
namespace SimpleCombatSystem
{
    public class Utils
    {
        public static int GetAliveFightersInTeam(ITeam team)
        {
            int count = 0;
            foreach (IFighter fighter in team.GetFighters())
            {
                if (fighter.IsAlive())
                {
                    count += 1;
                }
            }
            return count;
        }
    }
}
