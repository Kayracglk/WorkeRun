using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float totalHeightScore;
    public float totalWeightScore;

    private float totalScore;

    private void Update()
    {
        totalScore = totalHeightScore + totalWeightScore;
        Debug.Log("total: " + totalScore);
        Debug.Log("kilo : " + totalWeightScore);
        Debug.Log("boy: " + totalHeightScore);
    }

}
