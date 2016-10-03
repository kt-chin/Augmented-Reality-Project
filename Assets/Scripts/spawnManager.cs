using UnityEngine;
using System.Collections;


//abstract public class Damage
//{
//    public int dmg = Random.Range(5, 12);
//    public void DamageEnemy()
//    {
    
//    }
//}

public class maingameManager : MonoBehaviour
{

    private float spawnRadius = 20.0f;
    private float Max = 80.0f;
    private float Min = -80.0f;
    public Transform playerLocation;
    public GameObject Enemies;
   //public int damageAmount;
    private Vector3 mobSpawnLocation;
    private Vector3 ran;
    private int maxAmount = 8;
    private int currentAmount;
    private bool startSpawn = true;
    private float spawnTimer;
    private float xPos;
    private float yPos = 0.0f;
    private float zPos = 0.0f;
    private float minEnemyDensity = 6f;
    private float minSpawnDistance = 20f;
    private int xHeight;
    private int yHeight;

    void Start()
    {
        currentAmount = 0;
    }


    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 spawnPoint = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 lastSpawnPoint = Vector3.zero;
        spawnTimer -= Time.deltaTime;
        //Debug.Log(spawnTimer);
       // Debug.Log(currentAmount);
        currentAmount = enemies.Length;
        xPos = Random.Range(Min, Max);
        zPos = Random.Range(Min, Max);

        if (spawnTimer < 0.0f)
        {
            if (startSpawn)
            {
                spawnTimer = 2.0f;
                if (currentAmount <= maxAmount)
                {
                    if ((spawnPoint - playerLocation.position).magnitude >= minSpawnDistance || (spawnPoint - lastSpawnPoint).magnitude >= minEnemyDensity)
                    {

                        Vector3 ran = new Vector3(xPos, 0, zPos);

                        mobSpawnLocation = ran;
                        
                        Instantiate(Enemies, mobSpawnLocation, transform.rotation);
                        
                        currentAmount += 1;
                    }
                }
            }
        }


    }

}