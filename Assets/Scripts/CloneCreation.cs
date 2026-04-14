using UnityEngine;

public class CloneCreation : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    public float destroyTime = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

            Destroy(obj, destroyTime);
        }
    }
}
