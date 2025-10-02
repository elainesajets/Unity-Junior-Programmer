using UnityEngine;

public enum ColorType { Red, Blue, Green }

public class ColorSetter : MonoBehaviour
{
    public ColorType beadColor;
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetColor(ColorType newColor)
    {
        beadColor = newColor;

        switch (newColor)
        {
            case ColorType.Red:
                rend.material.color = Color.red;
                break;
            case ColorType.Blue:
                rend.material.color = Color.blue;
                break;
            case ColorType.Green:
                rend.material.color = Color.green;
                break;
        }
    }
}
