using BulletMLI.Enums;
using BulletMLI.Nodes;
using NUnit.Framework;
using Tests.Utils;

namespace Tests.Task.FireTask
{
    [TestFixture()]
    [Category("TaskTest")]
    [Category("FireTaskTest")]
    public class FireTaskSpeedTest
    {
        [SetUp]
        public void SetupHarness()
        {
            TestUtils.Initialize();
        }

        [Test]
        public void BulletCreated()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeed.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);
            mover.Speed = 100;

            TestUtils.MoverManagerStep();

            Assert.AreEqual(TestUtils.Manager.Movers.Count, 2);
        }

        [Test]
        public void BulletDefaultSpeed()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireActionEmpty.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            var myTask = mover.Tasks[0];
            var fireTask = myTask.ChildTasks[0] as BulletMLI.Tasks.FireTask;

            Assert.IsNotNull(fireTask);
            Assert.IsNull(fireTask.SpeedTask);
            Assert.IsNull(fireTask.DirectionTask);
        }

        [Test]
        public void BulletDefaultSpeed1()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireActionEmpty.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);
            mover.Speed = 100f;

            var myTask = mover.Tasks[0];
            var fireTask = myTask.ChildTasks[0] as BulletMLI.Tasks.FireTask;

            Assert.IsNotNull(fireTask);

            var fireTask2 = new BulletMLI.Tasks.FireTask(fireTask.Node as FireNode, fireTask);
            fireTask2.InitTask(mover);

            Assert.IsNull(fireTask2.SpeedTask);
            Assert.IsNull(fireTask2.DirectionTask);
            Assert.AreEqual(100f, fireTask2.FireSpeed);
        }

        [Test]
        public void BulletDefaultSpeed2()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireActionEmpty.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            var bullet = TestUtils.Manager.Movers[1];

            Assert.AreEqual(100f, bullet.Speed);
        }

        [Test]
        public void SpeedDefault()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeed.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            var bullet = TestUtils.Manager.Movers[1];

            Assert.AreEqual(5f, bullet.Speed);
        }

        [Test]
        public void AbsSpeedDefault()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedAbsolute.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);
            mover.Speed = 100;
            TestUtils.MoverManagerStep();

            var bullet = TestUtils.Manager.Movers[1];

            Assert.AreEqual(5f, bullet.Speed);
        }

        [Test]
        public void RelSpeedDefault()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedRelative.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(TestUtils.Pattern.RootNode);
            TestUtils.MoverManagerStep();

            var myTask = mover.Tasks[0];
            var fireTask = myTask.ChildTasks[0] as BulletMLI.Tasks.FireTask;

            Assert.IsNotNull(fireTask);
            Assert.AreEqual(105f, fireTask.FireSpeed);
        }

        [Test]
        public void RelSpeedDefault1()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedRelative.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            var bullet = TestUtils.Manager.Movers[1];

            Assert.AreEqual(105f, bullet.Speed);
        }

        [Test]
        public void RightInitSpeed()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedBulletSpeed.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);
            mover.Speed = 100;

            TestUtils.MoverManagerStep();

            var bullet = TestUtils.Manager.Movers[1];

            Assert.AreEqual(5f, bullet.Speed);
        }

        [Test]
        public void IgnoreSequenceInitSpeed1()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedSequence.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);
            mover.Speed = 100;

            var myTask = mover.Tasks[0];
            var fireTask = myTask.ChildTasks[0] as BulletMLI.Tasks.FireTask;

            Assert.IsNotNull(fireTask);
            Assert.AreEqual(NodeType.sequence, fireTask.SpeedTask.Node.NodeType);
        }

        [Test]
        public void IgnoreSequenceInitSpeed2()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedSequence.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);
            mover.Speed = 100;

            var myTask = mover.Tasks[0];
            var fireTask = myTask.ChildTasks[0] as BulletMLI.Tasks.FireTask;

            Assert.IsNotNull(fireTask);
            Assert.IsNotNull(fireTask.SpeedTask);
            Assert.AreEqual(NodeType.sequence, fireTask.SpeedTask.Node.NodeType);
            Assert.AreEqual(100f, mover.Speed);
            Assert.AreEqual(5f, fireTask.SpeedTask.Node.GetValue(fireTask));
        }

        [Test]
        public void IgnoreSequenceInitSpeed3()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedSequence.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            var myTask = mover.Tasks[0];
            var fireTask = myTask.ChildTasks[0] as BulletMLI.Tasks.FireTask;

            Assert.IsNotNull(fireTask);
            Assert.AreEqual(105f, fireTask.FireSpeed);
        }

        [Test]
        public void IgnoreSequenceInitSpeed4()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedSequence.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            var testDude = TestUtils.Manager.Movers[1];

            Assert.AreEqual(105f, testDude.Speed);
        }

        [Test]
        public void FireAbsSpeed()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedAbsolute.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            var bullet = TestUtils.Manager.Movers[1];

            Assert.AreEqual(5f, bullet.Speed);
        }

        [Test]
        public void FireRelSpeed()
        {
            var filename = TestUtils.GetFilePath(@"Content\FireSpeedRelative.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            var bullet = TestUtils.Manager.Movers[1];

            Assert.AreEqual(105f, bullet.Speed);
        }

        [Test]
        public void NestedBullets()
        {
            var filename = TestUtils.GetFilePath(@"Content\NestedBulletsSpeed.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            // Test the second bullet
            var bullet = TestUtils.Manager.Movers[1];

            Assert.AreEqual(10f, bullet.Speed);
        }

        [Test]
        public void NestedBullets1()
        {
            var filename = TestUtils.GetFilePath(@"Content\NestedBulletsSpeed.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            Assert.AreEqual(3, TestUtils.Manager.Movers.Count);
        }

        [Test]
        public void NestedBullets2()
        {
            var filename = TestUtils.GetFilePath(@"Content\NestedBulletsSpeed.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            // Test the second bullet
            var bullet = TestUtils.Manager.Movers[2];

            Assert.AreEqual(20f, bullet.Speed);
        }
    }
}