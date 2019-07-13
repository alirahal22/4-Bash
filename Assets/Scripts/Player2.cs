using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player2 : MonoBehaviour
{
    Rigidbody rb;
    Vector3 beforeCollisionVelocity;

    float c = 1.68012451f;
    float z = 0;
    float x = 1.68012451f;

    float oldYAngle = 90;
    float newYAngle = 90;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Level2.AddTag("1");
        tag = "1";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            z = c;
            x = 0;
            newYAngle = 0;

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            z = -c;
            x = 0;
            newYAngle = 180;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            x = -c;
            z = 0;
            newYAngle = -90;

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            x = c;
            z = 0;
            newYAngle = 90;
        }
        transform.eulerAngles = new Vector3(0, oldYAngle, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Box"))
        {
            beforeCollisionVelocity = rb.velocity;
        }
        else
        {
            rb.transform.position = new Vector3(collision.collider.transform.position.x, 0.65f, collision.collider.transform.position.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("Box"))
        {
            rb.velocity = beforeCollisionVelocity;
        }
        else
        {
            oldYAngle = newYAngle;
            rb.velocity = new Vector3(x, c, z);
        }
    }




}