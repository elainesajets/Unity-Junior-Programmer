
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public GameObject gameManager;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        var bead = other.GetComponent<ColorSetter>();
        var container = gameObject.GetComponent<ColorSetter>();

        if (bead != null && bead.beadColor == container.beadColor)
        {
            Count += 1;
            gameManager.GetComponent<GameManager>().UpdateTotal(1);
            CounterText.text = "" + Count;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var bead = other.GetComponent<ColorSetter>();
        var container = gameObject.GetComponent<ColorSetter>();

        if (bead != null && bead.beadColor == container.beadColor)
        {
            Count -= 1;
            gameManager.GetComponent<GameManager>().UpdateTotal(-1);
            CounterText.text = "" + Count;
        }


    }
}
