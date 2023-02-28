using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tele_port_Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            PlayerController.instance.transform.position = gameObject.transform.position;
        }
    }


}
