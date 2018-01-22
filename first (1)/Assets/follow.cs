using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {
    public Transform targetTR;
    public float dist = 3.0f;
    public float height = 3.0f;
    public float dampTrace = 10.0f;
    private Transform tr;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
//        System.Threading.Thread.Sleep(5000);
        tr.position = Vector3.Lerp(tr.position, targetTR.position - (targetTR.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
        tr.LookAt(targetTR.position);
	}
}
