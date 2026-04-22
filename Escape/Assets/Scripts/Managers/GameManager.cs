using System.Collections.Generic;
using Controller;
using Data;
using Managers.Base;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers
{
    public class GameManager : SingletonManagerBase<GameManager>
    {
        [SerializeField] public List<Tilemap> tilemaps;
        [SerializeField] public GameFlag GameFlag;
        [SerializeField] public InventoryController InventoryController;
        [SerializeField] public PlayerController PlayerController;
    }
}