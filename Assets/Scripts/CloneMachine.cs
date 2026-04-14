using UnityEngine;

public class CloneMachine : MonoBehaviour
{

    public GameObject myPrefab; //referencia a clonar 
    public Vector3 spawnPosition; //referencia de la posicion donde se clona
    private GameObject clone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clone = Instantiate(myPrefab, spawnPosition, Quaternion.identity); //crea un clon de mi objeto
    }

    // Update is called once per frame
    void Update()
    {

        //Use SpaceBar to create clones 2 by 2
        // 6 clones in total
        // Create the 6 clones with one instace

        //Clicking an X button destroy the clones
        
        //Use T Key to deactivate the clones - component inside a gameobject
        
        //Use D Key to destroy the scripts inside the clones - prefabs
        // The script must include the life of the clone with a value of 100

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(clone);
            Destroy(this);//destroys the script
        }
    }
}
