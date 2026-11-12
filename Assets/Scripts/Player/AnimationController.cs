using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //Intilisations
    public static Animator grummyAnimator;
    public static int _hurtStateID = Animator.StringToHash("grummyHit");
    public static int _doubtStateID = Animator.StringToHash("grummyDoubt");
    public static int _eatStateID = Animator.StringToHash("grummyFood");

    void Awake()
    {
        grummyAnimator = GetComponentInChildren<Animator>();
        grummyAnimator.Play("GrummySquint");
    }

}
