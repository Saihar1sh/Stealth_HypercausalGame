using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardStateMachineBase : MonoBehaviour
{
    protected GuardView guardView;


    private void OnEnable()
    {
        guardView = GetComponent<GuardView>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnEnterState()
    {
        this.enabled = true;
    }
    public virtual void OnExitState()
    {
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