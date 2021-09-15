using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardModel
{
    public GuardModel(GuardScriptable guard)
    {
        guardPrefab = guard.guardPrefab;
        mvtSpeed = guard.mvtSpeed;
        rotatingSpeed = guard.rotatingSpeed;
        health = guard.health;
        reloadTime = guard.reloadTime;
        damage = guard.damage;
    }

    public GuardView guardPrefab { get; }
    public float mvtSpeed { get; }
    public float rotatingSpeed { get; }
    public int health { get; }
    public float reloadTime { get; }
    public float damage { get; }

}
