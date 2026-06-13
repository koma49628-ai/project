using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HUGGYWUGGY : MonoBehaviour
{
    public int speed;
    public int speedRotation;
    private float gorisont;
    private float vertical;
    private int coinNumber;
    public TextMeshProUGUI coinTextt;
    private int originalSpeed;
    public int stopCooldown;
    private float lastUsedTime = -10f;
    public GameObject youAreLooser;
    private bool GameStart;
    public Transform Tanks_tochka;
    public GameObject Tanks_Ammo;
    public float AmmoPower;
    void Start()
    {
        originalSpeed = speed;
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
            bool canPressButtons = Time.time >= lastUsedTime;
            if (canPressButtons)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    speed = 0;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    speed = originalSpeed;
                    lastUsedTime = Time.time + stopCooldown;
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject ammoCopy = Instantiate(Tanks_Ammo, Tanks_tochka.position, Tanks_tochka.rotation);
                Rigidbody ammo_Rb = ammoCopy.GetComponent<Rigidbody>();
                ammo_Rb.AddForce(Tanks_tochka.forward * AmmoPower, ForceMode.Impulse);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("damage car 52"))
            {
            speed = speed - 1;
            if (speed<0)
            {
                youAreLooser.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.CompareTag("monetacoincoins"))
        {
            coinNumber = coinNumber + 2;
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
