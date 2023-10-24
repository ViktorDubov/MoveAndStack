using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoystick : Joystick
{
    private static FixedJoystick instance;
    public static FixedJoystick Instance => instance;

    public void Awake()
    {
        instance = this;
    }
}