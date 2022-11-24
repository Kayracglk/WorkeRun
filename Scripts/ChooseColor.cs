using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseColor : MonoBehaviour
{

    [SerializeField] private GameObject pink;
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject yellow;
    private Transform _transform;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject player2;
    [SerializeField] private Material[] material;
    private Renderer rend;
    [SerializeField] GameObject lock1;
    [SerializeField] private GameObject lock2;
    [SerializeField] private Button blueButton;
    [SerializeField] private Button yellowButton;
    [SerializeField] private GameObject buyButtonYellow;
    [SerializeField] private GameObject buyButtonBlue;
    private int isOpen1 = 0;
    private int isOpen = 0;

    private void Awake()
    {
        _transform = transform;
        rend = player2.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        if (PlayerPrefs.HasKey("blue"))
        {
            isOpen = PlayerPrefs.GetInt("blue");
            
            if (isOpen == 1)
            {
                Destroy(lock2);
                Destroy(buyButtonBlue);
                blueButton.interactable = true;
            }
        }
        if(PlayerPrefs.HasKey("yellow"))
        {
            isOpen1 = PlayerPrefs.GetInt("yellow");
            if (isOpen1 == 1)
            {
                Destroy(lock1);
                Destroy(buyButtonYellow);
                yellowButton.interactable = true;
            }
        }
        
        
    }
    public void PinkButton()
    {
        _transform.position = pink.transform.position;
        player.GetComponent<Movement>().playerColor = Movement.color.pink;
        rend.sharedMaterial = material[0];
    }

    public void BlueButton()
    {
        _transform.position = blue.transform.position;
        player.GetComponent<Movement>().playerColor = Movement.color.blue;
        rend.sharedMaterial = material[1];
    }

    public void YellowButton()
    {
        _transform.position = yellow.transform.position;
        player.GetComponent<Movement>().playerColor = Movement.color.yellow;
        rend.sharedMaterial = material[2];
    }

    public void BuyBlue()
    {
        if (CashManager.instance.cash >= 700)
        {
            CashManager.instance.cash -= 700;
            Destroy(lock2);
            Destroy(buyButtonBlue);
            blueButton.interactable = true;
            isOpen = 1;
            PlayerPrefs.SetInt("blue", isOpen);
        }
        
    }

    public void BuyYellow()
    {
        if(CashManager.instance.cash >= 300)
        {
            CashManager.instance.cash -= 300;
            Destroy(lock1);
            Destroy(buyButtonYellow);
            yellowButton.interactable = true;
            isOpen1 = 1;
            PlayerPrefs.SetInt("yellow", isOpen1);
        }
    }
    
}
