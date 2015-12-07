using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Direction direction = Direction.Left;
    public EnemyState state;
    public Transform startPositionTransform;
    public Transform endPositionTransform;
    public float walkSpeed = 1f;
    public float runSpeed = 3f;
    public int damageToPlayer = 1;

    private Vector2 rightPatrolPosition;
    private Vector2 leftPatrolPosition;
    private Vector2 startPosition;
    private Animator anim;
    private float attackingDistance = 1.5f;


     void Start()
     {
         anim = GetComponent<Animator>();
         SetEnemyState(EnemyState.Patrolling);
         startPosition = transform.position;
         rightPatrolPosition = endPositionTransform.position;
         leftPatrolPosition = startPositionTransform.position;
     }
	

	void Update () 
    {
        MoveEnemy();
	}


    private void MoveEnemy()
    {

        if (direction == Direction.Left && transform.position.x <= leftPatrolPosition.x)
        {
            direction = Direction.Right;
            FlipEnemy();
        }
        else if (direction == Direction.Right && transform.position.x >= rightPatrolPosition.x)
        {
            direction = Direction.Left;
            FlipEnemy();
        }
        

        if (state == EnemyState.Patrolling)
        {
            if (direction == Direction.Left)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(leftPatrolPosition.x, transform.position.y), walkSpeed*Time.deltaTime);
            }
            else if (direction == Direction.Right)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(rightPatrolPosition.x, transform.position.y), walkSpeed*Time.deltaTime);
            }
        }
            
        if (state == EnemyState.Returning)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(startPosition.x, transform.position.y), runSpeed*Time.deltaTime);
            if (transform.position.x == startPosition.x)
            {
                SetEnemyState(EnemyState.Patrolling);
                SetAnimationState();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetEnemyState(EnemyState.Attacking);
            SetAnimationState();
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AttackTarget(other.transform.position);
        }
     }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetEnemyState(EnemyState.Returning);
        }
    }


    private void AttackTarget(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed*Time.deltaTime);

        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);

        if (distanceToTarget <= attackingDistance)
        {
            SetEnemyState(EnemyState.Stabbing);
            SetAnimationState();
        }
        else
        {
            if (state == EnemyState.Stabbing)
            {
                SetEnemyState(EnemyState.Attacking);
                SetAnimationState();
                FlipEnemy();
            }  
        }
    }


    private void FlipEnemy()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }


    private void SetEnemyState(EnemyState newState)
    {
        this.state = newState;
    }


    private void SetAnimationState()
    {
        anim.SetBool("IsAttacking", state == EnemyState.Attacking);
        anim.SetBool("IsStabbing", state == EnemyState.Stabbing);
        anim.SetBool("IsPatrolling", state == EnemyState.Patrolling);
    }
}
