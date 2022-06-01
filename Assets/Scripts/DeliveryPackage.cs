using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPackage : MonoBehaviour
{
    [SerializeField] Color32 color;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var delivery = collision.gameObject.GetComponent<Delivery>();
        if (delivery != null)
        {
            if (delivery.AddPackage(color))
            {
                Destroy(gameObject);
            }
        }
    }
}
