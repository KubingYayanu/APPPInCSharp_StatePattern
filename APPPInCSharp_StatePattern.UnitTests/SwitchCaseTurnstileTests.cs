﻿using NUnit.Framework;

namespace APPPInCSharp_StatePattern.UnitTests
{
    [TestFixture]
    public class SwitchCaseTurnstileTests : TurnstileTest
    {
        private SwitchCaseTurnstile turnstile;

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