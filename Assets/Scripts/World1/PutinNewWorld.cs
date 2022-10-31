using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PutinNewWorld : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject text;
    public GameObject player;
    public GameObject effect;
    public GameObject coin;
    public float speed = 5;
    public float coinsSpawnsTime = 0.5f;

    private bool songStarted = false;
    private bool active = false;
    private int coinsValue = 0;
    private GameManager _gm;

    private void Start()
    {
        _gm = gameManager.GetComponent<GameManager>();
    }
    void Update()
    {
        if (text.activeSelf)
        {
            active = true;
            if (songStarted == false)
            {
                songStarted = true;
                if (PlayerPrefs.GetString("EffectsSound") == "On")
                    GetComponent<AudioSource>().Play();
            }

            transform.position = Vector3.Lerp(transform.position,
                 new Vector3(player.transform.position.x, player.transform.position.y+1.2f, player.transform.position.z), 
                Time.deltaTime * speed);
            GameObject expl = Instantiate(effect, 
                new Vector3(transform.position.x, transform.position.y, transform.position.z+0.1f),
                Quaternion.identity);
            Destroy(expl, 0.4f);
        }
        
    }
    private bool catched = false; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active == true)
        {
            if (collision.transform.tag == "Player")
            {
                if (catched == false)
                {
                    catched = true;
                    //player.GetComponent<PlayerMovement>().enabled = false;
                    coinsValue = _gm.getCoinValue();
                    speed = 5;
                    StartCoroutine(spawnCoins());
                }
            }
        }
    }
    private bool exitWordl = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (active == true)
        {
            if (collision.transform.tag == "Player")
            {
                if (exitWordl == true)
                {
                    StopCoroutine(spawnCoins());
                    _gm.save();
                    SceneManager.LoadScene("Tutorial");
                }
            }
        }
    }
    private int spawnBoost = 7;
    IEnumerator spawnCoins()
    {
        while (true)
        {
            if (coinsValue > 0)
            {
                GameObject newCoin = Instantiate(coin,
                    new Vector3(player.transform.position.x, player.transform.position.y+1f, -1),
                    Quaternion.identity);
                newCoin.GetComponentInParent<CoinEvents>().parent = gameObject;
                newCoin.GetComponentInParent<CoinEvents>().checkable = false;
                float dir = 1;
                if (transform.position.x < player.transform.position.x)
                    dir = -1;
                newCoin.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir*1000, 1000));

                _gm.addCoins(-1);
                coinsValue--;
                spawnBoost++;
                if (spawnBoost > 35)
                    spawnBoost = 35;
                if (coinsValue == 0)
                    yield return new WaitForSeconds(2);
                yield return new WaitForSeconds(coinsSpawnsTime/ (spawnBoost/ 7));
            }
            else
            {
                exitWordl = true;
                yield return new WaitForSeconds(2);
            }
        }
    }
    
}
