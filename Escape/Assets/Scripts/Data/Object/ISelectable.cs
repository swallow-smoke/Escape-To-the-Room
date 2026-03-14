using UnityEngine;

namespace Data.Object
{
    public interface ISelectable
    {
        public void OnSelect();
        public void OnDeselect();
    }
}