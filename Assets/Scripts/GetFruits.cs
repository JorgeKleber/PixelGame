using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GetFruits : MonoBehaviour
{

    [SerializeField] AudioSource audio;
    void Start()
    {

    }

    void Update()
    {

    }

    int count = 0;

    
    void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.layer == 6)
        {
            count++;
            audio.Play();
            item.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            item.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            Destroy(item.gameObject, 0.3f);
        }    
    }
}
