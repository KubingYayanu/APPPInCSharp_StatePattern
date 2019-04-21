namespace APPPInCSharp_StatePattern
{
    public class SwitchCaseTurnstile
    {
        public SwitchCaseTurnstile(TurnstileController action)
        {
            turnstileController = action;
        }

        //Private
        //Set [assembly: InternalsVisibleTo("APPPInCSharp_StatePattern.UnitTests")]
        internal State state = State.LOCKED;

        private TurnstileController turnstileController;

        public void HandleEvent(Event e)
        {
            switch (state)
            {
                case State.LOCKED:
                    switch (e)
                    {
                        case Event.COIN:
                            state = State.UNLOCKED;
                            turnstileController.Unlock();
                            break;
                        case Event.PASS:
                            turnstileController.Alarm();
                            break;
                    }
                    break;
                case State.UNLOCKED:
                    switch (e)
                    {
                        case Event.COIN:
                            turnstileController.Thankyou();
                            break;
                        case Event.PASS:
                            state = State.LOCKED;
                            turnstileController.Lock();
                            break;
                    }
                    break;
            }
        }
    }
}