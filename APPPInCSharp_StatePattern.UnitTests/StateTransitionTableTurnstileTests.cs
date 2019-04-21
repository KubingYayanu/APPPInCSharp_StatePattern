using NUnit.Framework;

namespace APPPInCSharp_StatePattern.UnitTests
{
    [TestFixture]
    public class StateTransitionTableTurnstileTests : TurnstileTest
    {
        private StateTransitionTableTurnstile turnstile;

        [SetUp]
        public void SetUp()
        {
            controllerSpoof = new TurnstileControllerSpoof();
            turnstile = new StateTransitionTableTurnstile(controllerSpoof);
        }

        [Test]
        public void InitialConditions()
        {
            Assert.AreEqual(TurnstileState.LOCKED, turnstile.state);
        }

        [Test]
        public void CoinInLockedState()
        {
            turnstile.state = TurnstileState.LOCKED;
            turnstile.HandleEvent(TurnstileEvent.COIN);

            Assert.AreEqual(TurnstileState.UNLOCKED, turnstile.state);
            Assert.IsTrue(controllerSpoof.unlockCalled);
        }

        [Test]
        public void CoinInUnlockedState()
        {
            turnstile.state = TurnstileState.UNLOCKED;
            turnstile.HandleEvent(TurnstileEvent.COIN);

            Assert.AreEqual(TurnstileState.UNLOCKED, turnstile.state);
            Assert.IsTrue(controllerSpoof.thankyouCalled);
        }

        [Test]
        public void PassInLockedState()
        {
            turnstile.state = TurnstileState.LOCKED;
            turnstile.HandleEvent(TurnstileEvent.PASS);

            Assert.AreEqual(TurnstileState.LOCKED, turnstile.state);
            Assert.IsTrue(controllerSpoof.alarmCalled);
        }

        [Test]
        public void PassInUnlockedState()
        {
            turnstile.state = TurnstileState.UNLOCKED;
            turnstile.HandleEvent(TurnstileEvent.PASS);

            Assert.AreEqual(TurnstileState.LOCKED, turnstile.state);
            Assert.IsTrue(controllerSpoof.lockCalled);
        }
    }
}