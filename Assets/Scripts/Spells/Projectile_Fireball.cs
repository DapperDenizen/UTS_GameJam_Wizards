using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Fireball : Projectile {

    bool firstCall = false;
    [SerializeField] float forceIncrease = 10f;
    [SerializeField] GameObject xplosion;
    public override void MoveTo()
    {
        if (!firstCall)
        {
            firstCall = true;
            rb.AddForce(heading * forceIncrease, ForceMode.Impulse);
        }
        myTrans.LookAt(myTrans.position+heading);
    }

    public override void OnHit(Collision coll)
    {
        JustDie();
    }


    public override void JustDie()
    {
        if (this == null) { return; }
        RaycastHit[] hit = Physics.SphereCastAll(myTrans.position, radius, myTrans.position);
        if (hit.Length > 0)
        {

            foreach (RaycastHit h in hit)
            {
                if (h.rigidbody != null) {
                    if (h.rigidbody.CompareTag("Wizard"))
                    {
                        //check you can see them
                        RaycastHit rayHit;
                        Ray ray = new Ray(myTrans.position, (myTrans.position - h.point));
                        if (Physics.Raycast(ray, out rayHit, radius))
                        {
                            if (rayHit.transform == h.transform)
                            {

                                float bottomFloat = Vector3.Distance(h.transform.position, this.myTrans.position);
                                if (bottomFloat < 1f) { bottomFloat = 1f; }
                                float newDam = damage / bottomFloat;
                                float newKnock = 10f / bottomFloat;
                                h.transform.GetComponent<PlayerController>().Damage(newDam);
                                h.transform.GetComponent<PlayerController>().Knockback(myTrans.position - h.transform.position, -newKnock, .2f);
                            }
                        }
                    }
                }
                
            }

        }
        Instantiate(xplosion, myTrans.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
