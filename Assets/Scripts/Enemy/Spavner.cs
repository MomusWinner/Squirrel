using UnityEngine;

public class Spavner : MonoBehaviour
{
    public GameObject[] enemies;
    public float timeInterval;
    public float complication;
    public float minIntreval;

    private float time;

    public void Update()
    {
        time += Time.deltaTime;

        if (time >= timeInterval) 
        {
            Instantiate(RandomChooseObject(enemies), transform.position, Quaternion.identity);
            time= 0;

            if (minIntreval < timeInterval)
                timeInterval -= complication;

        }
       
    }

    private GameObject RandomChooseObject(GameObject[] objects)
    {
        return objects[Random.RandomRange(0, objects.Length - 1)];
    } 
}
