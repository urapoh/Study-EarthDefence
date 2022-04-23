using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicBody : MonoBehaviour
{

    [SerializeField] protected float speed;
    [SerializeField] protected GameObject nuke;

    // Update is called once per frame
    protected virtual void Update()
    {

        // ABSTRACTION
        Move();
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Shield")) {
            // ABSTRACTION
            HitShield();
        }
        else if (other.CompareTag("Earth"))
        {
            // ABSTRACTION
            HitEarth();
        }
    }

    protected virtual void HitShield()
    {
        GameManager.Instance.AddScore(1);
    }

    protected virtual void HitEarth()
    {
        if (nuke != null)
        {
            nuke.SetActive(true);
            nuke.transform.up = transform.position.normalized;
            nuke.transform.SetParent(GameManager.Instance.transform);
        }

        Destroy(gameObject);
    }

    protected virtual void Move()
    {
        transform.position -= transform.position.normalized * speed * Time.deltaTime;
    }

    protected virtual void Rotate()
    {
        float rotX = 5 * Time.deltaTime;
        float rotY = 7 * Time.deltaTime;
        float rotZ = 11 * Time.deltaTime;
        transform.Rotate(rotX, rotY, rotZ, Space.World);
    }
}
