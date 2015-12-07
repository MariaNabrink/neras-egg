using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public GUISkin skin;
    public Texture2D heart;
    public float life = 10;

    private float maxLife = 10;
    private float barLength;
    private bool isAlive = true;
    private bool paused = false;


    void Start()
    {
        barLength = Screen.width / 10;
    }


    void Update()
    {
        ChangeCurrentLife(0);
    }


    private void OnGUI()
    {
        if (!isAlive)
        {
            ShowGameOverMenu();
        }

        HealthBar();
    }


    private void ShowGameOverMenu()
    {
        paused = true;

        GUI.skin = skin;

        GUI.Box(new Rect(Screen.width / 2 - 100, 100, 200, 200), "GAME OVER");

        if (GUI.Button(new Rect(Screen.width / 2 - 55, 150, 110, 55), "Start over"))
        {
            Application.LoadLevel("Nera");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 55, 210, 110, 55), "Exit"))
        {
            Application.LoadLevel("NeraMenu");
        }

        if (paused == true)
        {
            Time.timeScale = 0;
        }

        HealthBar();
    }


    private void HealthBar()
    {
        GUI.skin.box.normal.textColor = Color.red;

        GUI.Label(new Rect(10, 10, 90, 30), heart);

        GUI.Box(new Rect(40, 10, barLength, 20), life + "  / " + maxLife);
    }


    public void ChangeCurrentLife(int changeLife)
    {
        life += changeLife;

        if (life < 0)
        {
            life = 0;
        }

        if (life > maxLife)
        {
            life = maxLife;
        }

        if (maxLife < 1)
        {
            maxLife = 1;
        }

        barLength = (Screen.width / 10) * (life / (float)maxLife);
    }


    private void Damage(int damage)
    {
        life -= damage;
        
        if (life <= 0)
        {
            isAlive = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Meat")
        {
            if (life <= 10)
          {
              life += 1;
             Destroy(other.gameObject);
           }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {      
            Debug.Log("HIT");
            Damage(1);
        }
    }
}
