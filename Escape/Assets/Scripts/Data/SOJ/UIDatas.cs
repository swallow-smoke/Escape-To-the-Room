using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "UIDatas", menuName = "UIs/Data")]
public class UIDatas : ScriptableObject
{
    public List<UIData> guiDatas;
}

[System.Serializable]
public class UIData
{
    public Type type;
    public UIBase ui;
}