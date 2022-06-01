using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    [SerializeField] float destroyableTime = 0.1f;
    [SerializeField] Color32 hasPackageColorGreen = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasPackageColorRed = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    internal bool AddPackage(Color32 color)
    {
        if (hasPackage) return false;

        hasPackage = true;
        spriteRenderer.color = color;
        return true;
    }

    SpriteRenderer spriteRenderer;

        void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasPackage)
        {
            if (other.tag == "Package")
            {
                hasPackage = true;
                spriteRenderer.color = hasPackageColorGreen;
                Destroy(other.gameObject, destroyableTime);

            }
            if (other.tag == "RedPackage")
            {
                hasPackage = true;
                spriteRenderer.color = hasPackageColorRed;
                Destroy(other.gameObject, destroyableTime);
            }
        }
        else
        {
            if (other.tag == "DeliverPoint")
            {
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
        }
    }
}
