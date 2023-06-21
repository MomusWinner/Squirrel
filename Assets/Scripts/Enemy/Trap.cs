using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private string layer;
    [SerializeField] private Vector2 direction;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layer))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }
}
