using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public SpriteRenderer sprite;
    public Animator anim;


   
    public float speed;
    public GameObject interactionIcon;
    public GameObject inventory;
    private bool canInteract;
    private bool IsInventory=false;
    private bool IsMoving;

    [SerializeField]
    public ClothesSocket[] clothesSocket;

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

        if(HorizontalMovement > 0)
        {
            anim.SetInteger("Transition", 2);//right
            clothesSocket[0].GetComponent<SpriteRenderer>().flipX = false;
            clothesSocket[1].GetComponent<SpriteRenderer>().flipX = false;
            clothesSocket[2].GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (HorizontalMovement > 0 && VerticalMovement!=0)
        {
            anim.SetInteger("Transition", 2);//right
            clothesSocket[0].GetComponent<SpriteRenderer>().flipX = false;
            clothesSocket[1].GetComponent<SpriteRenderer>().flipX = false;
            clothesSocket[2].GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (HorizontalMovement < 0)
        {
            anim.SetInteger("Transition", 1);//left
            clothesSocket[0].GetComponent<SpriteRenderer>().flipX = true;
            clothesSocket[1].GetComponent<SpriteRenderer>().flipX = true;
            clothesSocket[2].GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(HorizontalMovement < 0 && VerticalMovement != 0)
        {
            anim.SetInteger("Transition", 1);//left
            clothesSocket[0].GetComponent<SpriteRenderer>().flipX = true;
            clothesSocket[1].GetComponent<SpriteRenderer>().flipX = true;
            clothesSocket[2].GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(VerticalMovement != 0)
        {
            anim.SetInteger("Transition", 2);//right
            clothesSocket[0].GetComponent<SpriteRenderer>().flipX = false;
            clothesSocket[1].GetComponent<SpriteRenderer>().flipX = false;
            clothesSocket[2].GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            anim.SetInteger("Transition", 0);//idle
            clothesSocket[0].GetComponent<SpriteRenderer>().flipX = false;
            clothesSocket[1].GetComponent<SpriteRenderer>().flipX = false;
            clothesSocket[2].GetComponent<SpriteRenderer>().flipX = false;
        }

        rig.velocity = new Vector2(VerticalMovement * speed, rig.velocity.y);
        rig.velocity = new Vector2(HorizontalMovement * speed, rig.velocity.x);
        /*
        if(anim.GetInteger("Transition")==1)
        {
            foreach(ClothesSocket item in clothesSocket)
            {
                item.GetComponent<SpriteRenderer>().flipX = true;
            }
        }*/
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
