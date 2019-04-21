using System;

namespace APPPInCSharp_StatePattern
{
    public class FSMError : ApplicationException
    {
        public FSMError(string theEvent, State state) : base(string.Format(message, state.StateName(), theEvent))
        {
        }

        private static string message = "Undefined transition from state: {0} with event: {1}.";
    }
}