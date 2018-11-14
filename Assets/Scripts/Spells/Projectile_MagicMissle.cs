using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_MagicMissle : Projectile {

    GameObject target;
    [SerializeField] float speed = 1f;
    private bool justSpawned = true;
	// Use this for initialization
	void Start () {
        float minDist = float.MinValue;
        GameObject[] possibles = GameObject.FindGameObjectsWithTag("Wizard");
        foreach (GameObject target in possibles)
        {

            if (Vector3.Distance(target.transform.position, myTrans.position) > minDist)
            {

                minDist = Vector3.Distance(target.transform.position, myTrans.position);
                this.target = target;
            }
        }
        if (target == null) { JustDie(); }
        transform.LookAt(target.transform.position);
        Invoke("TargetAcquired", .2f);
	}

    void TargetAcquired() {
        justSpawned = false;
    }

    public override void MoveTo()
    {
        //direction to target
        if (justSpawned)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        else {
            if (target == null) { JustDie(); }
            else
            {
                heading = target.transform.position - myTrans.position;
                rb.AddForce(heading * speed, ForceMode.Acceleration);
            }
        }

    }

    public override void OnHit(Collision coll)
    {
        if(coll.transform.CompareTag("Wizard"))
        {
            coll.transform.GetComponent<PlayerController>().Damage(damage);
            coll.transform.GetComponent<PlayerController>().Knockback(myTrans.position - coll.transform.position,1.1f, .1f);
            JustDie();
        }
        if (!coll.transform.CompareTag("MM")) { JustDie(); }
    }

    public override void JustDie()
    {
        Destroy(gameObject);
    }



}
