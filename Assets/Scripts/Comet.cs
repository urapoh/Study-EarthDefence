using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : CosmicBody
{
    protected override void HitEarth()
    {
        base.HitEarth();
        Destroy(gameObject);
        Debug.Log("Game over");
    }

    protected override void HitShield()
    {
        base.HitShield();
        speed = -speed;
    }

    protected override void Move()
    {
        transform.position -= transform.position.normalized * speed * Time.deltaTime;
    }

    protected override void Update()
    {
        base.Update();
        DestroyDistant();
    }

    private void DestroyDistant()
    {
        if (transform.position.magnitude > 40)
        {
            Destroy(gameObject);
        }
    }
}
