using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour
{

    public void Quit()
    {
        GameControl.control.Save();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        print("quitting");
#else
        Application.Quit();
#endif
    }
}
