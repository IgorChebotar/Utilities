namespace SimpleMan.StateMechine
{
    public abstract class State<TContext> : BaseState<TContext>
    {
        //------CONSTRUCTORS
        protected State(TContext context) : base(context)
        {
        }




        //------METHODS
        public abstract void Start();
    }
}