using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    public Player Player;

    public void Update()
    {
        // In-editor button press simulation
#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
        if (Input.GetKey(KeyCode.LeftArrow))
            LeftHeld();
        if(Input.GetKeyUp(KeyCode.LeftArrow))
            LeftReleased();
        if (Input.GetKey(KeyCode.RightArrow))
            RightHeld();
        if (Input.GetKeyUp(KeyCode.RightArrow))
            RightReleased();
#endif
    }

    public void Jump()
    {
        Player.Jump();
    }

    public void LeftHeld()
    {
        Player.SetHorizontalInput(-1);
    }

    public void LeftReleased()
    {
        Player.SetHorizontalInput(0);
    }

    public void RightHeld()
    {
        Player.SetHorizontalInput(1);
    }

    public void RightReleased()
    {
        Player.SetHorizontalInput(0);
    }
}
