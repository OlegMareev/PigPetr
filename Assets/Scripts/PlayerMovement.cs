using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject walkPlayer;
    public GameObject standPlayer;
    public GameObject sitPlayer;
    public float speed = 1;
    public float jumpForce = 1;
    public AudioClip[] jumpSongs;
    public bool jumpEnable = true;

    private AudioSource _as;
    private Rigidbody2D _rb;
    private bool moveFlag = false;
    private float moveValueX = 0;
    private bool faceRight = true;
    private bool jumpFlag = false;

    public float timeToSit = 10;
    private float timeToSitCounter = 0;
    public bool sitEnable = true;
    void Start()
    {
        _as = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveValueX = Input.GetAxis("Horizontal");
        float moveValueY = Input.GetAxis("Vertical");
        if (moveValueX != 0)
        {
            moveFlag = true;
            standPlayer.SetActive(false);
            walkPlayer.SetActive(true);
            sitPlayer.SetActive(false);

            timeToSitCounter = 0;
        }
        else
        {
            moveFlag = false;
            standPlayer.SetActive(true);
            walkPlayer.SetActive(false);
            sitPlayer.SetActive(false);
        }

        if (sitEnable == true)
        {
            timeToSitCounter += Time.deltaTime;
            if (timeToSitCounter > timeToSit)
            {
                standPlayer.SetActive(false);
                walkPlayer.SetActive(false);
                sitPlayer.SetActive(true);
            }
            else 
            { 
                sitPlayer.SetActive(false); 
            }
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || 
            Input.GetKeyDown(KeyCode.W)) && isGround())
            if(jumpEnable)
                jumpFlag = true;
    }
    private void FixedUpdate()
    {
        if (jumpFlag)
        {
            _rb.AddForce(Vector2.up * jumpForce);
            jumpFlag = false;

            int numOfSong = 0;
            if (jumpSongs.Length > 1)
                numOfSong = Random.Range(0, jumpSongs.Length);
            _as.clip = jumpSongs[numOfSong];
            if (PlayerPrefs.GetString("EffectsSound") == "On")
                _as.Play();
        }

        if (moveFlag == true)
        {
            if (moveValueX > 0 && !faceRight)
                changeDirection();
            else if (moveValueX < 0 && faceRight)
                changeDirection();

            transform.position = Vector3.MoveTowards(transform.position, 
                transform.position+ transform.right * moveValueX, speed * Time.deltaTime);
            moveFlag = false;
        }

    }

    private void flipY(GameObject obj)
    {
        obj.transform.localScale = new Vector3(
                obj.transform.localScale.x * (-1),
                obj.transform.localScale.y, obj.transform.localScale.z);
    }
    private void changeDirection()
    {
        faceRight = !faceRight;
        flipY(walkPlayer);
        flipY(standPlayer);
        flipY(sitPlayer);
    }
    private bool isGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        return collider.Length > 1;
    }
}