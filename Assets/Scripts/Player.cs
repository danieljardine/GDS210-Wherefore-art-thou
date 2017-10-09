using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameManager gameManager;

    public KeyCode kcNegative = KeyCode.W;
    public KeyCode kcPositive = KeyCode.S;
    public KeyCode Yawleft = KeyCode.A;
    public KeyCode Yawright = KeyCode.D;

    public Vector3 v3Rotation = new Vector3(0.0f, 1.0f, 0.0f);
    public Vector3 Yaw = new Vector3(1.0f, 0.0f, 0.0f);

    public float movementSpeed;
    private float inLight = 0f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
           if (Input.GetKey(kcPositive))
               transform.Rotate(v3Rotation);
           if (Input.GetKey(kcNegative))
               transform.Rotate(-v3Rotation);
           if (Input.GetKey(Yawleft))
               transform.Rotate(Yaw);
           if (Input.GetKey(Yawright))
               transform.Rotate(-Yaw);
               
        movementSpeed += movementSpeed * 0.1f;
        movementSpeed = ClampValue(movementSpeed, -10, 20);
        rb.MovePosition(gameObject.transform.position + gameObject.transform.right * movementSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monk"))
        {
            AudioSource Collect = GetComponent<AudioSource>();
            Collect.Play();
            gameManager.score += 50;
            gameManager.curentMonks += 1;
        }
        if (gameManager.curentMonks >= 1 && other.gameObject.CompareTag("Skyspace"))
        {
            AudioSource Collect = GetComponent<AudioSource>();
            Collect.Play();
            gameManager.score += 50 * gameManager.curentMonks;
            gameManager.curentMonks -= gameManager.curentMonks;
            gameManager.monks += gameManager.curentMonks;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            movementSpeed = -5;
            movementSpeed += 6;
            AudioSource Hit = GetComponent<AudioSource>();
            Hit.Play();
        }
        inLight += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            gameManager.score += 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Destroy(other.gameObject);
        }
    }

    public float ClampValue(float value, float minvalue, float maxvalue)
    {
        //Returns clamp value
        if (value < minvalue)
        {
            value = minvalue;
        }
        else if (value > maxvalue)
        {
            value = maxvalue;
        }
        return value;
    }
}
