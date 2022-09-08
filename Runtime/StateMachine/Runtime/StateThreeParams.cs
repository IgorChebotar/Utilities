namespace SimpleMan.StateMechine
{
    public abstract class StateThreeParams<TContext, T0, T1, T2> : BaseState<TContext>
    {
        //------CONSTRUCTORS
        protected StateThreeParams(TContext context) : base(context)
        {
        }




        //------METHODS
        public abstract void Start(T0 arg0, T1 arg1, T2 arg2);
    }
}