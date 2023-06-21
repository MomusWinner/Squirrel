using UnityEngine;
using UnityEngine.UI;

public class RecordResult : MonoBehaviour
{
    [SerializeField] private Text Record;
    [SerializeField] private Text BestRecord;

    private GameObject player;
    private float result = 0;
    private int bestResult = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        bestResult = PlayerPrefs.GetInt("SavedBestResult");

        bestResult = PlayerPrefs.GetInt("SavedBestResult");
        BestRecord.text = bestResult.ToString();
    }


    void Update()
    {
        if (!player.GetComponent<PlayerContoller>().death) {
            result += Time.deltaTime;
            Record.text = ((int)result).ToString();
        }
        else
        {
            if (bestResult < result)
                RecordBestResult((int)result);
            Destroy(gameObject);
        }
    }

    public void RecordBestResult(int result)
    {
        PlayerPrefs.SetInt("SavedBestResult", result);
    }
}
