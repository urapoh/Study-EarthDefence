using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : CosmicBody
{
    [SerializeField] protected int deathOnImpact;
    protected override void HitEarth()
    {
        base.HitEarth();
        Destroy(gameObject);
        //Debug.Log("Game over");
        GameManager.Instance.PeopleAlive -= deathOnImpact;
    }

    protected override void HitShield()
    {
        base.HitShield();
        Destroy(gameObject);
    }
}
