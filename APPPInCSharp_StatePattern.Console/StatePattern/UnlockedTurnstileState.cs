namespace APPPInCSharp_StatePattern
{
    internal class UnlockedTurnstileState : StatePatternTurnstileState
    {
        public void Coin(StatePatternTurnstile t)
        {
            t.Thankyou();
        }

        public void Pass(StatePatternTurnstile t)
        {
            t.SetLocked();
            t.Lock();
        }
    }
}