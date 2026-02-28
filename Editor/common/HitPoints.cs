
using System.Collections.Generic;
using System;

namespace SimpleCombatSystem
{
    public class HitPoints
    {
        public static readonly int MIN_VALUE = 0;
        public static readonly int MAX_VALUE = 1000000;
        public static readonly string DEFAULT_KEY = "HP";

        private Dictionary<string, int> hp;

        // Constructors
        public HitPoints()
        {
            hp = new();
        }

        public HitPoints(int value) : this(DEFAULT_KEY, value) { }

        public HitPoints(string key, int value)
        {
            hp = new();
            hp[key] = value;
        }

        public HitPoints(Dictionary<string, int> hp)
        {
            this.hp = hp;
        }

        // Getters
        public int GetHp()
        {
            return hp[DEFAULT_KEY];
        }

        public int GetHp(string key)
        {
            return hp[key];
        }

        public List<string> GetKeys()
        {
            return new(hp.Keys);
        }

        public Dictionary<string, int> GetHpDict()
        {
            Dictionary<string, int> hpDict = new();
            foreach (string key in hp.Keys)
            {
                hpDict[key] = hp[key];
            }
            return hpDict;
        }

        // Removers
        public void RemoveHpKey(string key)
        {
            hp.Remove(key);
        }

        // Arithmetic Operators
        public static HitPoints operator +(HitPoints left, HitPoints right)
        {
            Dictionary<string, int> hp = new();
            foreach (string key in Union(left.hp.Keys, right.hp.Keys))
            {
                hp[key] = Math.Min(left.hp.GetValueOrDefault(key, 0) + right.hp.GetValueOrDefault(key, 0), MAX_VALUE);
            }
            return new HitPoints(hp);
        }

        public static HitPoints operator -(HitPoints left, HitPoints right)
        {
            Dictionary<string, int> hp = new();
            foreach (string key in left.hp.Keys)
            {
                hp[key] = Math.Max(left.hp.GetValueOrDefault(key, 0) - right.hp.GetValueOrDefault(key, 0), MIN_VALUE);
            }
            return new HitPoints(hp);
        }

        // Relative Operators
        public bool ExactEquals(HitPoints other)
        {
            if (this.hp.Keys.Count != other.hp.Keys.Count)
            {
                return false;
            }
            foreach (string key in this.hp.Keys)
            {
                if (!other.hp.ContainsKey(key))
                {
                    return false;
                }
                if (this.hp[key] != other.hp[key])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator ==(HitPoints left, HitPoints right)
        {
            return left.CumulativeValue() == right.CumulativeValue();
        }

        public static bool operator !=(HitPoints left, HitPoints right)
        {
            return left.CumulativeValue() != right.CumulativeValue();
        }

        public static bool operator <(HitPoints left, HitPoints right)
        {
            return left.CumulativeValue() < right.CumulativeValue();
        }

        public static bool operator <=(HitPoints left, HitPoints right)
        {
            return left.CumulativeValue() <= right.CumulativeValue();
        }

        public static bool operator >(HitPoints left, HitPoints right)
        {
            return left.CumulativeValue() > right.CumulativeValue();
        }

        public static bool operator >=(HitPoints left, HitPoints right)
        {
            return left.CumulativeValue() >= right.CumulativeValue();
        }

        // Methods
        public int CumulativeValue()
        {
            int tot = 0;
            foreach (string key in hp.Keys)
            {
                tot += hp[key];
            }
            return tot;
        }

        public HitPoints Clone()
        {
            Dictionary<string, int> hp = new();
            foreach (string key in this.hp.Keys)
            {
                hp[key] = this.hp[key];
            }
            return new HitPoints(hp);
        }

        // Min Max
        public static HitPoints CumulativeMax(HitPoints left, HitPoints right)
        {
            if (left >= right)
            {
                return left;
            }
            return right;
        }

        public static HitPoints CumulativeMin(HitPoints left, HitPoints right)
        {
            if (left <= right)
            {
                return left;
            }
            return right;
        }

        public static HitPoints IndividualMax(HitPoints left, HitPoints right)
        {
            Dictionary<string, int> hp = new();
            foreach (string key in Union(left.hp.Keys, right.hp.Keys))
            {
                hp[key] = Math.Max(left.hp.GetValueOrDefault(key, 0), right.hp.GetValueOrDefault(key, 0));
            }
            return new HitPoints(hp);
        }

        public static HitPoints IndividualMin(HitPoints left, HitPoints right)
        {
            Dictionary<string, int> hp = new();
            foreach (string key in Union(left.hp.Keys, right.hp.Keys))
            {
                hp[key] = Math.Min(left.hp.GetValueOrDefault(key, MAX_VALUE), right.hp.GetValueOrDefault(key, MAX_VALUE));
            }
            return new HitPoints(hp);
        }

        // Overrides
    #nullable enable
        public override bool Equals(object? o) { return base.Equals(o); }
    #nullable disable
        public override int GetHashCode() { return base.GetHashCode(); }

        private static List<string> Union(IEnumerable<string> enumA, IEnumerable<string> enumB)
        {
            HashSet<string> newSet = new(enumA);
            foreach (string value in enumB)
            {
                newSet.Add(value);
            }
            return new(newSet);
        }
    }
}
