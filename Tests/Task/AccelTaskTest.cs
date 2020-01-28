using BulletMLI;
using BulletMLI.Enums;
using BulletMLI.Nodes;
using BulletMLI.Tasks;
using NUnit.Framework;
using Tests.Utils;

namespace Tests.Task
{
    [TestFixture()]
    [Category("TaskTest")]
    public class AccelTaskTest
    {
        [SetUp]
        public void SetupHarness()
        {
            TestUtils.Initialize();
        }

        [Test]
        public void CorrectSpeedAbs()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelAbs.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);
            Assert.AreEqual(20f, mover.Acceleration.X);
            Assert.AreEqual(40f, mover.Acceleration.Y);
        }

        [Test]
        public void CorrectSpeedAbs1()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelAbs.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            Assert.AreEqual(19f, mover.Acceleration.X);
            Assert.AreEqual(38f, mover.Acceleration.Y);
        }

        [Test]
        public void CorrectSpeedAbs2()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelAbs.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            for (int i = 0; i < 10; i++)
            {
                TestUtils.MoverManagerStep();
            }

            Assert.AreEqual(10f, mover.Acceleration.X);
            Assert.AreEqual(20f, mover.Acceleration.Y);
        }

        [Test]
        public void CorrectSpeedRel()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            Assert.AreEqual(21f, mover.Acceleration.X);
            Assert.AreEqual(42f, mover.Acceleration.Y);
        }

        [Test]
        public void CorrectSpeedRel1()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            for (int i = 0; i < 10; i++)
            {
                TestUtils.MoverManagerStep();
            }

            Assert.AreEqual(30f, mover.Acceleration.X);
            Assert.AreEqual(60f, mover.Acceleration.Y);
        }

        [Test]
        public void CorrectSpeedRel2()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            BulletMLTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel);
            Assert.IsNotNull(myTask);
        }

        [Test]
        public void CorrectSpeedRel3()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            AccelTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel) as AccelTask;
            Assert.IsNotNull(myTask);
        }

        [Test]
        public void CorrectSpeedRel4()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            AccelTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel) as AccelTask;
            Assert.AreEqual(1f, myTask.Acceleration.X);
            Assert.AreEqual(2f, myTask.Acceleration.Y);
        }

        [Test]
        public void CorrectSpeedRel5()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            AccelTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel) as AccelTask;
            BulletMLNode myNode = myTask.Node.GetChild(NodeName.horizontal);
            Assert.AreEqual(10f, myNode.GetValue(myTask));
        }

        [Test]
        public void CorrectSpeedRel6()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            AccelTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel) as AccelTask;
            BulletMLNode myNode = myTask.Node.GetChild(NodeName.vertical);
            Assert.AreEqual(NodeType.relative, myNode.NodeType);
        }

        [Test]
        public void CorrectSpeedRel7()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            AccelTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel) as AccelTask;
            BulletMLNode myNode = myTask.Node.GetChild(NodeName.horizontal);
            Assert.AreEqual(NodeType.relative, myNode.NodeType);
        }

        [Test]
        public void CorrectSpeedRel8()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            AccelTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel) as AccelTask;
            BulletMLNode myNode = myTask.Node.GetChild(NodeName.vertical);
            Assert.AreEqual(20f, myNode.GetValue(myTask));
        }

        [Test]
        public void CorrectSpeedRel9()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelRel.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            AccelTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel) as AccelTask;
            Assert.AreEqual(10f, myTask.Duration);
        }

        [Test]
        public void CorrectSpeedSeq()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelSeq.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            AccelTask myTask = mover.FindTaskByLabelAndName("test", NodeName.accel) as AccelTask;
            Assert.AreEqual(1f, myTask.Acceleration.X);
            Assert.AreEqual(2f, myTask.Acceleration.Y);
        }

        [Test]
        public void CorrectSpeedSeq1()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelSeq.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            Assert.AreEqual(21f, mover.Acceleration.X);
            Assert.AreEqual(42f, mover.Acceleration.Y);
        }

        [Test]
        public void CorrectSpeedSeq2()
        {
            var filename = TestUtils.GetFilePath(@"Content\AccelSeq.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.Acceleration = new Vector2(20f, 40f);
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            for (int i = 0; i < 10; i++)
            {
                TestUtils.MoverManagerStep();
            }

            Assert.AreEqual(30f, mover.Acceleration.X);
            Assert.AreEqual(60f, mover.Acceleration.Y);
        }
    }
}