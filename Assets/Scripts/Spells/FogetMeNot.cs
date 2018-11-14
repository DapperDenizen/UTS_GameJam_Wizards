using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogetMeNot : Spell {

    [SerializeField] float maxDist = 6f;
    [SerializeField] GameObject forgetfulPoof;
    public override string myName()
    {
        return "FogetMeNot";
    }

    public override void Activate(Vector3 origin, Vector3 dir, Transform wizTransform)
    {
        Ray myRay = new Ray(origin, dir);

        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, maxDist))
        {

            if (hit.transform.CompareTag("Wizard")) {

                PlayerController target = hit.transform.GetComponent<PlayerController>();
                target.AddSpell(target.myDad.GetNewSpell());
                Instantiate(forgetfulPoof, target.transform.position, Quaternion.identity);
                //MAXIMUM HACKINESS
            }

        }


    }
}
