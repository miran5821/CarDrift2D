using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnTransforms;

    [SerializeField] GameObject shield;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject oil;
    [SerializeField] GameObject nitro;
    [SerializeField] GameObject barrier;
    [SerializeField] float spawnTimer, coinSpawnTimer, shieldSpawnTimer,oilSpawnTimer,nitroSpawnTimer, barrierSpawnTimer;

    float timer, coinTimer, shieldTimer,oilTimer,nitroTimer,barrierTimer;

    int spawnIndex;
    [SerializeField] GameObject[] policeCars;
    [SerializeField] GameObject[] shieldObject;

    private void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
            timer += Time.deltaTime;

            if (timer >= spawnTimer)
            {
                PoliceCarSpawner();
                timer = 0;
            }

            shieldTimer += Time.deltaTime;

            if (shieldTimer > shieldSpawnTimer)
            {
                float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);
                GameObject shieldObject = Instantiate(shield, spawnPos, Quaternion.identity);
                shieldTimer = 0;
                Destroy(shieldObject, 5f);

            }


            coinTimer += Time.deltaTime;

            if (coinTimer > coinSpawnTimer)
            {
                float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);
                GameObject coinObject = Instantiate(coin, spawnPos, Quaternion.identity);
                coinTimer = 0;
                Destroy(coinObject, 5f);

            }

            oilTimer += Time.deltaTime;

            if (oilTimer > oilSpawnTimer)
            {
                float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);
                GameObject oilObject = Instantiate(oil, spawnPos, Quaternion.identity);
                oilTimer = 0;
                Destroy(oilObject, 5f);

            }

            nitroTimer += Time.deltaTime;

            if (nitroTimer > nitroSpawnTimer)
            {
                float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);
                GameObject nitroObject = Instantiate(nitro, spawnPos, Quaternion.identity);
                nitroTimer = 0;
                Destroy(nitroObject, 5f);

            }
            barrierTimer += Time.deltaTime;

            if (barrierTimer > barrierSpawnTimer)
            {
                float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);
                GameObject barrierObject = Instantiate(barrier, spawnPos, Quaternion.Euler(0,0,Random.Range(-90,90)));
                barrierTimer = 0;
                Destroy(barrierObject, 15f);

            }
        }
    }
    


    void PoliceCarSpawner()
    {
        if (spawnIndex <= 14)
        {
            int index = Random.Range(0, 9);
            policeCars[spawnIndex].gameObject.SetActive(true);
            policeCars[spawnIndex].transform.position = spawnTransforms[index].position;
            spawnIndex++;
        }
        else
        {
            int index = Random.Range(0, 9);
            spawnIndex = 0;
            policeCars[spawnIndex].gameObject.SetActive(true);
            policeCars[spawnIndex].transform.position = spawnTransforms[index].position;
        }
    }
}



