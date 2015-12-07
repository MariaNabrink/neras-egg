using UnityEngine;
using System.Collections;

public class GUITextBeginning : MonoBehaviour {

    public GUISkin skin;
    private bool text;


    private void OnGUI()
    {
        GUI.skin = skin;

        if (text == true)
        {
            GUI.Label(new Rect(Screen.width / 6 - 50, 100, 200, 100), "The humans stole Neras egg. Hurry and bring it back!");
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
