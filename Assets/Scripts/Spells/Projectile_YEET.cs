using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_YEET : Projectile {

    [SerializeField] float yEETPERCENTAGE = 100f;
    bool directed = false;

    public override void MoveTo()
    {
        if (!directed)
        {

            myTrans.LookAt(myTrans.position - heading);

        }
    }
    public override void JustDie()
    {
        Destroy(gameObject);
    }
    public override void OnHit(Collision coll)
    {
        //dont hit on me!
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Wizard"))
        {
            //yeet them!
            other.GetComponent<PlayerController>().Knockback(myTrans.position - other.transform.position, -yEETPERCENTAGE, 1.0f);

        }
    }

}
