using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public bool canMove = true;
    bool shouldOpenParachute=>Input.GetKey(KeyCode.E)&&!isGrounded;

    [SerializeField] GameObject spriteSet;

    [Header("Player Stats")]
    [SerializeField] private float playerSpeed;
    private float gravity;
    [SerializeField] private float mainGravity;
    [SerializeField] private float parachuteGravity;

    [Header("ScoreHandler")]
    
    public int score; 
    private float timer = 0f;
    public float delayAmount;


    

    [SerializeField] private int speedMultiplier;
    //others
    Rigidbody2D rb;
    Vector2 currentInput;
    Animator anim;
    bool facingRight=true;
    bool isGrounded;
    bool usingParachute;
   


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
            handleGravity();
            handleScore();

            if(shouldOpenParachute)
                handleParachute();
            else
                handleParachuteClose();

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

    void handleScore()
    {
        timer += Time.deltaTime;
      
        if (timer >= delayAmount)
        {
            timer = 0f;
            score+=speedMultiplier;
       
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
    
    void handleParachute()
    {
        gravity = parachuteGravity;
        usingParachute = true;
    }
    void handleParachuteClose()
    {
        if(usingParachute)
        {
            gravity = mainGravity;
            usingParachute = false;
        }
        else
        {
          
                gravity += 0.25f * Time.deltaTime;
        }

        if (isGrounded)
            gravity = mainGravity;
     
        
    }

    void handleGravity()
    {
        if(!isGrounded)
            rb.AddForce(Vector2.down * gravity);
    }
   
    void applyMovement()
    {   

        rb.velocity = currentInput*playerSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            print("www");

            isGrounded = true;
        }
  
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


}
