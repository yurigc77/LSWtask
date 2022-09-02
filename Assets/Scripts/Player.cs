using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public SpriteRenderer sprite;


    public int money;
    public float speed;


    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");

        if (HorizontalMovement > 0)
        {
            sprite.flipX = false;
        }
        else if (HorizontalMovement < 0)
        {
            sprite.flipX = true;
        }

        rig.velocity = new Vector2(VerticalMovement * speed, rig.velocity.y);
        rig.velocity = new Vector2(HorizontalMovement * speed, rig.velocity.x);
    }
}
