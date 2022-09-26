namespace SimpleMan.Containers
{
    public struct FLastFrameActions<T> 
    {
        //------FIELDS
        T[] instancesRegisteredInLastFrame;
        T[] instancesUnregisteredInLastFrame;




        //------CONSTRUCTORS
        public FLastFrameActions(T[] instancesRegisteredInLastFrame, T[] instancesUnregisteredInLastFrame)
        {
            this.instancesRegisteredInLastFrame = instancesRegisteredInLastFrame;
            this.instancesUnregisteredInLastFrame = instancesUnregisteredInLastFrame;
        }
    }
}