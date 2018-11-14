using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell {

    public GameObject fireballRef;

    public override string myName()
    {
        return "Fireball";
    }
    public override void Activate(Vector3 origin, Vector3 dir, Transform wizTransform)
    {
        //fireballRef = (GameObject)Resources.Load("Resources/SpellGameObjects/FireOBall");
        GameObject temp = Instantiate(fireballRef,origin,Quaternion.identity);
        temp.GetComponent<Projectile>().InitialiseMe(dir, true);
        /*
        RaycastHit hit;
        Ray ray = new Ray(origin, dir);
        if (Physics.Raycast(ray,out hit, maxDist))
        {
            //we have hit something
        }//*/

    }
}
