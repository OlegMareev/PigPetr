using UnityEngine;

public class polFlag : MonoBehaviour
{
    public GameObject text;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        text.SetActive(true);
    }

}
