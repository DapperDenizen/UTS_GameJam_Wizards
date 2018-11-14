using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : Spell {
    [SerializeField] GameObject pushRef;
    [SerializeField] float chargeTime;
    public override float ChargeTime()
    {
        return chargeTime;
    }
    public override string myName()
    {
        return "Push";
    }

    public override void Activate(Vector3 origin, Vector3 dir, Transform wizTransform)
    {
        GameObject temp = Instantiate(pushRef, origin + (dir*2f), Quaternion.identity);
        temp.GetComponent<Projectile_Push>().InitialiseMe(dir, true);
    }
}
