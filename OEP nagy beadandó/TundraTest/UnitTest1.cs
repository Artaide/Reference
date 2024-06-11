using Tundra;

namespace TundraTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OwlVsLemmingTest()
        {
            SnowyOwl o = new SnowyOwl("owls", 10);
            Lemming l = new Lemming("lemmings", 90);

            o.Reproduce(1);
            l.Reproduce(1);
            Assert.AreEqual(10, o.Specimens);
            Assert.AreEqual(90, l.Specimens);

            o.Attack(l);
            Assert.AreEqual(10, o.Specimens);
            Assert.AreEqual(63, l.Specimens);

            o.Reproduce(2);
            l.Reproduce(2);
            Assert.AreEqual(10, o.Specimens);
            Assert.AreEqual(126, l.Specimens);

            o.Attack(l);
            Assert.AreEqual(10, o.Specimens);
            Assert.AreEqual(89, l.Specimens);

            o.Reproduce(3);
            l.Reproduce(3);
            Assert.AreEqual(14, o.Specimens);
            Assert.AreEqual(89, l.Specimens);
        }
        [TestMethod]
        public void OwlVsHareTest()
        {
            SnowyOwl o = new SnowyOwl("owls", 10);
            ArcticHare h = new ArcticHare("hares", 50);

            o.Reproduce(1);
            h.Reproduce(1);
            Assert.AreEqual(10, o.Specimens);
            Assert.AreEqual(50, h.Specimens);

            o.Attack(h);
            Assert.AreEqual(10, o.Specimens);
            Assert.AreEqual(40, h.Specimens);

            o.Reproduce(2);
            h.Reproduce(2);
            Assert.AreEqual(10, o.Specimens);
            Assert.AreEqual(60, h.Specimens);

            o.Attack(h);
            Assert.AreEqual(10, o.Specimens);
            Assert.AreEqual(48, h.Specimens);

            o.Reproduce(3);
            h.Reproduce(3);
            Assert.AreEqual(14, o.Specimens);
            Assert.AreEqual(48, h.Specimens);

            o.Attack(h);
            Assert.AreEqual(1, o.Specimens);
            Assert.AreEqual(39, h.Specimens);
        }
        [TestMethod]
        public void OwlVsMooseTest()
        {
            SnowyOwl o = new SnowyOwl("owls", 10);
            Moose m = new Moose("moose", 70);

            o.Reproduce(3);
            m.Reproduce(3);
            Assert.AreEqual(14, o.Specimens);
            Assert.AreEqual(70, m.Specimens);

            o.Attack(m);
            Assert.AreEqual(0, o.Specimens);
            Assert.AreEqual(70, m.Specimens);

            o.Reproduce(3);
            m.Reproduce(4);
            Assert.AreEqual(0, o.Specimens);
            Assert.AreEqual(84, m.Specimens);
        }
        [TestMethod]
        public void FoxVsLemmingTest()
        {
            ArcticFox f = new ArcticFox("foxes", 10);
            Lemming l = new Lemming("Lemmings", 90);

            f.Reproduce(2);
            l.Reproduce(2);
            Assert.AreEqual(10, f.Specimens);
            Assert.AreEqual(180, l.Specimens);

            f.Attack(l);
            Assert.AreEqual(4, f.Specimens);
            Assert.AreEqual(171, l.Specimens);

            f.Reproduce(3);
            l.Reproduce(3);
            Assert.AreEqual(7, f.Specimens);
            Assert.AreEqual(171, l.Specimens);
        }
        [TestMethod]
        public void FoxVsHareTest()
        {
            ArcticFox f = new ArcticFox("foxes", 10);
            ArcticHare h = new ArcticHare("Lemmings", 60);

            f.Attack(h);
            Assert.AreEqual(10, f.Specimens);
            Assert.AreEqual(39, h.Specimens);

            f.Reproduce(2);
            h.Reproduce(2);
            Assert.AreEqual(10, f.Specimens);
            Assert.AreEqual(58, h.Specimens);

            f.Attack(h);
            Assert.AreEqual(10, f.Specimens);
            Assert.AreEqual(38, h.Specimens);

            f.Reproduce(3);
            h.Reproduce(3);
            Assert.AreEqual(16, f.Specimens);
            Assert.AreEqual(38, h.Specimens);

            f.Attack(h);
            Assert.AreEqual(2, f.Specimens);
            Assert.AreEqual(25, h.Specimens);
        }
        [TestMethod]
        public void FoxVsMooseTest()
        {
            ArcticFox f = new ArcticFox("foxes", 10);
            Moose m = new Moose("moose", 70);

            f.Reproduce(3);
            m.Reproduce(3);
            Assert.AreEqual(16, f.Specimens);
            Assert.AreEqual(70, m.Specimens);

            f.Attack(m);
            Assert.AreEqual(0, f.Specimens);
            Assert.AreEqual(70, m.Specimens);

            f.Reproduce(4);
            m.Reproduce(4);
            Assert.AreEqual(0, f.Specimens);
            Assert.AreEqual(84, m.Specimens);
        }
        [TestMethod]
        public void BearVsMooseTest()
        {
            PolarBear b = new PolarBear("bears", 10);
            Moose m = new Moose("moose", 80);

            b.Attack(m);
            Assert.AreEqual(10, b.Specimens);
            Assert.AreEqual(60, m.Specimens);

            b.Reproduce(8);
            m.Reproduce(8);
            Assert.AreEqual(12, b.Specimens);
            Assert.AreEqual(72, m.Specimens);

            b.Attack(m);
            Assert.AreEqual(12, b.Specimens);
            Assert.AreEqual(54, m.Specimens);
        }
    }
}