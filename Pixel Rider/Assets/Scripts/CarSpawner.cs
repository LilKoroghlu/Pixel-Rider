using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] carReference;
    GameObject spawnedCar;
    [SerializeField]
    Transform top, bottom, middleTop, middleBottom;
    int randomIndex;
    int randomPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, carReference.Length);
            randomPos = Random.Range(0, 4);
            spawnedCar = Instantiate(carReference[randomIndex]);
            if (randomPos == 0)
                spawnedCar.transform.position = top.position;
            else if (randomPos == 1)
                spawnedCar.transform.position = bottom.position;
            else if (randomPos == 2)
                spawnedCar.transform.position = middleTop.position;
            else
                spawnedCar.transform.position = middleBottom.position;
        }
    }
}
