namespace SimpleMan.StateMachine
{
    /// <summary>
    /// Inherit your custom state from this class
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class State<TContext>
    {
        //------PROPERTIES
        /// <summary>
        /// Owner of the current state
        /// </summary>
        public TContext Context { get; internal set; }

        /// <summary>
        /// State machine owner
        /// </summary>
        public StateMachine<TContext> MachineOwner { get; internal set; }




        //------METHODS
        public abstract void Start();

        public abstract void Tick();

        public abstract void Stop();
    }
}