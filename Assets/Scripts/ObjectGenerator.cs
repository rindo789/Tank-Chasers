using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> BonusPrefab;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnObject());
        } while (looping);
    }

    private IEnumerator SpawnObject()
    {
        for (; ; )
        {
            string nameOfpoint = "Point (" + Random.Range(1, GameObject.Find("PointsOfBonus").transform.childCount).ToString() + ")";
            var newObject = Instantiate(BonusPrefab[Random.Range(0, 2)], GameObject.Find(nameOfpoint).transform.position, Quaternion.identity);

            yield return new WaitForSeconds(15f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
