using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GUISkin skin;

    private void OnGUI()
    {
        GUI.skin = skin;

        GUI.Box(new Rect(Screen.width / 2 - 100, 100, 200, 200), "");

        if (GUI.Button(new Rect(Screen.width / 2 - 55, 150, 110, 55), "New Game"))
        {
            Application.LoadLevel("Nera");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 55, 210, 110, 55), "Exit Game"))
        {
            Application.Quit();
        }
    }
}
