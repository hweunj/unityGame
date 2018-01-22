using UnityEngine;
using System.Collections;

public class ball3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
    }
}
