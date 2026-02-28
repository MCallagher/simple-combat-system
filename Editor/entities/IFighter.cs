
namespace SimpleCombatSystem
{
    public interface IFighter : IHasName, IHasTeam, IHasStatus<FighterStatus>, IHasHealth, ICanAttack
    { }
}
