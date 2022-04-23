using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Comet : CosmicBody
{
    [SerializeField] protected float deathOnImpact;

    // POLYMORPHISM
    protected override void HitEarth()
    {
        base.HitEarth();
        
        GameManager.Instance.PeopleAlive = Mathf.CeilToInt(GameManager.Instance.PeopleAlive / deathOnImpact);
    }

    // POLYMORPHISM
    protected override void HitShield()
    {
        base.HitShield();
        speed = -speed;
    }

    // POLYMORPHISM
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
