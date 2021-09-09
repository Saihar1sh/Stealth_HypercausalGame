using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardView : MonoBehaviour
{
    private GuardController guardController;

    private void Awake()
    {
        guardController = new GuardController(this);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetGuardController(GuardController _guardController)
    {
        guardController = _guardController;
    }
}
