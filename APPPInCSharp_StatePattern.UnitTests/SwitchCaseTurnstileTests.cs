using NUnit.Framework;

namespace APPPInCSharp_StatePattern.UnitTests
{
    [TestFixture]
    public class SwitchCaseTurnstileTests
    {
        private SwitchCaseTurnstile turnstile;
        private TurnstileControllerSpoof controllerSpoof;

        private class TurnstileControllerSpoof : TurnstileController
        {
            public bool lockCalled = false;

            public bool unlockCalled = false;

            public bool thankyouCalled = false;

            public bool alarmCalled = false;

            public void Alarm()
            {
                alarmCalled = true;
            }

            public void Lock()
            {
                lockCalled = true;
            }

            public void Thankyou()
            {
                thankyouCalled = true;
            }

            public void Unlock()
            {
                unlockCalled = true;
            }
        }

        [SetUp]
        public void SetUp()
        {
            controllerSpoof = new TurnstileControllerSpoof();
            turnstile = new SwitchCaseTurnstile(controllerSpoof);
        }

        [Test]
        public void InitialConditions()
        {
            Assert.AreEqual(State.LOCKED, turnstile.state);
        }

        [Test]
        public void CoinInLockedState()
        {
            turnstile.state = State.LOCKED;
            turnstile.HandleEvent(Event.COIN);

            Assert.AreEqual(State.UNLOCKED, turnstile.state);
            Assert.IsTrue(controllerSpoof.unlockCalled);
        }

        [Test]
        public void CoinInUnlockedState()
        {
            turnstile.state = State.UNLOCKED;
            turnstile.HandleEvent(Event.COIN);

            Assert.AreEqual(State.UNLOCKED, turnstile.state);
            Assert.IsTrue(controllerSpoof.thankyouCalled);
        }

        [Test]
        public void PassInLockedState()
        {
            turnstile.state = State.LOCKED;
            turnstile.HandleEvent(Event.PASS);

            Assert.AreEqual(State.LOCKED, turnstile.state);
            Assert.IsTrue(controllerSpoof.alarmCalled);
        }

        [Test]
        public void PassInUnlockedState()
        {
            turnstile.state = State.UNLOCKED;
            turnstile.HandleEvent(Event.PASS);

            Assert.AreEqual(State.LOCKED, turnstile.state);
            Assert.IsTrue(controllerSpoof.lockCalled);
        }
    }
}