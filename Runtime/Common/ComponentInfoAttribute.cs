using System;


namespace SimpleMan.Utilities
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentInfoAttribute : Attribute
    {
        //------PROPERTIES
        public string Description { get; set; }
        public string IconPath { get; set; }




        //------CONSTRUCTORS
        public ComponentInfoAttribute(string description)
        {
            Description = description;
        }

        public ComponentInfoAttribute(string description, string iconPath)
        {
            Description = description;
            IconPath = iconPath;
        }
    }
}