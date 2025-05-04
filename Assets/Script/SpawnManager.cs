using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoints;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2, 1);
    }

    void SpawnEnemy()
    {
        if (enemy.Length == 0 || spawnPoints.Length == 0) return;

        // เลือกศัตรูแบบสุ่ม
        int enemyIndex = Random.Range(0, enemy.Length);

        // เลือกจุด spawn แบบสุ่ม
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // สร้างศัตรู
        Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
    }
}
