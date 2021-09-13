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
        guardModel = new GuardModel(guardScriptable);
        guardController = new GuardController(this, guardModel);
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

    public void ApplyMovement(Vector3 destination)
    {
        transform.position = guardController.Movement(transform.position, destination);
    }
}
