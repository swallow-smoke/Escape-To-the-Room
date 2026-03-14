using UnityEngine;
using UnityEngine.UI;

namespace Data.Object
{
    [RequireComponent(typeof(Collider2D), typeof(Outline))]
    public abstract class StructureBase : MonoBehaviour, ISelectable
    {
        public Vector2Int position;

        protected virtual void Awake()
        {
            position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        }

        protected virtual void Initialize()
        {
            position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        }

        public virtual void OnSelect()
        {
            
        }

        public virtual void OnDeselect()
        {
            
        }
    }
}