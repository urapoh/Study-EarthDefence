using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Asteroid : CosmicBody
{
    [SerializeField] protected int deathOnImpact;

    // POLYMORPHISM
    protected override void HitEarth()
    {
        base.HitEarth();

        GameManager.Instance.PeopleAlive -= deathOnImpact;
    }

    // POLYMORPHISM
    protected override void HitShield()
    {
        base.HitShield();
        Destroy(gameObject);
    }
}
