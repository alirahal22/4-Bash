using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player3 : MonoBehaviour
{
    Rigidbody rb;
    Vector3 beforeCollisionVelocity;

    float c = 1.68012451f;
    float x = 0;
    float z = -1.68012451f;

    float oldYAngle = 180;
    float newYAngle = 180;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Level2.AddTag("2");
        tag = "2";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            z = c;
            x = 0;
            newYAngle = 0;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            z = -c;
            x = 0;
            newYAngle = 180;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            x = -c;
            z = 0;
            newYAngle = -90;
        }
        if (Input.GetKeyDown(KeyCode.K))
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