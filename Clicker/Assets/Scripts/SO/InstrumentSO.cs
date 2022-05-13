using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Instrument", menuName = "InstrumentData")]
public class InstrumentSO : ScriptableObject
{
    public Sprite instrumentSprite;
    public string instrumentName;
    public int instrumentCost;
    public int instrumentBuff;
}