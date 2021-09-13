using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingletonGeneric<InputManager>
{
    [SerializeField]
    private Joystick mvtJoystick;

    [SerializeField]
    private bool invertYControl = false, invertXControl = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        JoystickInput();

    }

    public Vector3 JoystickInput()
    {
        int invertY = invertYControl ? 1 : -1;
        int invertX = invertXControl ? 1 : -1;
        float horizontal = mvtJoystick.Horizontal;
        float vertical = mvtJoystick.Vertical;
        Vector3 playerInput = new Vector3(vertical * invertY, 0, horizontal * invertX);

        return playerInput;
    }
}
