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
    private int score;

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

        InvokeRepeating("SpawnBoby", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
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
