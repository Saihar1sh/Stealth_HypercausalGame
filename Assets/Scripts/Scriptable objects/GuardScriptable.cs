using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GuardScriptableObject", menuName = "ScriptableObjects/Guard")]
public class GuardScriptable : ScriptableObject
{
    public GuardView guardPrefab;
    public float mvtSpeed, rotatingSpeed, reloadTime;
    public int health;
}
