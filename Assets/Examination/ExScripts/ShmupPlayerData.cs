using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShmupData/ShmupSave")]
public class ShmupPlayerData : ScriptableObject
{
    public int PlayerPoints = 0;
    public int PlayerHealth = 0;
}
