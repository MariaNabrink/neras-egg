using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour{


    private Animator anim;
    public EggState state;


    void Start()
    {
        SetEggState(EggState.Idle);
        anim = GetComponent<Animator>();
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetEggState(EggState.Hatching);
            SetAnimationState();
        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetEggState(EggState.Baby);
            SetAnimationState();
        }
    }


    private void SetEggState(EggState newState)
    {
        this.state = newState;
    }


    private void SetAnimationState()
    { 
        anim.SetBool("IsHatching", state == EggState.Hatching);
        anim.SetBool("IsBaby", state == EggState.Baby);
        anim.SetBool("IsIdle", state == EggState.Idle);
    }
}
