using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSocket : MonoBehaviour
{
    public Animator MyAnimator { get; set; }
    
    private SpriteRenderer spriteRenderer;
    
    private AnimatorOverrideController overrideController;

    private Animator ParentAnimator;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ParentAnimator = GetComponentInParent<Animator>();

        MyAnimator = GetComponent<Animator>();

        overrideController = new AnimatorOverrideController(MyAnimator.runtimeAnimatorController);

        MyAnimator.runtimeAnimatorController = overrideController;
    }


    public void Equip(AnimationClip[] animations)
    {
        spriteRenderer.color=Color.white;

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
