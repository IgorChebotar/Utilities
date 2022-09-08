namespace SimpleMan.StateMechine
{
    public abstract class StateTwoParams<TContext, T0, T1> : BaseState<TContext>
    {
        //------CONSTRUCTORS
        protected StateTwoParams(TContext context) : base(context)
        {
        }




        //------METHODS
        public abstract void Start(T0 arg0, T1 arg1);
    }
}