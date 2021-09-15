using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : GuardStateMachineBase
{
    private bool coroutineCompleted = true;
    public override void OnEnterState()
    {
        base.OnEnterState();
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (statesManager.PlayerVisible())
        {
            guardView.EnableMotion(false);
            if (coroutineCompleted)
                StartCoroutine(ShootWithDelay(.5f));
        }
        else
            guardView.EnableMotion(true);


    }
    public override void OnExitState()
    {
        base.OnExitState();
    }

    IEnumerator ShootWithDelay(float reloadTime)
    {
        coroutineCompleted = false;
        guardView.EnableMotion(false);
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("Shoot");
        guardView.ShootPlayer();
        guardView.EnableMotion(true);
        coroutineCompleted = true;
    }
}
