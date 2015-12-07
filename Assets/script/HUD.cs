using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public GUISkin skin;
    private bool paused = false;
    private bool text;

    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            paused = true; 

            GUI.skin = skin;

            GUI.Box(new Rect(Screen.width / 2 - 100, 100, 200, 200), "");

            if (GUI.Button(new Rect(Screen.width / 2 - 55, 150, 110, 55), "Start over"))
             {
                 Application.LoadLevel("Nera");
             }
             if (GUI.Button(new Rect(Screen.width / 2 - 55, 210, 110, 55), "Exit to menu"))
             {
                 Application.LoadLevel("NeraMenu");
             }
        }
        else
        {
            paused = false;
        }


        if (paused == true)
        {
            Time.timeScale = 0;
        }
        if (paused == false)
        {
            Time.timeScale = 1;
        }
    }
}
