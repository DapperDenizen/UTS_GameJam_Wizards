using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletSelf : MonoBehaviour {
    [SerializeField] float lifeTime;
	// Use this for initialization
	void Start () {
        Invoke("Delete", lifeTime);
	}

    void Delete() {
        Destroy(gameObject);
    }
}
