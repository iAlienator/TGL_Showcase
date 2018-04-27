using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Player Player;
    public Text DeathCountText;
    public Canvas GUICanvas;
    public Canvas YouDiedCanvas;

    //private void Awake()
    //{
    //    GUICanvas.enabled = true;
    //    YouDiedCanvas.enabled = false;
    //}

    public void SetDeathCount(int value)
    {
        DeathCountText.text = "Deaths: " + value;
    }
}
