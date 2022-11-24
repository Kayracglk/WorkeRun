using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public VirtualJoystick moveJoystick;
    [SerializeField] private float rotationSpeed = 30f;

    [SerializeField] private Transform camTransform;
    private Transform _transform;

    [SerializeField] private float playerSpeed;

    [SerializeField] float speed; // saga sola gitme hizi
    [SerializeField] float xLimitLeft, xLimitRight; // yolun limitini belirler
    Touch touch;
    float limitedX;

    [SerializeField] private GameObject Finish1;
    [SerializeField] private GameObject Finish2;
    [SerializeField] private GameObject Joystick;
    public enum color { pink , blue , yellow}
    public color playerColor;

    [SerializeField] Animator animator;
    void Awake()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Finish1.GetComponent<FinishPlathform>().isFinishLap || Finish2.GetComponent<FinishPlathform>().isFinishLap)
        {
            JoystickMovement();
        }
        else
        {
            Swerve();
        }
        if(_transform.position.y < 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    private void Swerve()
    {
        limitedX = transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(Mathf.Clamp(limitedX, xLimitLeft, xLimitRight), transform.position.y, transform.position.z); // transform.position.z kismina hizi eklersen dokununca ileri gider
            }
            animator.SetBool("isRun", true);
            _transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    private void JoystickMovement()
    {
        Vector3 dir = Vector3.zero;

        /*
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if(dir.magnitude > 1)
        {
            dir.Normalize();
        }
        */
        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dir = moveJoystick.InputDirection;
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        Vector3 rotateDir = camTransform.TransformDirection(dir);
        rotateDir = new Vector3(rotateDir.x, 0, rotateDir.z);
        rotateDir = rotateDir.normalized * dir.magnitude;
        
        _transform.position = new Vector3(_transform.position.x + rotateDir.x * moveSpeed * Time.deltaTime, _transform.position.y, _transform.position.z + rotateDir.z * moveSpeed *Time.deltaTime);
        if (dir != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), rotationSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Zemin"))
        {
            Joystick.SetActive(true);
        }
    }
}
