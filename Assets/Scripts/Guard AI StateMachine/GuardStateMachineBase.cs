﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardStateMachineBase : MonoBehaviour
{
    protected GuardView guardView;

    protected Light spotLight;

    private Color defaultSpotlightColor;

    protected PlayerView player;
    protected StatesManager statesManager;

    private void OnEnable()
    {
        guardView = GetComponent<GuardView>();
        /*        spotLight = GetComponentInChildren<Light>();
                defaultSpotlightColor = spotLight.color;
        */
        statesManager = GetComponent<StatesManager>();
        player = statesManager.GetPlayerRef();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnEnterState()
    {
        Debug.Log("On Enter: " + this);
        this.enabled = true;
    }
    public virtual void OnExitState()
    {
        Debug.Log("On Exit: " + this);
        this.enabled = false;
    }
}

public enum GuardStates
{
    None,
    Wander,
    Chase,
    Attack
}