using UnityEngine;
using System.Collections;

public class BossLife : MonoBehaviour {

    public int life = 10;
    public bool isEnemy = true;
    private Animator anim;
    public EnemyState state;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Damage(int damageCount)
    {
        life -= damageCount;
        if (life <= 0)
        {
            Destroy(gameObject);
            SetEnemyState(EnemyState.Dying);
            SetAnimationState(); //spela upp långsamt
        }
    }

    void OnTriggerEnter2D(Collider2D other)
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

    private void SetEnemyState(EnemyState newState)
    {
        this.state = newState;
    }


    private void SetAnimationState()
    {
        anim.SetBool("IsDying", state == EnemyState.Dying);
    }
}
