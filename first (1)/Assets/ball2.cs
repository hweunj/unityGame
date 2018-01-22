using UnityEngine;
using System.Collections;

public class ball2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        var amtMove = 5 * Time.deltaTime;
        var ver = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * ver * amtMove);
        transform.Translate(Vector3.right * hor * amtMove);

    }

}
