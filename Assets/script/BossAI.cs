using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

    public Direction direction = Direction.Left;
    public EnemyState state;
    public float runSpeed = .02f;

    private float attackingDistance = 1.5f;
    private Vector2 startPosition;
    private Animator anim;

	
	void Start () 
    {
        SetEnemyState(EnemyState.Idle);
        startPosition = transform.position;
        anim = GetComponent<Animator>();
	}


    private void AttackTarget(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed);

        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);

        if (distanceToTarget <= attackingDistance)
        {
            SetEnemyState(EnemyState.Stabbing);
            SetAnimationState();

            if (direction == Direction.Left)
            {
                FlipEnemy();
            }
            else if(direction == Direction.Right)
            {
                FlipEnemy();
            }
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetEnemyState(EnemyState.Attacking);
            SetAnimationState();
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AttackTarget(other.transform.position);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetEnemyState(EnemyState.Idle);
            SetAnimationState();
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
        anim.SetBool("IsIdle", state == EnemyState.Idle);
        anim.SetBool("IsAttacking", state == EnemyState.Attacking);
        anim.SetBool("IsStabbing", state == EnemyState.Stabbing);
        anim.SetBool("IsDying", state == EnemyState.Dying);
    }
}
