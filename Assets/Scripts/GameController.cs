using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int Money;
    public Text MoneyText;

    private void Awake()
    {
        Time.timeScale = 1;

        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.GetInt("money") > 0)
        {
            Money = PlayerPrefs.GetInt("money");
            MoneyText.text = "x " + Money.ToString();
        }
    }

    public void GetMoney()
    {
        Money++;

        MoneyText.text = "x " + Money.ToString();

        PlayerPrefs.SetInt("money", Money);
    }

    public void LooseMoney()
    {
        Money--;

        MoneyText.text = "x " + Money.ToString();

        PlayerPrefs.SetInt("money", Money);
    }

}

