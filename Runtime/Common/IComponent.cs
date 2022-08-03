using UnityEngine;


namespace SimpleMan.Utilities
{
    public interface IComponent
    {
        //------PROPERTIES
        GameObject SelfGameObject { get; }
        bool PrintLogs { get; set; }
    }
}