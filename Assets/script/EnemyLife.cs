using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

    public int life = 5;
    public bool isEnemy = true;


    public void Damage(int damageCount)
    {
        life -= damageCount;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
        

    private void OnTriggerEnter2D(Collider2D other)
    {
        FireBall shot = other.gameObject.GetComponent<FireBall>();

        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                Destroy(shot.gameObject); 
            }
        }
    }
}
