using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] GameObject cometPrefab;
    [SerializeField] float distance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI aliveText;
    private int score;
    private int peopleAlive;
    //private float birthRate = 

    private const int initialPeople = 8000;
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

    public static GameManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        PeopleAlive = initialPeople;
        InvokeRepeating("SpawnBoby", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //PeopleAlive +=
    }

    private void SpawnBoby()
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
