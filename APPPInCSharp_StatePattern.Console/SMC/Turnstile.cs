//----------------------------------------------
//
// FSM:       Turnstile
// Context:   TurnstileActions
// Exception: FSMError
// Version:
// Generated: ¬P´Á¤é 04/21/2019 at 22:42:23 TST
//
//----------------------------------------------

//----------------------------------------------
//
// class Turnstile
//    This is the Finite State Machine class
//

namespace APPPInCSharp_StatePattern
{
    public class Turnstile : TurnstileActions
    {
        private State itsState;
        private static string itsVersion = "";

        // instance variables for each state
        private Locked itsLockedState;

        private Unlocked itsUnlockedState;

        // constructor
        public Turnstile()
        {
            itsLockedState = new Locked();
            itsUnlockedState = new Unlocked();

            itsState = itsLockedState;

            // Entry functions for: Locked
        }

        // accessor functions

        public string GetVersion()
        {
            return itsVersion;
        }

        public string GetCurrentStateName()
        {
            return itsState.StateName();
        }

        public State GetCurrentState()
        {
            return itsState;
        }

        public State GetItsLockedState()
        {
            return itsLockedState;
        }

        public State GetItsUnlockedState()
        {
            return itsUnlockedState;
        }

        // Mutator functions

        public void SetState(State value)
        {
            itsState = value;
        }

        // event functions - forward to the current State

        public void Coin()
        {
            itsState.Coin(this);
        }

        public void Pass()
        {
            itsState.Pass(this);
        }
    }

    //--------------------------------------------
    //
    // public class State
    //    This is the base State class
    //
    public abstract class State
    {
        public abstract string StateName();

        // default event functions

        public virtual void Coin(Turnstile name)
        {
            throw new FSMError("Coin", name.GetCurrentState());
        }

        public virtual void Pass(Turnstile name)
        {
            throw new FSMError("Pass", name.GetCurrentState());
        }
    }

    //--------------------------------------------
    //
    // class Locked
    //    handles the Locked State and its events
    //
    public class Locked : State
    {
        public override string StateName()
        { return "Locked"; }

        //
        // responds to Pass event
        //
        public override void Pass(Turnstile name)
        {
            name.Alarm();

            // change the state
            name.SetState(name.GetItsLockedState());
        }

        //
        // responds to Coin event
        //
        public override void Coin(Turnstile name)
        {
            name.Unlock();

            // change the state
            name.SetState(name.GetItsUnlockedState());
        }
    }

    //--------------------------------------------
    //
    // class Unlocked
    //    handles the Unlocked State and its events
    //
    public class Unlocked : State
    {
        public override string StateName()
        { return "Unlocked"; }

        //
        // responds to Coin event
        //
        public override void Coin(Turnstile name)
        {
            name.Thankyou();

            // change the state
            name.SetState(name.GetItsUnlockedState());
        }

        //
        // responds to Pass event
        //
        public override void Pass(Turnstile name)
        {
            name.Lock();

            // change the state
            name.SetState(name.GetItsLockedState());
        }
    }
}