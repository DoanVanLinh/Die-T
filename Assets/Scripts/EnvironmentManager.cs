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
    public int distanceBetweenGroup;
    public int amountBuildingPerGroup;
    public int amountDetailPerGroup;


    private int lengthBuilding;
    private int lengthDetailObject;
    private int previewBuilding;
    private int previewDetailObject;
    private Vector3 positionSpawn;
    private int currenSpawnGroup;
    private GameObject emptyObj;

    void Awake()
    {
        lengthBuilding = countries[styleCountry].building.Count;
        lengthDetailObject = countries[styleCountry].detailObject.Count;
        emptyObj = new GameObject();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SpawnEnvironment();
    }
    public void SpawnEnvironment()
    {
        RandomSpawnGroup();
    }
    private void RandomSpawnGroup()
    {
        Vector2 verticalRangeSpawn = new Vector2(currenSpawnGroup*distanceBetweenGroup,(currenSpawnGroup+1)*distanceBetweenGroup);
        //Building
        GameObject cloneGroup = new GameObject(); 
        cloneGroup.transform.position = new Vector3(currenSpawnGroup*distanceBetweenGroup,0,0);
        for (int i = 0; i < amountBuildingPerGroup; i++)
        {
           GameObject buildingClone = RandomSpawn(countries[styleCountry].building, rangeSpawnBuilding, verticalRangeSpawn);
           buildingClone.transform.parent = cloneGroup.transform;
           buildingClone.GetComponent<SpriteRenderer>().sortingOrder = i;
        }
        cloneGroup.AddComponent<BoxCollider>();
        cloneGroup.GetComponent<BoxCollider>().isTrigger = true;
        cloneGroup.layer = 9;
        cloneGroup.transform.parent = buildingParent.transform;
        // RandomSpawn(countries[styleCountry].detailObject, rangeSpawnDetailObject, detailObjectParent);
        currenSpawnGroup++;
    }
    private GameObject RandomSpawn(List<GameObject> listObject, Vector2 horizontalRangeSpawn, Vector2 verticalRangeSpawn)
    {
        int index = 0;

        do
        {
            int random = Random.Range(0, lengthBuilding);
            if (random != index)
            {
                index = random;
                break;
            }
        } while (true);

        int randomZ = 0;
        do
        {
            int random = Random.Range((int)horizontalRangeSpawn.x, (int)horizontalRangeSpawn.y);
            if (random != randomZ)
            {
                randomZ = random;
                break;
            }
        } while (true);

        int randomX = 0;
        do
        {
            int random = Random.Range((int)verticalRangeSpawn.x, (int)verticalRangeSpawn.y);
            if (random != randomX)
            {
                randomX = random;
                break;
            }
        } while (true);

        positionSpawn = new Vector3(randomX, 0, randomZ);
        GameObject clone = Instantiate(listObject[index],positionSpawn , Quaternion.identity);
        
        return clone;
    }
}
