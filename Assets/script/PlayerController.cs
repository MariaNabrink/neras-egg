using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Direction direction = Direction.Right;
    public bool grounded = true;

    private float speed = 3f;
    private float JumpForce = 250f;
    private int jumpCount = 0;
    private int maxJumpCount = 1;

	
	void Update () {

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (direction == Direction.Right)
            {
                Flip();
                direction = Direction.Left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (direction == Direction.Left)
            {
                Flip();
                direction = Direction.Right;
            }
        }

        ShootFireBall();
	}


    void FixedUpdate()
    {
        Jump();
        CheckIfGrounded();
    }


    void ShootFireBall()
    {
        bool shoot = Input.GetKey(KeyCode.Return);

        if (shoot)
        {
            PlayerFighting fight = GetComponent<PlayerFighting>();
            if (fight != null)
            {
                fight.Attack(false, direction);
            }
        }
    }


    void CheckIfGrounded()
    {
        grounded = rigidbody2D.velocity.y == 0;

        if(grounded)
        {
            jumpCount = 0;    
        }
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rigidbody2D.AddForce(Vector2.up*JumpForce);
            jumpCount++;
        }
    }


    void MoveLeft()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));
    }


    void MoveRight()
    {
        transform.Translate(new Vector2(speed * Time.deltaTime, 0f));
    }


    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
