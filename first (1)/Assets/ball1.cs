using UnityEngine;
using System.Collections;

public class ball_bounce_sound : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var power = 500; var speed = 5; var rotSpeed = 120;
        var amtMove = speed * Time.deltaTime;  // 매 프레임 이동거리        
        var amtRot = rotSpeed * Time.deltaTime;

        var ver = Input.GetAxis("Vertical");
        var ang = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.left * ver * amtMove);
        transform.Rotate(Vector3.up * ang * amtRot);

        if (Input.GetButtonDown("Fire1"))
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * power);
    }

}
