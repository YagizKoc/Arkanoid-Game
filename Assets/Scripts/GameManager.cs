using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public bool isGameOver;
    [SerializeField] List<GameObject> powerUps = new List<GameObject>();
    private void Awake()
    {
        //Singleton check
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public void GameOverCheck() 
    {
        if (GameObject.FindGameObjectWithTag("Ball") == null)
        {
            isGameOver = true;
        }
    }

    private void Update()
    {
        GameOverCheck();
    }
    public int GenerateRandomN(int n) 
    {
        return n = Random.Range(0, n+1);
    }

    public void InsantiatePowerUp() 
    { 
        int roll = Random.Range(0, powerUps.Count);
        float spawnRollX = Random.Range(-1.4f, 1.4f);
        Instantiate(powerUps[roll], new Vector3 (spawnRollX,0.8f,-1), Quaternion.identity);
    }
}
