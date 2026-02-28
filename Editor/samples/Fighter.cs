
using System.Collections.Generic;
using System;

namespace SimpleCombatSystem
{
    public class Fighter : IFighter
    {
        protected string name;
#nullable enable
        protected ITeam? team;
#nullable disable
        protected HashSet<FighterStatus> statuses;
        protected HitPoints health;
        protected HitPoints maxHealth;

        public Fighter(string name, HitPoints maxHealth)
        {
            this.name = name;
            this.health = maxHealth.Clone();
            this.maxHealth = maxHealth.Clone();
            statuses = new();
        }

        // IHasName
        public string GetName()
        {
            return name;
        }

        // IHasTeam
        public ITeam GetTeam()
        {
            if (team != null)
            {
                return team;
            }
            throw new Exception("No team assigned");
        }

        public bool HasTeam()
        {
            return team != null;
        }

        public void SetTeam(ITeam team)
        {
            this.team = team;
        }

        public void ResetTeam()
        {
            this.team = null;
        }

        // IHasStatus
        public void AddStatus(FighterStatus status)
        {
            statuses.Add(status);
        }

        public bool HasStatus(FighterStatus status)
        {
            return statuses.Contains(status);
        }

        public void RemoveStatus(FighterStatus status)
        {
            statuses.Remove(status);
        }

        // IHasHealth
        public HitPoints GetHealth()
        {
            return health.Clone();
        }

        public HitPoints GetMaxHealth()
        {
            return maxHealth.Clone();
        }

        public void GetHarmed(HitPoints damage)
        {
            health -= damage;
        }

        public void GetHealed(HitPoints heal)
        {
            health = HitPoints.IndividualMin(health + heal, maxHealth);
        }

        public bool IsAlive()
        {
            return health.CumulativeValue() > 0;
        }

        // ICanAttack
        public HitPoints GetAttack()
        {
            return new HitPoints(3);
        }
    }
}
