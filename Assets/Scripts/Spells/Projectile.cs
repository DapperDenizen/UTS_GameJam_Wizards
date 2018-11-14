using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {
    public Vector3 heading;
    public float timeAlive = 0;
    public Transform myTrans;
    public Rigidbody rb;
    public float radius;
    public float damage;
	// Use this for initialization
	void Awake () {
        myTrans = GetComponent<Transform>();
	}
    public void InitialiseMe(Vector3 headed, bool hasLifeTime)
    {
        heading = headed;
        if (hasLifeTime) {
            Invoke("JustDie", timeAlive);
        }
        
    }
    public abstract void MoveTo();
    public abstract void JustDie();
    public abstract void OnHit(Collision coll);
	// Update is called once per frame
	void FixedUpdate ()
    {
        MoveTo();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.CompareTag("Wizard")) {
            OnHit(collision);
            //JustDie();

        
    }


}
