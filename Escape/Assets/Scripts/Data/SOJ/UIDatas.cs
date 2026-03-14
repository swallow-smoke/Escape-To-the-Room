using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIDatas", menuName = "UIs/Data")]
public class UIDatas : ScriptableObject
{
    List<GUI> guiDatas = new List<GUI>();
}