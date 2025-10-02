using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bead") && gameObject.CompareTag("RedContainer"))
        {
            Renderer beadRenderer = other.GetComponent<Renderer>();
            if (beadRenderer != null && beadRenderer.material.color == Color.red)
            {
                Count += 1;
                CounterText.text = "" + Count;
            }
        }

        if (other.CompareTag("Bead") && gameObject.CompareTag("BlueContainer"))
        {
            Renderer beadRenderer = other.GetComponent<Renderer>();
            if (beadRenderer != null && beadRenderer.material.color == Color.blue)
            {
                Count += 1;
                CounterText.text = "" + Count;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bead"))
        {
            //     Renderer beadRenderer = other.GetComponent<Renderer>();
            //     if (beadRenderer != null && beadRenderer.material.color == Color.red)
            //     {
            //         Count -= 1;
            //         CounterText.text = "" + Count;
            //     }
            // }

            if (other.CompareTag("Bead"))
            {
                Count -= 1;
                CounterText.text = "" + Count;
            }
        }
    }
}
