using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y33T : Spell {
    [SerializeField] GameObject yeetRef;

    public override string myName()
    {
        return "Y33T";
    }

    public override void Activate(Vector3 origin, Vector3 dir, Transform wizTransform)
    {
        GameObject temp = Instantiate(yeetRef, origin + dir, Quaternion.identity);
        temp.GetComponent<Projectile_YEET>().InitialiseMe(dir, true);
    }
}
