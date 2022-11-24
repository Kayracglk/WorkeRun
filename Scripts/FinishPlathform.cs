using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FinishPlathform : MonoBehaviour
{
    public bool isFinishLap = false;
    [SerializeField] GameObject player;
    Rigidbody rb;
    [SerializeField] GameObject Joystick;
    [SerializeField] GameObject camUp;
    [SerializeField] GameObject camUnder;
 
    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isFinishLap = true;
            CashManager.instance.cash += 100;
            camUp.SetActive(false);
            other.transform.rotation = Quaternion.EulerAngles(Vector3.zero);
            camUnder.SetActive(true);
            camUnder.GetComponent<CinemachineVirtualCamera>().transform.rotation = Quaternion.EulerAngles(46.9f, 0, 0);
            camUnder.GetComponent<CinemachineVirtualCamera>().Follow = other.transform.GetChild(1);
            camUnder.GetComponent<CinemachineVirtualCamera>().transform.rotation = Quaternion.EulerAngles(46.9f, 0, 0);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 5,rb.velocity.z + 5);
        }
    }
}
