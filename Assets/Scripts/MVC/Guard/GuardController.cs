using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController
{
    public GuardController(GuardView guardView, GuardModel guardModel)
    {
        guardView.GetGuardController(this);
        speed = guardModel.mvtSpeed;
        maxHealth = guardModel.health;
        rotatingSpeed = guardModel.rotatingSpeed;
        reloadTime = guardModel.reloadTime;
    }

    public Vector3 Movement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 pos = Vector3.MoveTowards(currentPos, targetPos, Time.deltaTime * speed);
        return pos;
    }

    public float GetTargetAngle(Vector3 currentPos, Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - currentPos).normalized;
        return (90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg);
    }
    public GuardView guard { get; }
    private float speed { get; }
    public float maxHealth { get; }
    public float rotatingSpeed { get; }
    public float reloadTime { get; }

}