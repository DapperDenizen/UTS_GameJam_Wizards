using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour {
    public abstract string myName();
    public abstract float ChargeTime();
    public abstract void Activate(Vector3 origin, Vector3 dir ,Transform wizTransform);
}
