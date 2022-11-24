using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blocks : MonoBehaviour
{
    [SerializeField] private bool isSum;
    [SerializeField] private float heightScore, weightScore;
    private ScoreManager scoreManager;
    
    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(isSum)
            {
                scoreManager.totalHeightScore += heightScore;
                scoreManager.totalWeightScore += weightScore;
            }
            else
            {
                scoreManager.totalWeightScore *= weightScore;
                scoreManager.totalHeightScore *= heightScore;
            }
            if (scoreManager.totalHeightScore <= 1)
            {
                scoreManager.totalHeightScore = 1;
            }
            if (scoreManager.totalWeightScore <= 1)
            {
                scoreManager.totalWeightScore = 1;
            }
        }
        
    }
}
