
namespace SimpleCombatSystem
{
    public interface IHasTeam
    {
        bool HasTeam();
        ITeam GetTeam();
        void SetTeam(ITeam team);
        void ResetTeam();
    }
}
