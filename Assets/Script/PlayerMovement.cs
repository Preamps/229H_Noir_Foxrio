using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor.Overlays;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 200f;
    public bool isJumping = false;
    
    public int hp = 100;

    private float moveInput;
    private Rigidbody2D rb2d;
    private string savePath;

    [System.Serializable]
    private class PlayerStats
    {
        public int hp;
        public int coin;
    }


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        savePath = Application.persistentDataPath + "/playerdata.json";

    }// Start


    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // เคลื่อนที่ซ้าย-ขวา
        rb2d.linearVelocity = new Vector2(moveInput * speed, rb2d.linearVelocity.y);
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));

        }//Jump
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SavePlayerData();
        }
    }// Update

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            hp -= 10;
            if (hp <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

    }//OnCollisionEnter2D

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }//OnCollisionExit2D

    private void SavePlayerData()
    {
        PlayerStats stats = new PlayerStats
        {
            hp = this.hp,
        };

        string json = JsonUtility.ToJson(stats, true);
        File.WriteAllText(savePath, json);
    }

}//PlayerMovement
