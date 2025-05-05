using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = 2f;           // ?????????????????
    public float moveTime = 2f;            // ?????????????????????????
    public float waitTime = 1f;            // ???????????????????????????????

    private float moveTimer;
    private float waitTimer;
    private int direction;                 // -1 = ????, 1 = ???, 0 = ????

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseNewDirection();
    }

    private void Update()
    {
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0)
            {
                ChooseNewDirection();
            }
        }
    }

    private void ChooseNewDirection()
    {
        direction = Random.Range(-1, 2); // ????????? -1, 0 ???? 1
        moveTimer = moveTime;
        waitTimer = waitTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}