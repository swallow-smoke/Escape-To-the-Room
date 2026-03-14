using UnityEngine;

namespace Data.Object
{
    public abstract class TileBase : MonoBehaviour
    {
        public Vector2Int Position { get; private set; }
        public TileType TileType { get; private set; }
        public LayerMask TileLayer { get; private set; }

        protected virtual void Initialize(Vector2Int position)
        {
            Position = position;
        }

        protected virtual void Awake()
        {
            Initialize(new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)));
        }
    }

    public enum TileType
    {
        Wood,
        Stone,
        Water,
        Ice,
        Grass
    }
}