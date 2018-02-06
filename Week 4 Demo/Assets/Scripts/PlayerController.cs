using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Text scoreText;
    public static bool gameOver = true;
    public KeyCode moveUp, moveDown, moveLeft, moveRight;
    public float speedX = 0, speedY = 0;
    public bool linearMovement = true;
    public Camera mainCam;
    public static int score = 0;
    private Rigidbody2D rbody;
    public Animator mainThrusterAnim;
    public Animator LandingAnim;
    public GameObject Moon;
    public Text winText;

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "Moon")
        {
            Debug.Log("MOON");
           // LandingAnim.SetBool("Landing",true);
            SceneManager.LoadScene("Menu");
            Destroy(gameObject);
        }
        if(colInfo.collider.tag == "foe")
        {
            score = score - 7;
            scoreText.text = "Score: " + score;
        }
        if(colInfo.collider.tag == "friend")
        {
            score = score + 5;
            scoreText.text = "Score: " + score;
        }
    }
            // Initialization function
    void Start()
    {
        // store the rigid body in an attribute for easier access.
        rbody = GetComponent<Rigidbody2D>();
        Debug.Log("gameOver value: " + gameOver);
        //gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        // move the player in the 4 directions based on the keys we set up for it
        if (Input.GetKey(moveUp))
        {
            if (linearMovement) // simple constant velocity
                rbody.velocity = new Vector2(0f, speedY);
          //  else // if we were going to use a force instead
                //rbody.AddForce(new Vector2(0, speedY));
            mainThrusterAnim.SetBool("ApplyingThrust", true);             
        }
        else if (Input.GetKey(moveDown))
        {
            if (linearMovement)
                rbody.velocity = new Vector2(0f, -speedY);
            //else
                //rbody.AddForce(new Vector2(0f, -speedY));
        }
        else if (Input.GetKey(moveLeft))
        {
           
            if (linearMovement)
                rbody.velocity = new Vector2(-speedX, 0f);
            //else
                //rbody.AddForce(new Vector2(-speedX, 0f));
        }
        else if (Input.GetKey(moveRight))
        {
            if (linearMovement)
                rbody.velocity = new Vector2(speedX, 0f);
          //  else
              //  rbody.AddForce(new Vector2(speedX, 0f));
        }
        else
        {
            // no input, reset the speed
            rbody.velocity = new Vector2(0f, 0f);
            mainThrusterAnim.SetBool("ApplyingThrust", false);
           
        }
        AdjustPosition();
        if (score >= 25)
        {
            gameOver = true;
            score = 0;
            thatsNoMoon();
        }
    }

    // function to make sure the player doesn't go off the screen
    void AdjustPosition()
    {
        Vector3 screenPos = mainCam.WorldToScreenPoint(transform.position);
        Vector3 topScreen = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        Vector3 leftScreen = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f));
        Vector3 bottomScreen = mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

        // vertical adjustment
        if (screenPos.y > Screen.height)
            transform.position = new Vector3(transform.position.x, topScreen.y, transform.position.z);
        else if (screenPos.y < 0)
            transform.position = new Vector3(transform.position.x, bottomScreen.y, transform.position.z);
        // student: add some code for the horizontal
        if (screenPos.x > Screen.width)
            transform.position = new Vector3(bottomScreen.x, transform.position.y, transform.position.z);
        else if (screenPos.x < 0)
            transform.position = new Vector3(leftScreen.x, transform.position.y, transform.position.z);
        
    }

    private void thatsNoMoon()
    {
        winText.text = "Well done! Land on the moon to complete this level!";
        Vector2 moonSpot = new Vector2(-0.46f, 2.0f);
        Instantiate(Moon, moonSpot, transform.rotation);
    }
}