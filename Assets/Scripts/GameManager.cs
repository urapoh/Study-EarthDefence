using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const int initialPeople = 8000;

    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] GameObject cometPrefab;
    [SerializeField] float distance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI aliveText;
    private int score;
    private int peopleAlive;
    private int waveBodies;
    private int waveBodiesInit = 15;
    private float spawnDelay = 3f;
    private float spawnDelayInitial = 3f;
    private float timeSpawned;
    private bool isWave;
    private float cooldownTime = 10f;
    private float quickeningMultiplier = 0.95f;

    public static GameManager Instance { get; private set; }
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    public int PeopleAlive
    {
        get
        {
            return peopleAlive;
        }
        set
        {
            if (value >= 0)
            {
                peopleAlive = value;
            }
            else
            {
                peopleAlive = 0;
                Debug.Log("Game Over");
            }
            
            aliveText.text = "Alive:" + peopleAlive + "M";
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PeopleAlive = initialPeople;
        isWave = true;
        timeSpawned = 0;
        waveBodies = waveBodiesInit;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWave)
        {
            if (Time.time - timeSpawned > spawnDelay)
            {
                SpawnBody();
                timeSpawned = Time.time;
                spawnDelay *= quickeningMultiplier;
                waveBodies--;
                if (waveBodies <= 0)
                {
                    isWave = false;
                    StartCoroutine(WaveCooldown());
                }
            }
        }
    }

    IEnumerator WaveCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        waveBodies = waveBodiesInit;
        spawnDelay = spawnDelayInitial;
        isWave = true;
    }

    private void SpawnBody()
    {
        GameObject prefab;
        if (Random.Range(0f, 1f) < 0.8)
        {
            prefab = asteroidPrefab;
        } 
        else
        {
            prefab = cometPrefab;
        }
        
        GameObject cosmicBody = Instantiate(prefab);
        float angle = Random.Range(0f, 360f);
        float x = Mathf.Cos(angle) * distance;
        float y = Mathf.Sin(angle) * distance;
        cosmicBody.transform.position = new Vector3(x, y);
    }
}
