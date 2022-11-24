using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FinishUnderGame : MonoBehaviour
{
    [SerializeField] private Transform transformPoint;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject Upgame1;
    [SerializeField] private GameObject Upgame2;
    [SerializeField] private GameObject Finish1;
    [SerializeField] private GameObject Finish2;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject TapToStart;
    [SerializeField] private GameObject player;
    private ScoreManager scoreManager;
    [SerializeField] Animator animator;
    [SerializeField] GameObject camUp;
    [SerializeField] GameObject camUnder;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = transformPoint.position;
            joystick.SetActive(false);
            if (Upgame2.activeInHierarchy == false)
            {
                Upgame1.SetActive(false);
                Upgame2.SetActive(true);

            }
            else
            {
                Upgame1.SetActive(true);
                Upgame2.SetActive(false);

            }
            if (scoreManager.totalHeightScore > 1 || scoreManager.totalWeightScore > 1)
            {
                CashManager.instance.cash += (int)((scoreManager.totalHeightScore - 1) * 10) + (int)((scoreManager.totalWeightScore - 1) * 10);
                scoreManager.totalHeightScore = 1;
                scoreManager.totalWeightScore = 1;
            }
            Finish1.GetComponent<FinishPlathform>().isFinishLap = false;
            Finish2.GetComponent<FinishPlathform>().isFinishLap = false;
            Shop.SetActive(true);
            TapToStart.SetActive(true);
            player.GetComponent<Movement>().enabled = false;
            animator.SetBool("isRun", false);
            camUp.SetActive(true);
            other.transform.rotation = Quaternion.EulerAngles(Vector3.zero);
            camUp.GetComponent<CinemachineVirtualCamera>().Follow = other.transform.GetChild(1);
            camUnder.SetActive(false);
        }
    }
}
