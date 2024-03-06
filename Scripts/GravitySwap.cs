using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GravitySwap : MonoBehaviour
{
    private bool up=false;
    private bool down=false;
    private bool right=false;
    private bool left = false;
    private bool up2 = false;
    private bool down2 = true;
    private bool right2 = false;
    private bool left2 = false;
    [SerializeField] Rigidbody2D rb;
    Vector3 OgPos;
    private static GravitySwap instance;
    int scene;
    public int deaths;
    [SerializeField] Text scoreText;
    int Scene = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(Scene==5)
        Physics2D.gravity = new Vector2(0f, -9.81f);
        rb.rotation = 0;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        OgPos = transform.position;
        /*if (gameObject.scene.name.Equals("Level1"))
        {
            OgPos = new Vector2(-10.84f, -3.76f);
        }
        else if (gameObject.scene.name.Equals("Level2"))
        {
            OgPos = new Vector2(10.39f, -3.939872f);
        }*/
    }
    public static void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if (Scene == 5)
        {
            scoreText.text = "Deaths: " + deaths;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = new Vector2(-9.81f, 0f);
            rb.rotation = 270;
            if (left2 == false)
            {
                transform.position = new Vector2(transform.position.x - .5f, transform.position.y);
                left2 = true;
                up2 = false;
                down2 = false;
                right2 = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
            if (down2==false)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - .5f);
                down2 = true;
                up2 = false;
                right2 = false;
                left2 = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = new Vector2(0f, 9.81f);
            rb.rotation = 180;
            if (up2 == false)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + .5f);
                up2 = true;
                down2 = false;
                right2 = false;
                left2 = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = new Vector2(9.81f, 0f);
            rb.rotation = 90;
            if (right2 == false)
            {
                transform.position = new Vector2(transform.position.x + .5f, transform.position.y);
                right2 = true;
                up2 = false;
                down2 = false;
                left2 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            deaths = 0;
            Scene = 0;
            LoadScene(Scene);
            scoreText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Scene = 1;
            LoadScene(Scene);
            scoreText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Scene = 2;
            LoadScene(Scene);
            scoreText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Scene = 3;
            LoadScene(Scene);
            scoreText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Scene = 4;
            LoadScene(Scene);
            scoreText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Scene = 5;
            LoadScene(Scene);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Transport"))
        {
            Scene++;
            LoadScene(Scene);
        }
        if (collision.gameObject.tag.Equals("Moving")||collision.gameObject.tag.Equals("death"))
        {
            deaths++;
            transform.position = OgPos;
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
            down2 = true;
            up2 = false;
            right2 = false;
            left2 = false;
        }
        if (collision.gameObject.tag.Equals("Portal1"))
        {
            transform.position = new Vector2(9.95f, 3.92f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal2"))
        {
            transform.position = new Vector2(-4.37f, 3.15f);
        }
        if (collision.gameObject.tag.Equals("Portal3"))
        {
            transform.position = new Vector2(1.37f, -3.63f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal4"))
        {
            transform.position = new Vector2(-7.5f, -2.33f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal5"))
        {
            transform.position = new Vector2(-6.62f, 1.5f);
        }
        if (collision.gameObject.tag.Equals("Portal6"))
        {
            transform.position = new Vector2(-0.48f, 2.73f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 7"))
        {
            transform.position = new Vector2(-9.79f, 2.99f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 8"))
        {
            transform.position = new Vector2(-9.05f, .1f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 9"))
        {
            transform.position = new Vector2(2.37f, 3.8f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 10"))
        {
            transform.position = new Vector2(-2.37f, -2.54f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 11"))
        {
            transform.position = new Vector2(9.29f, -3.15f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 12"))
        {
            transform.position = new Vector2(-3.37f, -.66f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 13"))
        {
            transform.position = new Vector2(-2.34f, 1.95f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 14"))
        {
            transform.position = new Vector2(8.28f, 3.78f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 15"))
        {
            transform.position = new Vector2(-8.88f, -2.27f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 16"))
        {
            transform.position = new Vector2(-4.04f, 3.6f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 17"))
        {
            transform.position = new Vector2(-.86f, -3.95f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 18"))
        {
            transform.position = new Vector2(-5.74f, -3.72f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 19"))
        {
            transform.position = new Vector2(-10.16f, 2.39f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 20"))
        {
            transform.position = new Vector2(-10.11f, .05f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 21"))
        {
            transform.position = new Vector2(5.92f, -3.54f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
        if (collision.gameObject.tag.Equals("Portal 22"))
        {
            transform.position = new Vector2(2.93f, -1.02f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            rb.rotation = 0;
        }
    }

    void Rotation()
    {
        if (up == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        //up = !up;
    }

    void Rotation2()
    {
        if (right == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 90f);
        }
        //right = !right; 
    }

    void Rotation3()
    {
        if (left == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 270f);
        }
        //left = !left;
    }

    void Rotation4()
    {
        if (down == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0f);
        }
        //down = !down;
    }
}
