using NUnit.Framework;
using Tests.Utils;

namespace Tests.Task
{
    [TestFixture()]
    [Category("TaskTest")]
    public class ActionRefTaskTest
    {
        [SetUp]
        public void SetupHarness()
        {
            TestUtils.Initialize();
        }

        [Test]
        public void CorrectBullets()
        {
            var filename = TestUtils.GetFilePath(@"Content\ActionRefParamChangeSpeed.xml");
            TestUtils.Pattern.Parse(filename);
            Mover mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            Assert.AreEqual(2, TestUtils.Manager.Movers.Count);

            mover = TestUtils.Manager.Movers[1];
            Assert.AreEqual("test", mover.Label);
        }

        [Test]
        public void CorrectSpeedFromParam()
        {
            var filename = TestUtils.GetFilePath(@"Content\ActionRefParamChangeSpeed.xml");
            TestUtils.Pattern.Parse(filename);

            var mover = (Mover)TestUtils.Manager.CreateBullet();
            mover.InitTopNode(TestUtils.Pattern.RootNode);

            TestUtils.MoverManagerStep();

            Assert.AreEqual(2, TestUtils.Manager.Movers.Count);

            mover = TestUtils.Manager.Movers[1];
            Assert.AreEqual("test", mover.Label);
            Assert.AreEqual(5.0f, mover.Speed);

            TestUtils.MoverManagerStep();

            Assert.AreEqual(10.0f, mover.Speed);
        }
    }
}