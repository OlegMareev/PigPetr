using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject text;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            text.SetActive(true);
        }
    }
}
