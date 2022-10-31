using UnityEngine;

public class CoinEvents : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject parent;
    public GameObject explosionEffect = null;
    public AudioClip explosionSong = null;
    public bool checkable = true;
    private AudioSource _as;
    private bool coinGeted = false;
    private void Start()
    {
        _as = parent.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (coinGeted == false)
            {
                coinGeted = true;
                if (explosionEffect != null)
                {
                    GameObject expl = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                    Destroy(expl, 1f);
                }
                if (explosionSong != null)
                {
                    _as.clip = explosionSong;
                    if (PlayerPrefs.GetString("EffectsSound") == "On")
                        _as.Play();
                }
                if (checkable == true)
                {
                    Destroy(gameObject, 0.5f);
                    gameManager.addCoins(1);
                }else
                    Destroy(gameObject, 3f);
            }
        }

    }
}
