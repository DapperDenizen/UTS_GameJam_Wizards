using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyHeal : Spell {


    GameObject toHeal;
    [SerializeField] GameObject myBeam;
    [SerializeField] float minHeal = 5f;
    [SerializeField] float maxHeal = 15f;
    [SerializeField] float chargeTime;
    public override float ChargeTime()
    {
        return chargeTime;
    }

    public override string myName()
    {
        return "Heal";
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
            toHeal.GetComponent<PlayerController>().Damage(-Random.Range(minHeal,maxHeal));

        }
    }
}
