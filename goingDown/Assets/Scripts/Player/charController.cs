using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class charController : MonoBehaviour
{
    public bool canMove = true;
    bool shouldOpenParachute=>Input.GetKey(KeyCode.E)&&!isGrounded;

    [Header("UI")]
    [SerializeField] GameObject spriteSet;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject popUpPoint;

    [Header("Player Stats")]
    [SerializeField] private float playerSpeed;
    private float gravity;
    [SerializeField] private float mainGravity;
    [SerializeField] private float parachuteGravity;

    [Header("ScoreHandler")]
    
    public int score; 
    private float timer = 0f;
    public float delayAmount;

    [Header("ButtonAnims")]
    public Animator buttonPrchtAnim;
    public Animator buttonRightAnim;
    public Animator buttonLeftAnim;



    [SerializeField] private int speedMultiplier;
    //others
    Rigidbody2D rb;
    Vector2 currentInput;
    Animator anim;
    bool facingRight=true;
    bool isGrounded;
    bool usingParachute;
    float parachuteCheck;

    


    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
       
        anim=GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(canMove)
        {
            //handleMoveInput();
            handleAnimations();
            handleFacing();
            handleGravity();
            handleScore();
            handleParachute();
            handleUI();

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
        delayAmount-= Time.deltaTime*.005f;
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
      
        if (usingParachute)
        {
            parachuteCheck = 1;
            gravity = parachuteGravity;
        }
          
        else
        {
            gravity = mainGravity;

            if (parachuteCheck ==1)
            {
                gravity += 0.25f * Time.deltaTime;
            }
        }

        if (isGrounded)
            parachuteCheck = 0;
        else
            parachuteCheck = 1;
           

    }
    
    public void handleParachuteOpen()
    {    
        usingParachute = true;
        buttonPrchtAnim.SetBool("open", true);
    }
    public void handleParachuteClose()
    {
        usingParachute = false;
        buttonPrchtAnim.SetBool("open", false);
    }

    void handleGravity()
    {
        if(!isGrounded)
            rb.AddForce(Vector2.down * gravity);
    }
    public void moveRight()
    {
        buttonRightAnim.SetBool("click", true);
        if(canMove)
            currentInput.x = 1;
    }

    public void moveLeft()
    {
        buttonLeftAnim.SetBool("click", true);
        if (canMove)
             currentInput.x = -1;
    }

    public void notMoving()
    {
        buttonLeftAnim.SetBool("click", false);
        buttonRightAnim.SetBool("click", false);
        currentInput.x = 0;
    }

    void handleUI()
    {
        scoreText.text=score.ToString();
    }

    void applyMovement()
    {   

        rb.velocity = currentInput*playerSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
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
