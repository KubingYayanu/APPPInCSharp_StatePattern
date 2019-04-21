namespace APPPInCSharp_StatePattern
{
    internal class LockedTurnstileState : StatePatternTurnstileState
    {
        public void Coin(StatePatternTurnstile t)
        {
            t.SetUnlocked();
            t.Unlock();
        }

        public void Pass(StatePatternTurnstile t)
        {
            t.Alarm();
        }
    }
}