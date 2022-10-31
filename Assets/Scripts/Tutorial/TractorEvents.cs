using UnityEngine;

public class TractorEvents : MonoBehaviour
{
    public GameObject player;
    public GameObject playerOnTractorWalk;
    public GameObject playerOnTractorStand;
    public float speedBoost = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerMovement _playerMovement =  player.GetComponent<PlayerMovement>();
            _playerMovement.sitEnable = false;

            _playerMovement.walkPlayer.SetActive(false);
            _playerMovement.standPlayer.SetActive(false);

            playerOnTractorStand.SetActive(true);
            playerOnTractorWalk.transform.SetParent(player.transform);
            playerOnTractorStand.transform.SetParent(player.transform);

            playerOnTractorStand.transform.position = new Vector3(
                player.transform.position.x, player.transform.position.y+1.09f, player.transform.position.z);
            playerOnTractorWalk.transform.position = new Vector3(
                player.transform.position.x, player.transform.position.y + 1.09f, player.transform.position.z);

            _playerMovement.walkPlayer = playerOnTractorWalk;
            _playerMovement.standPlayer = playerOnTractorStand;
            _playerMovement.speed *= speedBoost;


            gameObject.SetActive(false);


        }
    }

}
