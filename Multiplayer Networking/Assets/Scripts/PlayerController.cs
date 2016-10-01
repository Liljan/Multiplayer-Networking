using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private float x, z;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0.0f, 0.0f, -x);
        transform.Translate(0.0f, z, 0.0f);
    }
}
