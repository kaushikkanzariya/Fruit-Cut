using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPrefab : MonoBehaviour
{
    public GameObject sliceFruit;
    public GameObject fruitJuice;

    public int score;

    float rotationSpeed = 100f;

    Rigidbody fruitRb;

    private void Awake()
    {
        fruitRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationSpeed);
    }

    private void Instantiate_Fruit()
    {
        GameObject sliceFruitNew = Instantiate(sliceFruit, transform.position, transform.rotation);

        GameObject fruitJuiceNew = Instantiate(fruitJuice, new Vector3(transform.position.x, transform.position.y, 0), fruitJuice.transform.rotation);

        Rigidbody[] rb = sliceFruitNew.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rbSlice in rb)
        {
            rbSlice.AddExplosionForce(100f, transform.position, 10f);
            rbSlice.velocity = fruitRb.velocity * 1.1f;
        }

        Destroy(sliceFruitNew, 5);
        Destroy(fruitJuiceNew, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            GameManager.Instance.UpdateScore(score);
            Destroy(gameObject);
            Instantiate_Fruit();
        }

        if (other.tag == "GameOverTrigger")
        {
            GameManager.Instance.UpdateLives();
        }
    }
}
