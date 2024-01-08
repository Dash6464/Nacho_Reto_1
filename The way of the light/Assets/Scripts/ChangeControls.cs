using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeControls : MonoBehaviour
{
    public GameObject keyboard_controls, gamepad_controls;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Controls(PlayerInput playerInput)
    {
        if (playerInput.currentControlScheme == "Keyboard")
        {
            keyboard_controls.SetActive(true);
            gamepad_controls.SetActive(false);
        }

        if (playerInput.currentControlScheme == "Gamepad")
        {
            keyboard_controls.SetActive(false);
            gamepad_controls.SetActive(true);
        }

        Console.WriteLine(playerInput.currentControlScheme);
    }
}
