using UnityEditor;
using UnityEngine;

public class ChestEvents : MonoBehaviour
{
    public GameObject coin;
    public GameObject parent;
    public GameObject explosionEffect = null;
    public AudioClip explosionSong = null;

    public float xCoinForce = 1000;
    public float yCoinForce = 1000;
    public float playerForce = 1500;

    private AudioSource _as;
    private void Start()
    {
        _as = parent.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            addObjForce(collision.gameObject, playerForce, playerForce);

            coin.transform.SetParent(parent.transform);
            coin.SetActive(true);
            if (explosionEffect != null)
            {
                GameObject expl = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(expl, 1f);
            }
            if (explosionSong != null)
            {
                _as.clip = explosionSong;
                if(PlayerPrefs.GetString("EffectsSound") == "On")
                    _as.Play();
            }
            
            Destroy(gameObject,0.2f);
            addObjForce(coin, xCoinForce, yCoinForce);
        }
    }

    private void addObjForce(GameObject obj,float xForce,float yForce)
    {
        if ((xForce == 0) && (yForce == 0))
            return;

        Rigidbody2D _rb = obj.GetComponent<Rigidbody2D>();
        Transform _tr = obj.GetComponent<Transform>();

        if(_tr.position.x > transform.position.x)
        {
            _rb.AddForce(new Vector2(xForce, yForce));
        }
        else
        {
            _rb.AddForce(new Vector2(-xForce, yForce));
        }

    }
}
