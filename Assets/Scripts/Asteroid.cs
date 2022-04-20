using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : CosmicBody
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
        Destroy(gameObject);
    }
}
