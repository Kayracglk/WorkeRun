using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    private ScoreManager scoreManager;
    private Transform _transform;
    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        _transform = transform;
    }

    private void Update()
    {
        _transform.localScale = new Vector3(scoreManager.totalWeightScore, scoreManager.totalHeightScore , scoreManager.totalWeightScore);
    }
}
