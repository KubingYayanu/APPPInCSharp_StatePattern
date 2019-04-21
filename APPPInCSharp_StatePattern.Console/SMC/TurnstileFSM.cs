namespace APPPInCSharp_StatePattern
{
    public class TurnstileFSM : Turnstile
    {
        public TurnstileFSM(TurnstileController controller)
        {
            this.controller = controller;
        }

        private readonly TurnstileController controller;

        public override void Lock()
        {
            controller.Lock();
        }

        public override void Unlock()
        {
            controller.Unlock();
        }

        public override void Thankyou()
        {
            controller.Thankyou();
        }

        public override void Alarm()
        {
            controller.Alarm();
        }
    }
}