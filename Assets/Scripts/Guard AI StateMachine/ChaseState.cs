using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : GuardStateMachineBase
{
    Coroutine playerCheck;
    public override void OnEnterState()
    {
        //base.OnEnterState();
        this.enabled = true;
        //wait for 0.5f then go to player pos when visible
        playerCheck = StartCoroutine(WaitAndCheckPlayer());
    }
    public override void OnExitState()
    {
        StartCoroutine(WaitForGuardToTravel());
        //StopAllCoroutines();
    }

    IEnumerator WaitAndCheckPlayer()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 guardPos = transform.position;
        guardView.transform.LookAt(player.transform);
        guardView.ApplyMovement(playerPos);
        if (guardView.transform.position == playerPos)
            yield return null;
        else
        {
            yield return new WaitForSeconds(.1f);
        }

    }
    IEnumerator WaitForGuardToTravel()
    {
        yield return playerCheck;
        base.OnExitState();

    }
}
