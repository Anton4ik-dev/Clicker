using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Slot", menuName = "SlotData")]
public class SlotsSO : ScriptableObject
{
    public enum TypeOf { instrument, musician, agitation, drug}
    public TypeOf typeOfSlot;
    public enum TypeOfMusician { guitarist, baraban, bas, none}
    public TypeOfMusician typeOfMusician;
    [Space]
    public Sprite slotSprite;
    public string slotName;
    public float slotCost;
    public string slotBustDiscription;
    public int[] slotChangeValues = new int[2];
}