namespace SimpleMan.StateMechine
{
    public abstract class BaseState<TContext>
    {
        //------FIELDS
        protected readonly TContext _context;




        //------CONSTRUCTORS
        public BaseState(TContext context)
        {
            _context = context;
        }




        //------METHODS
        public abstract void Stop();
        public abstract void Tick();
    }
}