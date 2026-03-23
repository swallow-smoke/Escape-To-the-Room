using System.Collections.Generic;
using Managers.Base;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers
{
    public class GameManager : SingletonManagerBase<GameManager>
    {
        [SerializeField] public Tilemap ground;
        [SerializeField] public Tilemap structure;
    }
}