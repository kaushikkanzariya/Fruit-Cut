using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFruit : MonoBehaviour
{
    public GameObject[] fruitPrefabs;

    public float leftSide;
    public float rightSide;
    void Start()
    {
        StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2.5f));

        while (GameManager.Instance.gameOver == false)
        {
            InstantiateRandomFruit();
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        }
    }

    void InstantiateRandomFruit()
    {
        int fruitIndex = Random.Range(0, fruitPrefabs.Length);

        GameObject fruitSpw = Instantiate(fruitPrefabs[fruitIndex], transform.position, fruitPrefabs[fruitIndex].transform.rotation);

        fruitSpw.GetComponent<Rigidbody>().AddForce(new Vector2(Random.Range(leftSide, rightSide),1) * Random.Range(13f, 16f), ForceMode.Impulse);

        fruitSpw.transform.rotation = Random.rotation;

        Destroy(fruitSpw, 4f);
    }
}
