using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinsCollection : MonoBehaviour
{
    [SerializeField] private Text coinsTexting;
    [SerializeField] private int coinsCounter;

    private ObjCreator objectCreator;
    private void Start()
    {
        coinsTexting.text = "0";
        objectCreator = FindObjectOfType<ObjCreator>();
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            coinsCounter++;
            coinsTexting.text = coinsCounter.ToString();
            Destroy(col.gameObject);
            if (coinsCounter == objectCreator.coinsCount)
            {
                PlayerPrefs.SetInt("Result", 1);
                PlayerPrefs.SetInt("Score", coinsCounter);
                SceneManager.LoadScene("Restart");
            }
        }
        if (col.CompareTag("Spike"))
        {
            PlayerPrefs.SetInt("Score", coinsCounter);
            PlayerPrefs.SetInt("Result", 0);
            SceneManager.LoadScene("Restart");
        }
    }

}
