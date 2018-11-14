using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogetMeNot : Spell {
    GameObject toForget;
    [SerializeField] float maxDist = 6f;
    [SerializeField] GameObject forgetfulPoof;
    [SerializeField] GameObject forgetfullBeam;
    [SerializeField] float chargeTime;
    public override float ChargeTime()
    {
        return chargeTime;
    }
    public override string myName()
    {
        return "FogetMeNot";
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
                toForget = target;
            }
        }

        if (toForget != null)
        {
            LineRenderer lineRend = Instantiate(forgetfullBeam).GetComponent<LineRenderer>();
            lineRend.SetPosition(0, origin);
            lineRend.SetPosition(1, toForget.transform.position);
            PlayerController pTarget = toForget.GetComponent<PlayerController>();
            pTarget.AddSpell(pTarget.myDad.GetNewSpell());
            Instantiate(forgetfulPoof, pTarget.transform.position, Quaternion.identity);
        }

        


    }
}
