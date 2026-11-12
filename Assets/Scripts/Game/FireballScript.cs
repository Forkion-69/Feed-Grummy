
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    [Header("References")]
    public ProjectileHandler HeaderFile;

    private Rigidbody2D rb;
    private Vector3 GameCenter = new Vector3(0,0,0);

    public ParticleSystem fireParticle;

    void Start()
    {
        transform.localScale = new Vector3(1.5f,1.5f,0);
        rb = GetComponent<Rigidbody2D>();
        HeaderFile = FindAnyObjectByType<ProjectileHandler>().GetComponent<ProjectileHandler>();
    }

    void Update()
    {
        Move();
    }

    //---------------------------------------------------------------------------//

    private void Move()
    {
        Vector3 _directionVector = GameCenter - transform.position;

        transform.up = _directionVector;

        transform.position = Vector2.MoveTowards(transform.position,GameCenter, HeaderFile.fireballMoveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            GrummyManager.DeductHealth(1);
            AnimationController.grummyAnimator.SetTrigger(AnimationController._hurtStateID);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        ParticleSystem fireburst = Instantiate(HeaderFile.fireParticle,transform.position, Quaternion.identity);
        fireburst.Play();
        // Debug.Log("Pressed his ahh");
    }
}
