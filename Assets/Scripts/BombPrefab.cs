using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPrefab : MonoBehaviour
{
    float rotationSpeed = 100f;

    public ParticleSystem bombExplosionParticale;

    private void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            Destroy(gameObject);

            ParticalExplosion();

            GameManager.Instance.GameOver();
        }
    }

    void ParticalExplosion()
    {
        GameObject particale = Instantiate(bombExplosionParticale, transform.position, bombExplosionParticale.transform.rotation).gameObject;

        Destroy(particale, 5f);
    }
}
