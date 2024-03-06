using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saws : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float speed;
    public SpriteRenderer spriteRenderer;
    private int index = 0;
    bool flip = true;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("Moving"))
        {
            Vector2 newLoc = Vector2.MoveTowards(transform.position, waypoints[index].position, speed);
            transform.position = newLoc;

            if (Mathf.Abs(transform.position.x - waypoints[index].position.x) < .01f && Mathf.Abs(transform.position.y - waypoints[index].position.y) < .01f)
            { 
                index=(index+1)%waypoints.Count;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("wp5"))
        {
            Debug.Log("hit");
            spriteRenderer.flipX = false;
        }
        if (collision.gameObject.tag.Equals("wp6"))
        {
            Debug.Log("hit 2");
            spriteRenderer.flipX = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("wp5"))
        {
            Debug.Log("hit");
            spriteRenderer.flipX = false;
        }
        if (collision.gameObject.tag.Equals("wp6"))
        {
            Debug.Log("hit 2");
            spriteRenderer.flipX = true;
        }
    }
}
