using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //All these thingies are variables
    public float speed = 5f; // public in this varriable allows to control this parameter in unity itself
    public float jumpSpeed = 10f; //public allows to edit the variable in the unity itself
    private float movement = 0f; //movement is a variable 
    private Rigidbody2D rigidBody; // This is just created to refer to rigidbody later on when a new class is created //rigidBody just another name
    // Start is called before the first frame update
    public Transform groundCheckPoint;//Transform it is any object in a scene that can have position rotation and a scale; This part checks if the player is on the ground or not  
    public float groundCheckRadius; 
    public LayerMask groundLayer; //this adds other objects (e.g. planks) thee physics of ground
    private bool isTouchingGround;
    private Animator playerAnimation;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // this allows to access RIgidBody2D commponent in the code // we also do this bit case rigidBody includes the position
        playerAnimation = GetComponent<Animator>(); //gives access to Animator Component     
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    { 
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer); //vector2, float radius, layer mask; isTouchingGround is variable
        movement = Input.GetAxis("Horizontal"); // this will include positive and negative values +-1 for left and right movements
        //Debug.Log(movement); to check if it works
       
        if (movement > 0f) //it says that if no buttons are pressed movement is not >< 0 then no force is applied
        {
             rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y); //Vector2 (x axis,y axis) //Movement is changed by controls; speed is just a multiplication of it 
          /* !! */  transform.localScale = new Vector2(9.058179f, 9.058179f); //keeps the scale as it is (check transform scale component of the player)
        }
        else if (movement < 0f){
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y); //this code makes the player move
            /* !! */             transform.localScale = new Vector2(-9.058179f, 9.058179f); //flips the image on the x axis 
        } /*else
        {
            rigidBody.velocity = new Vector2(0  , rigidBody.velocity.y);
        }*/  //this eliminates moving when no buttons are pressed 
        if (Input.GetButtonDown("Jump") && isTouchingGround)   //Input is what we take from Edit->Preferences->Input manager-> Axes->Jump; GetButtonDown is clicking the button; equals to isTouchingGround==true
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        playerAnimation.SetFloat("Speed", Mathf.Abs(movement)); //the name of the parameter, float of the parameter; Mathf.Abs(movement) to pass to the animator the positive value because Speed should be greater than 0.0001 (positive)
        playerAnimation.SetBool("OnGround", isTouchingGround);
    }

    private void OnTriggerEnter2D(Collider2D other) //method
    {
        // it means that when you hit the FallCollider tag the player respawns at respawnPoint
        if (other.tag == "FallDetector") //tags are extremely important they combine your various gameObjects and prefabs under 1 working tag
            //what will happen when the player enters the FallDetector zone 
            gameLevelManager.Respawn(); //it refers to gameLevelManager variable which is a separate script
        {

        }
        if (other.tag == "CheckPoint") //this sets the checkpoint coordinates to a position where the check point should be 
        {
            respawnPoint = other.transform.position;
        }
    }

}
