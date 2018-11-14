using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Spell {

    [SerializeField] float maxDist;
    [SerializeField] GameObject ninjaSmoke;
    [SerializeField] float chargeTime;
    public override float ChargeTime()
    {
        return chargeTime;
    }
    public override string myName()
    {
        return "Teleport";
    }

    public override void Activate(Vector3 origin, Vector3 dir, Transform wizTransform)
    {
        Instantiate(ninjaSmoke, origin,Quaternion.identity);
        Ray myRay = new Ray(origin, dir);

        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, maxDist))
        {
            if (hit.transform.CompareTag("Wizard")) {
                //hurt wizard and knock them back
                PlayerController target = hit.transform.GetComponent<PlayerController>();
                target.Damage(1f);
                target.Knockback(hit.point - origin, 5f, .2f);
                
            }
            //we hit something so go there and get knocked a bit!
            wizTransform.position =  new Vector3 (hit.point.x, 0.51f,hit.point.z);
            wizTransform.GetComponent<PlayerController>().Knockback(origin - hit.point, 2.5f, .1f);
            Instantiate(ninjaSmoke, hit.point, Quaternion.identity);
        }
        else
        {
            Vector3 finalDir = dir + dir.normalized * maxDist;
            Vector3 targetPos = origin + finalDir;
            targetPos.y = 0.51f;
            wizTransform.position = targetPos;
            Instantiate(ninjaSmoke, targetPos, Quaternion.identity);
        }
       
    }

}
