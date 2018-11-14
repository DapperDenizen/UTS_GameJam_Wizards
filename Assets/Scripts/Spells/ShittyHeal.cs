using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyHeal : Spell {


    GameObject toHeal;
    [SerializeField] GameObject myBeam;

    public override string myName()
    {
        return "ShittyHeal";
    }

    public override void Activate(Vector3 origin, Vector3 dir, Transform wizTransform)
    {
        float minDist = float.MaxValue;
        GameObject[] possibles = GameObject.FindGameObjectsWithTag("Wizard");
        foreach (GameObject target in possibles)
        {
            
            if (Vector3.Distance(target.transform.position, origin) < minDist)
            {
                if (target.transform == wizTransform) { continue; } //no heals for yaself buddy!
                minDist = Vector3.Distance(target.transform.position, origin);
                toHeal = target;
            }
        }
        if (toHeal != null)
        {
            //make some effects
           LineRenderer lineRend = Instantiate(myBeam).GetComponent<LineRenderer>();
            lineRend.SetPosition(0, origin);
            lineRend.SetPosition(1, toHeal.transform.position);
            //do it
            toHeal.GetComponent<PlayerController>().Damage(-15f);

        }
    }
}
