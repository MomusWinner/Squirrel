using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    [Header("Death controll")]
    [SerializeField] private float deathPointY = -6.5f;
    [SerializeField] private GameObject deathPanel;
    public bool death { get; private set; }

    [Header("GUI")]
    [SerializeField] private Text counsText;

    private int couns;

    private void Start()
    {
        couns = PlayerPrefs.GetInt("Nuts");
    }

    void Update()
    {
        counsText.text = couns.ToString();
        Death();
    }

    public void Death()
    {
        if (transform.position.y < deathPointY)
        {
            death = true;
            deathPanel.SetActive(true);
            gameObject.SetActive(false);
        }
        else
            death = false;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nut"))
        {
            Debug.Log("dsfsdf");
            couns++;
            PlayerPrefs.SetInt("Nuts", couns);
            Destroy(collision.gameObject);
        }
    }
}
