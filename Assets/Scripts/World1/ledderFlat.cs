using UnityEngine;

public class ledderFlat : MonoBehaviour
{
    public float speed = 5;

    private float gravityValueMem = 4;
    private PlayerMovement _pm;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Rigidbody2D _rb = collision.GetComponent<Rigidbody2D>();
            _pm = collision.GetComponent<PlayerMovement>();
            if (_rb.gravityScale!=0)
                gravityValueMem = _rb.gravityScale;

            _rb.gravityScale = 0;
            _pm.jumpEnable = false;

            float moveY = Input.GetAxis("Vertical");

            if (moveY>0)
            {
                _rb.velocity = new Vector2(0, speed);
            }
            else if (moveY<0)
            {
                _rb.velocity = new Vector2(0, -speed);
            }
            else
            {
                _rb.velocity = new Vector2(0, 0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = gravityValueMem;
            _pm.jumpEnable = true;
        }
    }
}
