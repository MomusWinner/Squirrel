using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Update()
    {
        Death(10f,10f);
    }

    private void Death(float lifeDistantionX, float lifeDistantionY)
    {
        Vector3 pos = transform.position;
        if ((pos.x > lifeDistantionX || pos.x < -lifeDistantionX)
            || (pos.y > lifeDistantionY || pos.y < -lifeDistantionY))
            Destroy(gameObject);
    }
}
