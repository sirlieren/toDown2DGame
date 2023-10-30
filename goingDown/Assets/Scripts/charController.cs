using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField] GameObject spriteSet;
    [Header("Player Stats")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;

    [Header("Keys")]
    [SerializeField] private KeyCode jumpKeyCode = KeyCode.Space;

    //others
    Rigidbody2D rb;
    Vector2 currentInput;
    Animator anim;
    bool facingRight=true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        if(canMove)
        {
            handleMoveInput();
            handleAnimations();
            handleFacing();

            applyMovement();
        }
    }

    void handleMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        currentInput=new Vector2 (x,default);
        currentInput = currentInput.normalized;
    }
    void handleAnimations()
    {
        if(currentInput.x!=0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void handleFacing()
    {
        if(currentInput.x>.1&&!facingRight) //right
        {
            spriteSet.transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }
        else if(currentInput.x<-.1f&&facingRight)
        {
            spriteSet.transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }
    }
    void applyMovement()
    {
        rb.velocity = currentInput*playerSpeed;
    }
}
