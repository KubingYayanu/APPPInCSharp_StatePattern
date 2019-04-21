namespace APPPInCSharp_StatePattern
{
    public class StatePatternTurnstile
    {
        public StatePatternTurnstile(TurnstileController action)
        {
            turnstileController = action;
        }

        internal static StatePatternTurnstileState lockedState = new LockedTurnstileState();
        internal static StatePatternTurnstileState unlockedState = new UnlockedTurnstileState();
        private TurnstileController turnstileController;
        internal StatePatternTurnstileState state = unlockedState;

        public void Coin()
        {
            state.Coin(this);
        }

        public void Pass()
        {
            state.Pass(this);
        }

        public void SetLocked()
        {
            state = lockedState;
        }

        public void SetUnlocked()
        {
            state = unlockedState;
        }

        public bool IsLocked() => state == lockedState;

        public bool IsUnlocked() => state == unlockedState;

        internal void Thankyou()
        {
            turnstileController.Thankyou();
        }

        internal void Alarm()
        {
            turnstileController.Alarm();
        }

        internal void Lock()
        {
            turnstileController.Lock();
        }

        internal void Unlock()
        {
            turnstileController.Unlock();
        }
    }
}