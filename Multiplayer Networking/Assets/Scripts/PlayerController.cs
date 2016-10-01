using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    private float x, z;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        rb2d.rotation -= x;
        rb2d.velocity = transform.up * z * 3.0f;

       // transform.Rotate(0.0f, 0.0f, -x);
        //transform.Translate(0.0f, z, 0.0f);

        if (Input.GetButtonDown("Fire"))
        {
            CmdFire();
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    [Command]
    private void CmdFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 6.0f;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }
}
