using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Slot", menuName = "SlotData")]
public class SlotsSO : ScriptableObject
{
    public enum TypeOf { instrument, musician, agitation}
    public TypeOf typeOfSlot;
    public enum TypeOfMusician { guitarist, baraban, bas}
    public TypeOfMusician typyOfMusician;
    [Space]
    public Sprite slotSprite;
    public string slotName;
    public float slotCost;
    public string slotBustDiscription;
    public int[] slotChangeValues = new int[2];
}