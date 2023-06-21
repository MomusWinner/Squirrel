using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float moveSpeed;

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.fixedDeltaTime);
        if (transform.position.y<-15)
        {
            Destroy(gameObject);
        }
    }
}
