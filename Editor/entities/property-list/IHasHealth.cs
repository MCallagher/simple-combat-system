
namespace SimpleCombatSystem
{
    public interface IHasHealth
    {
        HitPoints GetHealth();
        HitPoints GetMaxHealth();
        void GetHarmed(HitPoints damage);
        void GetHealed(HitPoints heal);
        bool IsAlive();
    }
}
