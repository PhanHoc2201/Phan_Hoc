using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Enter2D_For_Default_Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);
        }
    }
}
