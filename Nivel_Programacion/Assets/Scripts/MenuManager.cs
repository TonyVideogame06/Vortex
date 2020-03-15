using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;
    public Canvas darkTransitionCanvas;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    public void ShowDarkTransition()
    {
        darkTransitionCanvas.enabled = true;
    }
    public void HideDarkTransition()
    {
        darkTransitionCanvas.enabled = false;
    }
}
