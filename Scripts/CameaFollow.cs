using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameaFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 fark;
    [SerializeField] private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        fark = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetView = fark + target.position;
            transform.position = Vector3.Lerp(transform.position, targetView, speed * Time.deltaTime);
            transform.LookAt(target.transform.position);
        }
    }
}
