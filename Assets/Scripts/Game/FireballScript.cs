
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 GameCenter = new Vector3(0,0,0);

    [SerializeField] private float _moveSpeed;

    void Start()
    {
        transform.localScale = new Vector3(1.5f,1.5f,0);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 _directionVector = GameCenter - transform.position;

        transform.up = _directionVector;

        transform.position = Vector2.MoveTowards(transform.position,GameCenter, _moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
