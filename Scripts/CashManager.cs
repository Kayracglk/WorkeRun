using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    public int cash = 100;
    [SerializeField] Text scoreManager;

    private void Awake()
    {
        instance = this;
        cash = PlayerPrefs.GetInt("cash");
    }
    private void Update()
    {
        scoreManager.text = cash.ToString();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("cash", cash);
    }
}
