using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<AnimalHunger2>().FeedAnimal(1);
        }
    }
}
