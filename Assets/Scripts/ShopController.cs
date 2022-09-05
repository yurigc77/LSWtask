using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopController : MonoBehaviour
{
    public static ShopController instance;


    public GameObject BuyMenu;
    public GameObject Dialog;




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

        
    }


    public void OpenBuyMenu()
    {
        CloseMenus();
        BuyMenu.SetActive(true);
       // inventory.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenus()
    {
        BuyMenu.SetActive(false);
        Dialog.SetActive(false);
        //inventory.SetActive(false);
        Time.timeScale = 1;
    }


    public void OpenDialog()
    {
        Dialog.SetActive(true);
        Time.timeScale = 0;
    }

  
}

