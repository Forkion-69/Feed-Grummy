
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FoodScript : MonoBehaviour
{   
    [Header("References")]
    public ProjectileHandler HeaderFile;


    private Rigidbody2D rb;
    private Vector3 gameCenter = new Vector3(0,0,0);

    
    [Header("Misc")]
    public Vector3 offsetVector;

    public List<Sprite> _fruitSprites = new List<Sprite>();


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        HeaderFile = FindAnyObjectByType<ProjectileHandler>().GetComponent<ProjectileHandler>();
        ChooseSprite();
        
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


    private void ChooseSprite()
    {
        int i = Random.Range(0,5);

        SpriteRenderer _sprite = gameObject.AddComponent<SpriteRenderer>();

        switch (i)
        {
            case 0:
                _sprite.sprite = _fruitSprites[0];
                break;
            case 1:
                _sprite.sprite = _fruitSprites[1];
                break;
            case 2:
                _sprite.sprite = _fruitSprites[2];
                break;
            case 3:
                _sprite.sprite = _fruitSprites[3];
                break;
            case 4:
                _sprite.sprite = _fruitSprites[4];
                break;
            
        }

    }

}
