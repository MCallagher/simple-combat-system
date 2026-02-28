
using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleCombatSystem.Test
{
    [TestFixture]
    public class TestHitPoint
    {
        [Test]
        public void ConstructorTest()
        {
            HitPoints hp = new HitPoints();
            Assert.IsEmpty(hp.GetKeys());

            hp = new HitPoints(10);
            Assert.AreEqual(10, hp.GetHp(HitPoints.DEFAULT_KEY));
            Assert.AreEqual(1, hp.GetKeys().Count);

            hp = new HitPoints("test-hp", 10);
            Assert.AreEqual(10, hp.GetHp("test-hp"));
            Assert.AreEqual(1, hp.GetKeys().Count);

            hp = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 10},
            {"test-hp-2", 20}
        });
            Assert.AreEqual(10, hp.GetHp("test-hp-1"));
            Assert.AreEqual(20, hp.GetHp("test-hp-2"));
            Assert.AreEqual(2, hp.GetKeys().Count);
        }

        [Test]
        public void GetterTest()
        {
            HitPoints hp = new HitPoints(new Dictionary<string, int>()
        {
            {HitPoints.DEFAULT_KEY, 5},
            {"test-hp-1", 10},
            {"test-hp-2", 20},
        });

            Assert.AreEqual(5, hp.GetHp());
            Assert.AreEqual(10, hp.GetHp("test-hp-1"));
            Assert.AreEqual(3, hp.GetKeys().Count);
            Assert.AreEqual(20, hp.GetHpDict()["test-hp-2"]);
        }

        [Test]
        public void SumTest()
        {
            HitPoints hp1 = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 10},
            {"test-hp-2", 20},
        });
            HitPoints hp2 = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-3", 35},
        });

            HitPoints hp3 = hp1 + hp2;
            Assert.AreEqual(3, hp3.GetKeys().Count);
            Assert.AreEqual(25, hp3.GetHp("test-hp-1"));
            Assert.AreEqual(20, hp3.GetHp("test-hp-2"));
            Assert.AreEqual(35, hp3.GetHp("test-hp-3"));
        }

        [Test]
        public void SubtractTest()
        {
            HitPoints hp1 = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 10},
            {"test-hp-2", 20},
        });
            HitPoints hp2 = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-3", 35},
        });

            HitPoints hp3 = hp2 - hp1;
            Assert.AreEqual(2, hp3.GetKeys().Count);
            Assert.AreEqual(5, hp3.GetHp("test-hp-1"));
            Assert.AreEqual(35, hp3.GetHp("test-hp-3"));
        }

        [Test]
        public void ComparatorTest()
        {
            HitPoints hpRef = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-3", 35},
        });
            HitPoints hpLow = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 10},
            {"test-hp-2", 20},
        });
            HitPoints hpHigh = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 30},
            {"test-hp-2", 40},
        });
            HitPoints hpEq = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 10},
            {"test-hp-2", 15},
            {"test-hp-3", 25},
        });
            HitPoints hpExactEq = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-3", 35},
        });

            Assert.False(hpRef.ExactEquals(hpEq));
            Assert.True(hpRef == hpEq);
            Assert.True(hpRef >= hpEq);
            Assert.True(hpRef <= hpEq);

            Assert.True(hpRef != hpLow);
            Assert.True(hpRef > hpLow);
            Assert.True(hpRef >= hpLow);

            Assert.True(hpRef != hpHigh);
            Assert.True(hpRef < hpHigh);
            Assert.True(hpRef <= hpHigh);

            Assert.True(hpRef.ExactEquals(hpExactEq));
            Assert.True(hpRef == hpExactEq);
            Assert.True(hpRef >= hpExactEq);
            Assert.True(hpRef <= hpExactEq);
        }

        [Test]
        public void CumulativeValueTest()
        {
            HitPoints hp = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-3", 35},
        });

            Assert.AreEqual(50, hp.CumulativeValue());
        }

        [Test]
        public void CloneTest()
        {
            HitPoints hp = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-2", 35},
        });
            HitPoints hpClone = hp.Clone();

            Assert.AreEqual(hp.GetKeys().Count, hpClone.GetKeys().Count);
            Assert.AreEqual(hp.GetHp("test-hp-1"), hpClone.GetHp("test-hp-1"));
            Assert.AreEqual(hp.GetHp("test-hp-2"), hpClone.GetHp("test-hp-2"));
        }

        [Test]
        public void CumulativeMinMaxTest()
        {
            HitPoints hpHigh = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-3", 35},
        });
            HitPoints hpLow = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 10},
            {"test-hp-2", 20},
        });

            Assert.AreEqual(hpHigh, HitPoints.CumulativeMax(hpLow, hpHigh));
            Assert.AreEqual(hpLow, HitPoints.CumulativeMin(hpLow, hpHigh));
        }

        [Test]
        public void IndividualMinMaxTest()
        {
            HitPoints hpHigh = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-3", 35},
        });
            HitPoints hpLow = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 10},
            {"test-hp-2", 20},
        });

            HitPoints hpMin = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 10},
            {"test-hp-2", 20},
            {"test-hp-3", 35},
        });
            HitPoints hpMax = new HitPoints(new Dictionary<string, int>()
        {
            {"test-hp-1", 15},
            {"test-hp-2", 20},
            {"test-hp-3", 35},
        });

            Assert.True(hpMax.ExactEquals(HitPoints.IndividualMax(hpLow, hpHigh)));
            Assert.True(hpMin.ExactEquals(HitPoints.IndividualMin(hpLow, hpHigh)));
        }
    }
}
