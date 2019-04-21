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

            AddTransition(State.LOCKED, Event.COIN, State.UNLOCKED, unlock);
            AddTransition(State.LOCKED, Event.PASS, State.LOCKED, alarm);
            AddTransition(State.UNLOCKED, Event.COIN, State.UNLOCKED, thankYou);
            AddTransition(State.UNLOCKED, Event.PASS, State.LOCKED, lockAction);
        }

        //Private
        internal State state = State.LOCKED;

        private IList<Transition> transitions = new List<Transition>();

        public void HandleEvent(Event e)
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

        private void AddTransition(State start, Event e, State end, Action action)
        {
            transitions.Add(new Transition(start, e, end, action));
        }

        private class Transition
        {
            public Transition(State start, Event e, State end, Action a)
            {
                startState = start;
                trigger = e;
                endState = end;
                action = a;
            }

            public State startState;
            public Event trigger;
            public State endState;
            public Action action;
        }
    }
}