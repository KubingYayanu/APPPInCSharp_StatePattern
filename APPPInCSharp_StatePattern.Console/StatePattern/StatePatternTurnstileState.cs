namespace APPPInCSharp_StatePattern
{
    public interface StatePatternTurnstileState
    {
        void Coin(StatePatternTurnstile t);

        void Pass(StatePatternTurnstile t);
    }
}