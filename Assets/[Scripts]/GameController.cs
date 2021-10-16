using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public Rect screen;
    public Rect backBtnRect;

    void Update()
    {
        OnOrientationChange();
    }

    private void OnOrientationChange()
    {
        screen = Screen.safeArea;
        switch (Screen.orientation)
        {
            case ScreenOrientation.LandscapeLeft:
                break;
            case ScreenOrientation.LandscapeRight:
                break;
            case ScreenOrientation.Portrait:
                break;
        }
    }
}
