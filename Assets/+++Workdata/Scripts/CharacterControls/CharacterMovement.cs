using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb; // container erstellt
    private float inputDirection; //damit man es überall nutzen kann
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int firstjumpcount = 2;
    private int jumpcount; //jumoing count

    private bool isGrounded; // it exists! 

    [SerializeField] private float sprintSpeed = 15f;
    [SerializeField] private float sneakSpeed;
    private float tempSpeed;

    private float isSprinting; // detacts if player holding the button oder so
    private float isSneaking;

    private PlayerInput playerInput;
 
    
    //SerialzeFields fügen in dem Fall die Buttons oder Panel in den Inspector
    //hinzu und man kann dann die InGame Elemente reinziehen und sie sind verbunden
    [SerializeField] private float movementSpeed = 10f;

    [SerializeField] private Transform groundCheckPosition; // position wann funktsen
    [SerializeField] private float groundCheckRadius; // in welchem Radius
    [SerializeField] private LayerMask layerGroundCheck;  // auf welcher ebene

    private bool isFacingRight = true;
    
    //private int framecounter = 0;
    //private int JumpCount = 0;
    
    // Start is called before the first frame update


    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //guckt ob es etwas mit dem namen gibt damit man es nutzen kann
        rb.freezeRotation = true; // kann sich nicht drehen
        Debug.Log("Start!");

        tempSpeed = movementSpeed;
    }

    // Update is called once per frame
    // sachen die sofort passieren sollen gehen in update
    void Update()
    {
        if (isSprinting > 0)
        {
            //if sprint is größerals zu kann sprint
            movementSpeed = sprintSpeed;
        }
        else if (isSprinting == 0 && isSneaking == 0)
        {
            //if both is 0 its normal speed
            movementSpeed = tempSpeed;
        }
        else if (isSneaking > 0)
        {
            //if sneaking is größerals zu kann sprint
            movementSpeed = sneakSpeed;
        }
    }

    // all things Pysical go here
    private void FixedUpdate() // physikalisch bewegende figuren immer in fixed sonst kann das bei allen Pcs anders sein
    {
        rb.velocity = new Vector2(inputDirection * movementSpeed, rb.velocity.y); //rb.velocity.y fall pysixk bleibt gleich und fällt nicht in slowmotion
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, layerGroundCheck);
    }

    void OnJump()
    {
        if (isGrounded) // nur wenn man den Kreis berührt dann springen sonst net
        {
            jumpcount = firstjumpcount; 
        }

        if (jumpcount > 0)
        {
            rb.velocity =
                new Vector2(x: 0f, y: jumpForce); // jump hight and now it can jump/ jumpForce damit man es im inspector umschalten kann
            //JumpCount = JumpCount + 1;
            Debug.Log("Jump! i jumped "); //+ JumpCount + " times!");
            jumpcount = jumpcount - 1;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        inputDirection = inputValue.Get<float>();
        //Debug.Log("Moved`!" + inputDirection); // isDirection um es ausgegeben zubekommen

        // wenn das in der klammer steht m,ache was in den geschiffenen klammern steht
        // wenn größer als nbull dann Face right wenn nicht stimmt dann lass es
        // && und   || oder
        if (inputDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (inputDirection < 0 && isFacingRight)
        {
            Flip();
        }
        
    }

    void Flip()
    { // transform auffinden dann localscale ansehen
        Vector3 currentScale = transform.localScale;
        currentScale.x = currentScale.x * -1;
        transform.localScale = currentScale;
        // verändern dann alten currentScale in minus und setze ihn neu an
        isFacingRight = !isFacingRight;
        // damitz auch die richtig facing stimmt nochmal reinschreiben
    }

    void OnSneak(InputValue inputValue)
    {
        Debug.Log("sneaky!");
        isSneaking = inputValue.Get<float>();// muss man nicht immer ranschreiben

    }

    void OnSprint(InputValue inputValue)
    {
        // so bekommt man die nachricht ob es gedrückt ist oder nicht
        isSprinting = inputValue.Get<float>(); // muss man nicht immer ranschreiben
        Debug.Log("Sprinting" + isSprinting);  //+ inputValue.Get<float>());
    }

    
    
}
