
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class AttackAction : ActionFighter2x
    {
        public AttackAction(List<object> actionParams) : base(ActionType.Attack, actionParams) { }

        public override void Perform()
        {
            IFighter attacker = fighter1;
            IFighter defender = fighter2;

            // Perform action
            HitPoints damage = attacker.GetAttack();
            defender.GetHarmed(damage);

            // Update status
            attacker.AddStatus(FighterStatus.Attacked);
            if (!defender.IsAlive())
            {
                defender.AddStatus(FighterStatus.Dead);
                if (Utils.GetAliveFightersInTeam(defender.GetTeam()) == 0)
                {
                    attacker.GetTeam().AddStatus(TeamStatus.Winner);
                    defender.GetTeam().AddStatus(TeamStatus.Defeated);
                }
            }
        }
    }
}
