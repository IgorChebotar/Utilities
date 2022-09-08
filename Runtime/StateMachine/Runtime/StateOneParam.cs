namespace SimpleMan.StateMechine
{
    public abstract class StateOneParam<TContext, T0> : BaseState<TContext>
    {
        //------CONSTRUCTORS
        protected StateOneParam(TContext context) : base(context)
        {
        }




        //------METHODS
        public abstract void Start(T0 arg0);
    }
}