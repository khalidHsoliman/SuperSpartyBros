using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    bool _taken;
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Player") && (!_taken) && (collision.gameObject.GetComponent<CharacterController2D>().playerCanMove))
        {
            _taken = true;

            if (explosion)
                Instantiate(explosion, transform.position, transform.rotation);

            collision.gameObject.GetComponent<CharacterController2D>().CollectLife();

            DestroyObject(this.gameObject);
        }
    }
}
