using System;

namespace UI.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class BindAttribute : Attribute
    {
        public string viewName { get; }

        public BindAttribute(string ViewName = null)
        {
            viewName = ViewName;
        }
    }
}