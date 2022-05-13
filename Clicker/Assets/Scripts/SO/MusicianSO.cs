using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Musician", menuName = "MusicianData")]
public class MusicianSO : ScriptableObject
{
    public Sprite musicianSprite;
    public string musicianName;
    public int musicianCost;
    public int musicianBuff;
}