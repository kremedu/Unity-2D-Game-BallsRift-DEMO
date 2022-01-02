using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            BallControl playerScript = collision.gameObject.GetComponent<BallControl>();
            //playerScript.ownCoins += 1;
            //int coins = playerScript.ownCoins;
            //Debug.Log("Coins: " + coins);
            CoinText.miktarCoin += 5;
            FindObjectOfType<AudioManager>().Oynat("coinsound");

        }
    }
}
