using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenWorld1 : MonoBehaviour
{
    public GameObject gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().addCoins(50);
            gameManager.GetComponent<GameManager>().save();
            SceneManager.LoadScene("World 1");
        }
    }
}
