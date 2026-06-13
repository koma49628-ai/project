using UnityEngine;

public class carschose67 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform chosechos;
    private GameObject[] Cars;
    private int carNumber = 0;
    public GameObject menu;
    public GameObject carMenu;

    void Start()
    {
        int childCount = chosechos.childCount;
        Cars = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            Cars[i] = chosechos.GetChild(i).gameObject;
        }
    }
    public void next()
    // Update is called once per frame
    {
        Cars[carNumber].SetActive(false);
        carNumber = (carNumber + 1) % Cars.Length;
        Cars[carNumber].SetActive(true);
    }
}
