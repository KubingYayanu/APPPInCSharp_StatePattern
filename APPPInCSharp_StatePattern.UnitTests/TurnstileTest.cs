namespace APPPInCSharp_StatePattern.UnitTests
{
    public abstract class TurnstileTest
    {
        protected TurnstileControllerSpoof controllerSpoof;

        protected class TurnstileControllerSpoof : TurnstileController
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
    }
}