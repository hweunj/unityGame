using UnityEngine;
using System.Collections;

public class Wallctrl : MonoBehaviour {
//	public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET")
        {
//			GameObject spark = (GameObject)Instantiate(sparkEffect, coll.transform.position, Quaternion.identity);
//			Destroy (spark, spark.GetComponent<ParticleSystem>().duration + 0.05f);
           	Destroy(coll.gameObject, 1.0f);
        }
    }
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
    }
}
