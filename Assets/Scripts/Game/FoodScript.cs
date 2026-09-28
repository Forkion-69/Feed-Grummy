
using UnityEngine;

public class FoodScript : MonoBehaviour
{   
    [Header("References")]
    public ProjectileHandler HeaderFile;


    private Rigidbody2D rb;
    private Vector3 gameCenter = new Vector3(0,0,0);
    [Header("Misc")]
    public Vector3 offsetVector;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        HeaderFile = FindAnyObjectByType<ProjectileHandler>().GetComponent<ProjectileHandler>();
    }

    private void Update()     
    {
        Move();
    }

    private void Move()
    {
        Vector3 _directionVector = gameCenter - transform.position;

        transform.up = _directionVector;

        transform.position = Vector2.MoveTowards(transform.position,gameCenter,HeaderFile.baseFoodSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
