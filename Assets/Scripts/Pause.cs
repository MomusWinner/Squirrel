using UnityEngine;

public class Pause : MonoBehaviour
{
    private float timer;
    private bool ispause = false;
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        Time.timeScale = timer;
        if (ispause == true) { 
            timer = 0;
        }
        else if (ispause == false)
        {
            timer = 1;
        }
    }
    
    public void onPause()
    {
        pauseMenu.SetActive(true);
        ispause = true;
    }

    public void offPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        ispause = false;

    }

    public void offPanel(GameObject panel) => panel.SetActive(false);

    public void onPanel(GameObject panel) => panel.SetActive(true);
}
