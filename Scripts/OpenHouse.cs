using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenHouse : MonoBehaviour
{
    [SerializeField] private float speed;
    private ScoreManager scoreManager;
    [SerializeField] private float buildHealt;
    [SerializeField] GameObject house;
    [SerializeField] Transform transformPoint;
    private Movement.color playerColor;
    [SerializeField] GameObject player;
    [SerializeField] private Movement.color houseColor;
    [SerializeField] private TextMeshProUGUI healthText;
    private bool isBuild = false;
    [SerializeField] string saveCode;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if(PlayerPrefs.HasKey(saveCode))
        {
            buildHealt = PlayerPrefs.GetFloat(saveCode);
            if(buildHealt <= 0)
            {
                house.SetActive(true);
                isBuild = true;
            }
        }
        healthText.text = ((int)(10 * buildHealt)).ToString();
    }
    
    private void OnTriggerStay(Collider other)
    {
        playerColor = player.GetComponent<Movement>().playerColor;
        if (other.gameObject.CompareTag("Player") && playerColor == houseColor)
        {
            if (buildHealt >= 0)
            {
                /*
                if (scoreManager.totalWeightScore <= 1)
                {
                    scoreManager.totalWeightScore = 1;
                }
                else
                {
                    scoreManager.totalWeightScore -= Time.deltaTime * speed;
                    buildHealt -= Time.deltaTime * speed;
                    healthText.text = ((int)(10 * buildHealt)).ToString();
                }
                if (scoreManager.totalHeightScore <= 1)
                {
                    scoreManager.totalHeightScore = 1;
                }
                else
                {
                    scoreManager.totalHeightScore -= Time.deltaTime * speed;
                    buildHealt -= Time.deltaTime * speed;
                    healthText.text = ((int)(10 * buildHealt)).ToString();
                }
                */

                if(scoreManager.totalHeightScore > 0.75f)
                {
                    scoreManager.totalHeightScore -= Time.deltaTime * speed;
                    buildHealt -= Time.deltaTime * speed;
                    healthText.text = ((int)(10 * buildHealt)).ToString();
                }
                else if(scoreManager.totalWeightScore > 0.75f)
                {
                    scoreManager.totalWeightScore -= Time.deltaTime * speed;
                    buildHealt -= Time.deltaTime * speed;
                    healthText.text = ((int)(10 * buildHealt)).ToString();
                }
                else
                {
                    scoreManager.totalHeightScore = 0.75f;
                    scoreManager.totalWeightScore = 0.75f;
                }
            }

            
            else if(buildHealt <= 0 && !isBuild)
            {
                healthText.gameObject.SetActive(false);
                house.SetActive(true);
                CashManager.instance.cash += 150;
                isBuild = true;
            }
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(saveCode, buildHealt);
    }

}
