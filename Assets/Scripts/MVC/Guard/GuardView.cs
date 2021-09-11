using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardView : MonoBehaviour
{
    private GuardController guardController;
    private GuardModel guardModel;

    [SerializeField]
    private GuardScriptable guardScriptable;


    private void Awake()
    {
    }
    private void OnEnable()
    {
        guardController = new GuardController(this);
        //guardModel = new GuardModel(guardScriptable);
        //mvtSpeed = guardModel.mvtSpeed;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void GetGuardController(GuardController _guardController)
    {
        guardController = _guardController;
    }

    public void ApplyMovement(Vector3 destination, float speed)
    {
        transform.position = guardController.Movement(transform.position, destination, speed);
    }
}
