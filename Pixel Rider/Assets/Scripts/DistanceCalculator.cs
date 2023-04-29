using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCalculator : MonoBehaviour
{
    int distance;
    [SerializeField]
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        distance = 0;
        StartCoroutine(DistanceCounter());
    }

    // Update is called once per frame
    IEnumerator DistanceCounter()
    {
        while (true)
        {
            distance += 1;
            yield return new WaitForSeconds(0.1f);
            score.text = "Distance: " + distance;

        }

    }

}
