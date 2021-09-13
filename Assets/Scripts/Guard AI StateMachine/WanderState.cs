﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : GuardStateMachineBase
{
    [SerializeField]
    private float waitTime = .5f;

    [SerializeField]
    private Transform pathHolder;

    private int prevDestinationIndex;   //-_-
    private Vector3 prevTargetDest;

    private bool enteredWanderStateOnce = false;

    private void Awake()
    {
        prevTargetDest = transform.position;
    }
    private void Start()
    {

    }
    public Vector3 GetLastDestination()
    {
        return prevTargetDest;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        int i = 0;
        for (i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i].y = transform.position.y;
        }
        StartCoroutine(FollowPath(waypoints));

    }

    public override void OnExitState()
    {
        enteredWanderStateOnce = true;
        // StopAllCoroutines();
        base.OnExitState();
    }




    //Coroutines

    IEnumerator FollowPath(Vector3[] waypts)
    {
        int q;
        if (enteredWanderStateOnce)
        {
            q = prevDestinationIndex;
        }
        else
        {
            q = 0;
        }

        transform.position = waypts[q];

        int targetWayptIndex = 1;
        Vector3 targetWaypt = waypts[targetWayptIndex];
        transform.LookAt(targetWaypt);
        while (true)
        {
            //transform.position = Vector3.MoveTowards(transform.position, targetWaypt, mvtSpeed * Time.deltaTime);
            guardView.ApplyMovement(targetWaypt);
            if (transform.position == targetWaypt)
            {
                targetWayptIndex = (targetWayptIndex + 1) % waypts.Length;
                targetWaypt = waypts[targetWayptIndex];
                prevDestinationIndex = targetWayptIndex;
                prevTargetDest = targetWaypt;
                yield return new WaitForSeconds(waitTime);
                yield return StartCoroutine(TurnToFace(targetWaypt));
            }
            yield return null;
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, guardView.GetRotatingSpeed() * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }

    //Gizoms

    private void OnDrawGizmos()
    {
        Vector3 startPos = pathHolder.GetChild(0).position;
        Vector3 prevPos = startPos;
        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(prevPos, waypoint.position);
            prevPos = waypoint.position;
        }
        Gizmos.DrawLine(prevPos, startPos);
    }

}
