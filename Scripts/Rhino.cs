using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool up;
    [SerializeField] bool right;
    [SerializeField] bool left;
    [SerializeField] bool down;
    public SpriteRenderer spriteRenderer;
    float xChange = 0f;
    float yChange = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            yChange += speed;
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (down)
        {
            yChange -= speed;
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }

        if (right)
        {
            xChange += speed;
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (left)
        {
            xChange -= speed;
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }


    }

    public void FixedUpdate()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Barrier"))
        {
            Debug.Log("HIT");
            if (up)
            {
                up = false;
                down = true;
            }
            else if (down)
            {
                down = false;
                up = true;
            }
            if (right)
            {
                Debug.Log("right");
                right = false;
                left = true;
                spriteRenderer.flipX = false;
            }
            else if (left)
            {
                left = false;
                right = true;
                spriteRenderer.flipX = true;
            }
        }
    }
}
