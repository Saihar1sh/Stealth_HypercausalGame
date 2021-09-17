using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController
{
    public GuardController(GuardView guardView, GuardModel _guardModel)
    {
        guardView.GetGuardController(this);
        guardModel = _guardModel;
        speed = _guardModel.mvtSpeed;
        maxHealth = _guardModel.health;
        rotatingSpeed = _guardModel.rotatingSpeed;
        reloadTime = _guardModel.reloadTime;
        damage = _guardModel.damage;
        speedMultiplier = 1;
    }

    public Vector3 Movement(Vector3 currentPos, Vector3 targetPos)
    {
        Vector3 pos = Vector3.MoveTowards(currentPos, targetPos, Time.deltaTime * speed * speedMultiplier);
        return pos;
    }

    public void SetSpeedMultiplier(float speedMutipl)
    {
        speedMultiplier = speedMutipl;
    }

    /*    public void SetRotatingSpeed(float rotSpeedMultiplier)
        {
            float rotSpeed = rotatingSpeed;
            rotatingSpeed = rotSpeed * rotatingSpeedMultiplier;
        }
        public void ResetRotSpeed()
        {
            rotatingSpeed = guardModel.rotatingSpeed;
        }
    */
    public float GetTargetAngle(Vector3 currentPos, Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - currentPos).normalized;
        return (90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg);
    }
    public GuardView guard { get; }
    private GuardModel guardModel { get; }
    private float speed { get; }
    private float speedMultiplier { get; set; }
    public float maxHealth { get; }
    public float rotatingSpeed { get; private set; }
    public float rotatingSpeedMultiplier { get; private set; }

    public float reloadTime { get; }
    public float damage { get; }
}