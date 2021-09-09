﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController
{
    public GuardController(GuardView guardView)
    {
        guardView.GetGuardController(this);
    }

    public Vector3 Movement(Vector3 playerPos, Vector3 targetPos)
    {
        Vector3 pos = Vector3.MoveTowards(playerPos, targetPos, Time.deltaTime);
        return pos;
    }

    public GuardView guard { get; }
}