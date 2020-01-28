using BulletMLI;
using NUnit.Framework;
using System;
using Tests.Utils;

namespace Tests.Task
{
    [TestFixture()]
    [Category("TaskTest")]
    public class ChangeDirectionTaskTest
    {
        [SetUp]
        public void SetupHarness()
        {
            TestUtils.Initialize();
        }

        [Test]
        public void ChangeDirectionAbsSetupCorrect()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionAbs.xml");
            TestUtils.Pattern.Parse(filename);
            TestUtils.Player.Position = new Vector2(0, 100);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(0, (int)direction);
        }

        [Test]
        public void ChangeDirectionAbs()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionAbs.xml");
            TestUtils.Pattern.Parse(filename);
            TestUtils.Player.Position = new Vector2(0, 100);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();
            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(45, (int)direction);
        }

        [Test]
        public void ChangeDirectionAbs1()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionAbs.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();
            TestUtils.MoverManagerStep();

            float direction = MathHelper.ToDegrees(mover.Rotation);

            Assert.AreEqual(90, (int)direction);
        }

        [Test]
        public void ChangeDirectionAbs2()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionAbs2.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            Assert.AreEqual(2, TestUtils.Manager.Movers.Count);

            TestUtils.MoverManagerStep();
            TestUtils.MoverManagerStep();
            TestUtils.MoverManagerStep();
            TestUtils.MoverManagerStep();

            var bullet = TestUtils.Manager.Movers[1];
            var direction = MathHelper.ToDegrees(bullet.Rotation);

            Assert.AreEqual(90, (int)direction);
        }

        [Test]
        public void ChangeDirectionAimSetupCorrect()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionAim.xml");
            TestUtils.Pattern.Parse(filename);
            TestUtils.Player.Position = new Vector2(100f, 0f);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(0, (int)direction);
        }

        [Test]
        public void ChangeDirectionAim()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionAim.xml");
            TestUtils.Pattern.Parse(filename);
            TestUtils.Player.Position = new Vector2(0f, 100f);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(90, (int)direction);
        }

        [Test]
        public void ChangeDirectionAim1()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionAim.xml");
            TestUtils.Pattern.Parse(filename);
            TestUtils.Player.Position = new Vector2(0f, 100f);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            var direction = mover.Rotation * (180 / (float)Math.PI);
            Assert.AreEqual(90, (int)direction);

            TestUtils.MoverManagerStep();

            direction = mover.Rotation * (180 / (float)Math.PI);
            Assert.AreEqual(180, (int)direction);
        }

        [Test]
        public void ChangeDirectionRelSetupCorrect()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(0, (int)direction);
        }

        [Test]
        public void ChangeDirectionRel()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();
            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(-45, (int)direction);
        }

        [Test]
        public void ChangeDirectionRel1()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();
            TestUtils.MoverManagerStep();

            float direction = mover.Rotation * 180 / (float)Math.PI;
            Assert.AreEqual(-90, (int)direction);
        }

        [Test]
        public void ChangeDirectionSeqSetupCorrect()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionSeq.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(0, (int)direction);
        }

        [Test]
        public void ChangeDirectionSeq()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionSeq.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();
            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(90, (int)direction);
        }

        [Test]
        public void ChangeDirectionSeq1()
        {
            var filename = TestUtils.GetFilePath(@"Content\ChangeDirectionSeq.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();
            TestUtils.MoverManagerStep();
            float direction = mover.Rotation * 180f / (float)Math.PI;
            Assert.AreEqual(180, (int)direction);
        }

        [Test]
        public void ChangeDirectionRepeatAim()
        {
            var filename = TestUtils.GetFilePath(@"Content\Test\Task\ChangeDirectionRepeatAim.xml");
            TestUtils.Pattern.Parse(filename);
            TestUtils.Player.Position = new Vector2(0f, 100f);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            var targetMover = TestUtils.Manager.Movers[1];

            var direction = MathHelper.ToDegrees(targetMover.Rotation);
            Assert.AreEqual(180, (int)direction);
        }
    }
}