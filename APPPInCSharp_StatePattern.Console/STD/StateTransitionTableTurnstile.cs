using System;
using System.Collections.Generic;

namespace APPPInCSharp_StatePattern
{
    public class StateTransitionTableTurnstile
    {
        public StateTransitionTableTurnstile(TurnstileController controller)
        {
            Action unlock = () => controller.Unlock();
            Action alarm = () => controller.Alarm();
            Action thankYou = () => controller.Thankyou();
            Action lockAction = () => controller.Lock();

            AddTransition(TurnstileState.LOCKED, TurnstileEvent.COIN, TurnstileState.UNLOCKED, unlock);
            AddTransition(TurnstileState.LOCKED, TurnstileEvent.PASS, TurnstileState.LOCKED, alarm);
            AddTransition(TurnstileState.UNLOCKED, TurnstileEvent.COIN, TurnstileState.UNLOCKED, thankYou);
            AddTransition(TurnstileState.UNLOCKED, TurnstileEvent.PASS, TurnstileState.LOCKED, lockAction);
        }

        //Private
        internal TurnstileState state = TurnstileState.LOCKED;

        private IList<Transition> transitions = new List<Transition>();

        public void HandleEvent(TurnstileEvent e)
        {
            foreach (var transition in transitions)
            {
                if (state == transition.startState && e == transition.trigger)
                {
                    state = transition.endState;
                    transition.action();
                }
            }
        }

        private void AddTransition(TurnstileState start, TurnstileEvent e, TurnstileState end, Action action)
        {
            transitions.Add(new Transition(start, e, end, action));
        }

        private class Transition
        {
            public Transition(TurnstileState start, TurnstileEvent e, TurnstileState end, Action a)
            {
                startState = start;
                trigger = e;
                endState = end;
                action = a;
            }

            public TurnstileState startState;
            public TurnstileEvent trigger;
            public TurnstileState endState;
            public Action action;
        }
    }
}