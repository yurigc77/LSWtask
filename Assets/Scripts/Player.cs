using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public SpriteRenderer sprite;


    //public int money;
    public float speed;
    public GameObject interactionIcon;
    public GameObject inventory;
    private bool canInteract;
    private bool IsInventory=false;


    private static Player instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
       if (canInteract)
        {
            Interact();
        }

       OpenInventory();

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

    void Interact()
    {
        if (Input.GetButtonDown("Submit"))
        {
            GameController.instance.OpenDialog();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==3)
        {
            interactionIcon.SetActive(true);
            
            canInteract = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            interactionIcon.SetActive(false);
            canInteract = false;
        }
    }

    public void OpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (IsInventory)
            {
                inventory.SetActive(false);
                IsInventory = false;
            }
            else
            {
                inventory.SetActive(true);
                IsInventory = true;
            }
        }
  
    }


}
