using System;

namespace UI.AutoBinder
{
    public interface IUIProvider
    {
        object GetUIElement(string name, Type type);
    }
}