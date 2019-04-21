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
        internal TurnstileState state = TurnstileState.LOCKED;

        private TurnstileController turnstileController;

        public void HandleEvent(TurnstileEvent e)
        {
            switch (state)
            {
                case TurnstileState.LOCKED:
                    switch (e)
                    {
                        case TurnstileEvent.COIN:
                            state = TurnstileState.UNLOCKED;
                            turnstileController.Unlock();
                            break;
                        case TurnstileEvent.PASS:
                            turnstileController.Alarm();
                            break;
                    }
                    break;
                case TurnstileState.UNLOCKED:
                    switch (e)
                    {
                        case TurnstileEvent.COIN:
                            turnstileController.Thankyou();
                            break;
                        case TurnstileEvent.PASS:
                            state = TurnstileState.LOCKED;
                            turnstileController.Lock();
                            break;
                    }
                    break;
            }
        }
    }
}