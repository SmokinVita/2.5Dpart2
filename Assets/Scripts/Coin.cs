using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            collider.GetComponent<Player>().UpdateCoinAmount();
            Destroy(this.gameObject);
        }
    }
}
