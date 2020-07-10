using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager singleton;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 posVec = new Vector3(Random.Range(-100, 100), -2f, Random.Range(-100, 100));
            Instantiate(GetCoinObject(), posVec, transform.rotation);
        }
    }

    private GameObject GetCoinObject()
    {
        return Instantiate(Resources.Load<GameObject>("RPG Pack/Prefabs/Coin") as GameObject);
    }
}
