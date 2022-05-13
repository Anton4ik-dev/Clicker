using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Agitation", menuName = "AgitationData")]
public class AgitationSO : ScriptableObject
{
    public Sprite agitationSprite;
    public string agitationName;
    public int agitationCost;
    public int agitationBuff;
}