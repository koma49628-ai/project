using UnityEngine;

public class startScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject screen;
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CloseScreen()
    {
        screen.SetActive(false);
        Time.timeScale = 1;
    }
}
