using UnityEngine;
using System.Collections;

public class PlayerFighting : MonoBehaviour {

    public Transform fireball;
    public float shootingRate = .5f;
    private float shootingCooldown;


    void Start()
    {
        shootingCooldown = 0f;
    }


	void Update () 
    {
        if (shootingCooldown > 0)
        {
            shootingCooldown -= Time.deltaTime;
        }
	}


    public void Attack(bool isEnemy, Direction direction)
    {
        if (shootingCooldown <= 0f)
        {
            shootingCooldown = shootingRate;
            
            var newShot = Instantiate(fireball) as Transform;
            newShot.position = transform.position;

            FireBall shot = newShot.gameObject.GetComponent<FireBall>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            MoveFireBall move = newShot.gameObject.GetComponent<MoveFireBall>();
            if (move != null)
            {
                if(direction == Direction.Right)
                {
                    move.direction = this.transform.right; 
                }
                else
                {
                    move.direction = -this.transform.right; 
                }
            }    
        }
    }
}
