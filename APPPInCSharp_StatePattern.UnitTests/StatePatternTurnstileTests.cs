using NUnit.Framework;

namespace APPPInCSharp_StatePattern.UnitTests
{
    [TestFixture]
    public class StatePatternTurnstileTests : TurnstileTest
    {
        private StatePatternTurnstile turnstile;

        [SetUp]
        public void SetUp()
        {
            controllerSpoof = new TurnstileControllerSpoof();
            turnstile = new StatePatternTurnstile(controllerSpoof);
        }

        [Test]
        public void InitialConditions()
        {
            Assert.IsTrue(turnstile.IsUnlocked());
        }

        [Test]
        public void CoinInLockedState()
        {
            turnstile.SetLocked();
            turnstile.Coin();

            Assert.IsTrue(turnstile.IsUnlocked());
            Assert.IsTrue(controllerSpoof.unlockCalled);
        }

        [Test]
        public void CoinInUnlockedState()
        {
            turnstile.SetUnlocked();
            turnstile.Coin();

            Assert.IsTrue(turnstile.IsUnlocked());
            Assert.IsTrue(controllerSpoof.thankyouCalled);
        }

        [Test]
        public void PassInLockedState()
        {
            turnstile.SetLocked();
            turnstile.Pass();

            Assert.IsTrue(turnstile.IsLocked());
            Assert.IsTrue(controllerSpoof.alarmCalled);
        }

        [Test]
        public void PassInUnlockedState()
        {
            turnstile.SetUnlocked();
            turnstile.Pass();

            Assert.IsTrue(turnstile.IsLocked());
            Assert.IsTrue(controllerSpoof.lockCalled);
        }
    }
}