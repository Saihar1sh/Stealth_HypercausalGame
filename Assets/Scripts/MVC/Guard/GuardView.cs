using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardView : MonoBehaviour
{
    private GuardController guardController;
    private GuardModel guardModel;

    private float maxHealth, health, reloadTime, damage;

    private bool canMove = true;

    [SerializeField]
    private GuardScriptable guardScriptable;

    [SerializeField]
    private PlayerView player;


    private void Awake()
    {
    }
    private void OnEnable()
    {
        guardModel = new GuardModel(guardScriptable);
        guardController = new GuardController(this, guardModel);
        damage = guardModel.damage;
        health = maxHealth = guardModel.health;
    }

    public void ShootPlayer()
    {
        player.ModifyHealth(-damage);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetRotatingSpeed()
    {
        return guardController.rotatingSpeed;
    }

    public void GetGuardController(GuardController _guardController)
    {
        guardController = _guardController;
    }
    public void ModifyHealth(float amt)
    {
        health += amt;
        if (health < 0)
        {
            health = 0;
            //death
            gameObject.SetActive(false);
        }
    }

    public float GetLookTargetAngle(Vector3 lookTarget)
    {
        return guardController.GetTargetAngle(transform.position, lookTarget);
    }

    public void ApplyMovement(Vector3 destination)
    {
        if (canMove)
            transform.position = guardController.Movement(transform.position, destination);
    }
    public void EnableMotion(bool enable)
    {
        canMove = enable;
    }
}
