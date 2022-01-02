using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject levelEndMenu;

    private void Awake()
    {
        endMenu.SetActive(false);
        levelEndMenu.SetActive(false);
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
        CoinText.miktarCoin = 0;
        endMenu.SetActive(false);
        levelEndMenu.SetActive(false);
    }
}
