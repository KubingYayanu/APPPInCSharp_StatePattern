using NUnit.Framework;

namespace APPPInCSharp_StatePattern.UnitTests
{
    [TestFixture]
    public class SMCTurnstileTests : TurnstileTest
    {
        private Turnstile turnstile;

        [SetUp]
        public void SetUp()
        {
            controllerSpoof = new TurnstileControllerSpoof();
            turnstile = new TurnstileFSM(controllerSpoof);
        }

        [Test]
        public void InitialConditions()
        {
            Assert.IsTrue(turnstile.GetCurrentState() is Locked);
        }

        [Test]
        public void CoinInLockedState()
        {
            turnstile.SetState(new Locked());
            turnstile.Coin();

            Assert.IsTrue(turnstile.GetCurrentState() is Unlocked);
            Assert.IsTrue(controllerSpoof.unlockCalled);
        }

        [Test]
        public void CoinInUnlockedState()
        {
            turnstile.SetState(new Unlocked());
            turnstile.Coin();

            Assert.IsTrue(turnstile.GetCurrentState() is Unlocked);
            Assert.IsTrue(controllerSpoof.thankyouCalled);
        }

        [Test]
        public void PassInLockedState()
        {
            turnstile.SetState(new Locked());
            turnstile.Pass();

            Assert.IsTrue(turnstile.GetCurrentState() is Locked);
            Assert.IsTrue(controllerSpoof.alarmCalled);
        }

        [Test]
        public void PassInUnlockedState()
        {
            turnstile.SetState(new Unlocked());
            turnstile.Pass();

            Assert.IsTrue(turnstile.GetCurrentState() is Locked);
            Assert.IsTrue(controllerSpoof.lockCalled);
        }
    }
}