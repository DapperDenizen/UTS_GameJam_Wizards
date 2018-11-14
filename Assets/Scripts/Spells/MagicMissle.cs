using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissle : Spell {
    [SerializeField]GameObject MagicMissRef;

    public override string myName()
    {
        return "MagicMissle";
    }

    public override void Activate(Vector3 origin, Vector3 dir, Transform wizTransform)
    {
        GameObject temp = Instantiate(MagicMissRef, origin+(Vector3.left*0.5f), Quaternion.identity);
        temp.GetComponent<Projectile>().InitialiseMe(dir, true);
        GameObject temp1 = Instantiate(MagicMissRef, origin+(Vector3.right * 0.5f), Quaternion.identity);
        temp1.GetComponent<Projectile>().InitialiseMe(dir, true);
        GameObject temp2 = Instantiate(MagicMissRef, origin, Quaternion.identity);
        temp2.GetComponent<Projectile>().InitialiseMe(dir, true);
    }
}
