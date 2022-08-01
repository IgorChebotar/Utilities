using SimpleMan.Utilities;

namespace SimpleMan.StateMachine
{
    /// <summary>
    /// Add custom tick rate for each state using this struct
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public struct StateData<TContext>
    {
        public State<TContext> state;
        public float tickRate;

        public StateData(State<TContext> state, float tickRate)
        {
            this.state = state;
            this.tickRate = tickRate.ClampPositive();
        }
    }
}