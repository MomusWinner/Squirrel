using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] private int direcction;

    [Space]
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject player;

    [SerializeField] private float blinkTime;
    [SerializeField] private float blinkInterval;
    private float lastBlinkTime;
    private bool isBlink = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            transform.position = new Vector2(transform.position.x,player.transform.position.y);
    }

    private void Update()
    {
        Blinking();
    }

    private void Blinking()
    {
        if (lastBlinkTime >= blinkInterval)
        {
            body.SetActive(isBlink);
            isBlink = !isBlink;
            lastBlinkTime = 0;
        }

        if (blinkTime <= 0)
        {
            Instantiate(bird, gameObject.transform.position + direcction*Vector3.left * 2, Quaternion.identity);
            Destroy(gameObject);
        }

        lastBlinkTime += Time.deltaTime;
        blinkTime -= Time.deltaTime;
    }

}
