using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {

    public int coinValue = 1;
    public bool taken = false;
    public GameObject explosion;

    public enum collectedItems {Coin,Life,OrangeMushroom,RedMushroom};

    public collectedItems item = collectedItems.Coin; 

	// if the player touches the coin, it has not already been taken, and the player can move (not dead or victory)
	// then take the coin
	void OnTriggerEnter2D (Collider2D other)
	{
		if ((other.tag == "Player" ) && (!taken) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
		{
			// mark as taken so doesn't get taken multiple times
			taken=true;

			// if explosion prefab is provide, then instantiate it
			if (explosion)
			{
				Instantiate(explosion,transform.position,transform.rotation);
			}

            switch(item)
            {
                case collectedItems.Coin:
                    other.gameObject.GetComponent<CharacterController2D>().CollectCoin(coinValue);
                    break;

                case collectedItems.Life:
                    other.gameObject.GetComponent<CharacterController2D>().CollectLife();
                    break;

                case collectedItems.OrangeMushroom:
                    other.gameObject.GetComponent<CharacterController2D>().CollectOrangeMushroom();
                    break;

                case collectedItems.RedMushroom:
                    other.gameObject.GetComponent<CharacterController2D>().CollectRedMushroom();
                    break;
            }

			// destroy the coin
			DestroyObject(this.gameObject);
		}
	}

}
