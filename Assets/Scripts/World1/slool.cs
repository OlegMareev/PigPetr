using UnityEngine;

public class slool : MonoBehaviour
{
    public float xLimit = 10;
    public float yLimit = 5;

    private Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        float maxPosX = startPos.x+ xLimit;
        float minPosX = startPos.x - xLimit;
        float maxPosY = startPos.y + yLimit;
        float minPosY = startPos.y - yLimit;

        if (transform.position.x > maxPosX)
            transform.position = startPos;
        if (transform.position.y > maxPosY)
            transform.position = startPos;
        if (transform.position.x < minPosX)
            transform.position = startPos;
        if (transform.position.y < minPosY)
            transform.position = startPos;
    }
}
