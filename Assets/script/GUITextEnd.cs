using UnityEngine;
using System.Collections;

public class GUITextEnd : MonoBehaviour {

    public GUISkin skin;
    private bool text;


    private void OnGUI()
    {
        GUI.skin = skin;

        if (text == true)
        {
            GUI.Label(new Rect(Screen.width / 1.7f - 50, 150, 200, 100), "You made it, the egg is safe. And it cracked!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text = false;
        }
    }
}
