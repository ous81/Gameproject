using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

  private AudioSource collectionSoundEffect;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Pineapple"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
    }

    if (collision.gameObject.CompareTag("Orange"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
    }

  }
}
