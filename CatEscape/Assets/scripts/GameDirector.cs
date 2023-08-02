using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject catGo;
    private GameObject hpGaugeGo;
    private GameObject scoreGo;
    public GameObject gameoverGo;
    
    void Start()
    {
        this.catGo = GameObject.Find("cat");
        this.hpGaugeGo = GameObject.Find("hpGauge");
        this.gameoverGo = GameObject.Find("GameOver");
        this.scoreGo = GameObject.Find("Score");

        Debug.LogFormat("this.cat{0}, this. hp{1}", this.catGo, this.hpGaugeGo);

        Image hpGauge = this.hpGaugeGo.GetComponent<Image>();

    }
    public void DecreasHp()
    {
        Image hpGauge = this.hpGaugeGo.GetComponent<Image>();
        hpGauge.fillAmount -= 0.1f;

        if (hpGauge.fillAmount <= 0)
        {
            Text text = gameoverGo.GetComponent<Text>();
            text.text = text.ToString();
            text.text = string.Format("Game over");
        }
    }
    public void IncreaseScore()
    {
        int score = 0;
        Text text = scoreGo.GetComponent<Text>();
        text.text = score.ToString();

    }
}

