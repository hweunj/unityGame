using UnityEngine;
using System.Collections;

public class BarrelCtrl1 : MonoBehaviour {
	public GameObject expEffect;
	private Transform tr;
	private int hitCount = 0;
	public Texture[] textures;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
		int idx = Random.Range(0, textures.Length);
		GetComponentInChildren<MeshRenderer>().material.mainTexture = textures [idx];
	}
	void OnCollisionEnter(Collision coll){
		if (coll.collider.tag == "BULLET")
			Destroy(coll.gameObject);
		if (++hitCount >= 1)
			ExpBarrel ();
	}
	void ExpBarrel(){
		Instantiate(expEffect, tr.position, Quaternion.identity);
		Collider[] colls = Physics.OverlapSphere(tr.position, 10.0f);
		foreach (Collider coll in colls) {
			Rigidbody rbody = coll.GetComponent<Rigidbody> ();
			if (rbody != null) {
				rbody.mass = 1.0f;
				rbody.AddExplosionForce (2000.0f, tr.position, 10.0f, 300.0f);
			}
		}
		Destroy(gameObject, 5.0f);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
