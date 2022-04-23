using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.back * input);
    }

}
