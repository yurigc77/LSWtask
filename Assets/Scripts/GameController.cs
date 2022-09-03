using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int Money;
    public TextMeshProUGUI MoneyText;
    public GameObject BuyMenu;
    public GameObject Dialog;
    public GameObject inventory;

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


            MoneyText.text = "x " + Money.ToString();
        
    }

    public void GetMoney(Item item)
    {
        Money=Money+(item.price/2);

        MoneyText.text = "x " + Money.ToString();

        PlayerPrefs.SetInt("money", Money);
    }

    public void LooseMoney()
    {
        Money--;

        MoneyText.text = "x " + Money.ToString();

        PlayerPrefs.SetInt("money", Money);
    }



    public void OpenBuyMenu()
    {
        CloseMenus();
        BuyMenu.SetActive(true);
        inventory.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenus()
    {
        BuyMenu.SetActive(false);
        Dialog.SetActive(false);
        inventory.SetActive(false);
        Time.timeScale = 1;
    }


    public void OpenDialog()
    {
        Dialog.SetActive(true);
        Time.timeScale = 0;
    }

  
}

