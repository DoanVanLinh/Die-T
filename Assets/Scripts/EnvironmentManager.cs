using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public int styleCountry;
    public GameObject buildingParent;
    public GameObject detailObjectParent;
    public List<Country> countries;
    public Vector2 rangeSpawnBuilding;
    public Vector2 rangeSpawnDetailObject;
    public Transform player;

    private int lengthBuilding;
    private int lengthDetailObject;
    private int previewBuilding;
    private int previewDetailObject;
    private  int index = 0;
    private int positionSpawn = 0;

    void Awake()
    {

        lengthBuilding = countries[styleCountry].building.Count;
        lengthDetailObject = countries[styleCountry].detailObject.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
            SpawnEnvironment();
    }
    void SpawnEnvironment()
    {
        
        RandomSpawn(countries[styleCountry].building,rangeSpawnBuilding,buildingParent);
        RandomSpawn(countries[styleCountry].detailObject,rangeSpawnDetailObject,detailObjectParent);
    }
    private void RandomSpawn(List<GameObject> listObject,Vector2 rangeSpawn, GameObject parent)
    {
        do
        {
            int random = Random.Range(0, lengthBuilding);
            if (random != index)
            {
                index = random;
                break;
            }
        } while (true);

        
        do
        {
            int random = Random.Range((int)rangeSpawn.x,(int)rangeSpawn.y);
            if (random != positionSpawn)
            {
                positionSpawn = random;
                break;
            }
        } while (true);

        GameObject clone = Instantiate(listObject[index], new Vector3(player.position.x, 0,positionSpawn), Quaternion.identity);
        clone.transform.parent = parent.transform;
        clone.transform.localScale *= Random.Range(7,15) * 0.1f;
    }
}
