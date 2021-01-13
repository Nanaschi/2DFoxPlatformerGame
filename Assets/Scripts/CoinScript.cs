using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour //class 
  
{
    private LevelManager gameLevelManager; //the access to LevelManager Script!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public int coinValue;
   /* public int score = 0; //this value applies to all methods within the class CoinScript // public allow to control this parameter from the unity directly
    // Start is called before the first frame update */
    void Start() //starts whenever this code starts running //method
    {
        gameLevelManager = FindObjectOfType<LevelManager>(); //this helps to connect the sript!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! P.S. give an access to lvl manage Script during the game 

    }

    // Update is called once per frame
    void Update() //method
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) //it means that we are going to run this code within a method when the object collides with any other object (this is like a huge if statement but not boolian but functional
    {
       if ( other.tag == "Player")   //tags are extremely powerful!!!!!! use them wisely 
        {
            gameLevelManager.AddCoins(coinValue); //here we call the AddCoins method from the script LevelManager
            Destroy(gameObject);
        }
       
        
        
        
        
        //score++;
       // Debug.Log("It collides and the score is " + score);

    }
}
