using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerController gamePlayer; //this variable refers to an accual script PlayerController *****
    // Start is called before the first frame update
    public int coins;
    public Text coinText; //this is accessed onnly when you select using UnityEngine.UI;
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>(); //this helps to find the object in the scene that has PlayerController script attached to it and that is Player object******
        coinText.text = "Coins: " + coins; //intial amount of coins in the beginning of the game
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn() //this is method :)
    {
        StartCoroutine("RespawnCoroutine");
    }
    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);//this disables the player
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint; //this sets the Player to a respawnPoint
        gamePlayer.gameObject.SetActive(true);
    }
    public void AddCoins(int numberOfCoins) //for thi method it passes the number of coins using the variable numberOfCoins
    {
        coins += numberOfCoins;
        coinText.text = "Coins: " + coins;
    }
}
