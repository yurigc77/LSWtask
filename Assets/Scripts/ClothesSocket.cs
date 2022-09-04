using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSocket : MonoBehaviour
{
    public Animator MyAnimator { get; set; }
    
    private SpriteRenderer spriteRenderer;
    
    private AnimatorOverrideController overrideController;

    private Animator ParentAnimator;

    //public Animator anim;

    private int i;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ParentAnimator = GetComponentInParent<Animator>();

        MyAnimator = GetComponent<Animator>();

        overrideController = new AnimatorOverrideController(MyAnimator.runtimeAnimatorController);

        MyAnimator.runtimeAnimatorController = overrideController;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Equip(AnimationClip[] animations)
    {
        spriteRenderer.color=Color.white;
      /*  if(anim.GetInteger("Transition")==1)
        {
            i = 0;
        }
        else
        {
            i = 1;
        }
      */
        overrideController["idle"] = animations[1];
        overrideController["walk_r"] = animations[1];
        overrideController["walk_l"] = animations[0];
    }

    public void Dequip()
    {
        overrideController["idle"] = null;
        overrideController["walk_r"] = null;
        overrideController["walk_l"] = null;

        Color c=spriteRenderer.color;
        c.a = 0;
        spriteRenderer.color = c;
    }
}
