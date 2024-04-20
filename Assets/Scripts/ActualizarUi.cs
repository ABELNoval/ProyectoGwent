using TMPro;
using UnityEngine;

public class ActualizarUi : MonoBehaviour
{
    public TextMeshProUGUI points;

    public ActualizarUi(int points)
    {
        this.points.text = points.ToString();
    }
}
