using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coinsCount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin")){
            Pickup pickup = col.gameObject.GetComponent<Pickup>();
            coinsCount += pickup.coinValue;
            Destroy(col.gameObject);
            Debug.Log("Coins: " + coinsCount);
        }
    }

}
