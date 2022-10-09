using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinsCollection : MonoBehaviour
{
    [SerializeField] private Text coinsTexting;
    [SerializeField] private int coinsCounter;

    private ObjCreator _oc;
    private void Start()
    {
        coinsTexting.text = "0";
        _oc = FindObjectOfType<ObjCreator>();
    }

    private void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        //interactable
        //interface
        if (col.CompareTag("Coin"))
        {
            coinsCounter++;
            coinsTexting.text = coinsCounter.ToString();
            Destroy(col.gameObject);
            PlayerPrefs.SetInt("Result", 1);
            if(coinsCounter == _oc.coinsCount)
            {
                SceneManager.LoadScene(1);
                PlayerPrefs.SetInt("Score", coinsCounter);
            }

        }
        if(col.CompareTag("Spike"))
        {
            PlayerPrefs.SetInt("Score", coinsCounter);
            PlayerPrefs.SetInt("Result", 0);
            SceneManager.LoadScene(1);
        }
    }

}
