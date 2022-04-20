using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicBody : MonoBehaviour
{

    [SerializeField] protected float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Shield")) {
            HitShield();
        }
        else if (other.CompareTag("Earth"))
        {
            HitEarth();
        }
    }

    protected virtual void HitShield()
    {

    }

    protected virtual void HitEarth()
    {

    }

    protected virtual void Move()
    {
        transform.position -= transform.position.normalized * speed * Time.deltaTime;
    }
}
