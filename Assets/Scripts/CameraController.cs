using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //allows to drag player in the component menu in Unity
    public float offset; //How far the camera could be from the player
    private Vector3 playerPosition; //determnes the position of the player
    public float offsetSmoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z); //this line lets the camera follow the player only on the x axis 
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z); //transform.position is where the camera is right now
        if (player.transform.localScale.x > 0f) // when the speed is positive
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        } else //and negative 
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing*Time.deltaTime); //Time.deltaTime means that it will remain smoothness on any computer and FPS
    }
}
