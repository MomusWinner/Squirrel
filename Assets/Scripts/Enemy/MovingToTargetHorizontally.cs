using UnityEngine;

public class MovingToTargetHorizontally : MonoBehaviour
{
    private int rotation;
    public float moveSpeed;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) {
            rotation = GameObject.FindGameObjectWithTag("Player").transform.position.x > transform.position.x ? 0 : 180;
            gameObject.transform.rotation = Quaternion.Euler(new Vector2(0, rotation));
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.fixedDeltaTime);
    }
}
