using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutobusGG : MonoBehaviour
{
    public int speed;
    public int speedRotation;
    private float gorisont;
    private float vertical;
    private int coinNumber;
    public TextMeshProUGUI coinTextt;
    
   
    
    public GameObject youAreLooser;
    private bool GameStart;
    
    
    void Start()
    {
        
        coinNumber = 0;
        coinTextt.text = "coins: " + coinNumber;
        GameStart = false;
    }

    void Update()
    {
        if (GameStart == true)
        {

            gorisont = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.Translate(Vector3.right * Time.deltaTime * speedRotation * gorisont);
            
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("damage car 52"))
        {
            speed = speed - 1;
            if (speed < 0)
            {
                youAreLooser.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("monetacoincoins"))
        {
            coinNumber = coinNumber + 6;
            coinTextt.text = "coins: " + coinNumber;
            Destroy(other.gameObject);
        }
    }
    public void GameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameStart()
    {
        GameStart = true;
    }
}
