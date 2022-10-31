using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float playerUpper = 5;
    public float cameraSpeed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y += playerUpper;
        playerPosition.z = -10;
        transform.position = Vector3.Lerp (transform.position, playerPosition, Time.deltaTime* cameraSpeed);
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y+ playerUpper, -10);
    }
}
