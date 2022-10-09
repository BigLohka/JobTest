using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Text gameFinishText;
    [SerializeField] private Text scoreText;
    private int score;

    public void Start()
    {
        gameFinishText.text = PlayerPrefs.GetInt("Result") == 0 ? "�� ���������!" : "�� ��������!";
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = ("��� ��������� ") + score.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.DeleteAll();
    }
}
