using System;
using System.Reflection;
using UI;
using UI.Attributes;


namespace UI.AutoBinder
{
    public static class UIBinder
    {
        public static void Bind(object target, IUIProvider provider)
        {
            var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                var attr = field.GetCustomAttribute<BindAttribute>();
                if (attr != null)
                {
                    string uiName = attr.viewName ?? field.Name;
                    var uiElement = provider.GetUIElement(uiName, field.FieldType);

                    if (uiElement != null)
                    {
                        field.SetValue(target, uiElement);
                    }
                }
            }
        }
    }
}