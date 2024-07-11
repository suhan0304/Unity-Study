using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tab_Data", menuName = "Tab_Data", order = 0)]
public class TabData : ScriptableObject
{
    [SerializeField] 
    public List<CardData> tabData = new List<CardData>();
}
