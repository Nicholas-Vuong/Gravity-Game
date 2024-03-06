using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    bool up = false;
    bool down = true;
    bool right = false;
    bool left = false;
    private bool top;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (up==false)
            {
                rb.gravityScale *= -1;
            }
            Rotation();
            up = true;
        }
    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else 
        {
            transform.eulerAngles = Vector3.zero;
        }
        top = !top;
    }
}
