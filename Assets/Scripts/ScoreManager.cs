using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    private int BestScore = 0;
    public Text ScoreText;
    // Use this for initialization
    void Awake()
    {
        ScoreText = GetComponent<Text>(); //поиск текста 
        BestScore = PlayerPrefs.GetInt("betsScore");//возвращаем максимальное значение
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;
        if (score > BestScore)
        {
            BestScore = score;
        }
        GameObject.Find("Score").GetComponent<Text>().text = "Score:" + score;//меняем количество попаданий 
        // GameObject.Find("Best").GetComponent<Text>().text = "Best:" + PlayerPrefs.GetInt("betsScore");
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("bestScore", BestScore);
        PlayerPrefs.Save();
    }
}
