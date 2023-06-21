using UnityEngine;

public class TreeSpavner : MonoBehaviour
{
    [SerializeField] private GameObject[] treePlatforms;

    private GameObject currentTreePlatform;


    void Start()
    {
        currentTreePlatform = Instantiate(RandomChooseObject(treePlatforms));
    }


    void Update()
    {
        if (currentTreePlatform.transform.position.y <= 0 )
            currentTreePlatform = Instantiate(RandomChooseObject(treePlatforms));
    }


    private GameObject RandomChooseObject(GameObject[] objects)
    {
        return objects[Random.RandomRange(0, objects.Length - 1)];
    }

}
