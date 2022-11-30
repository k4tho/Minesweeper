using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public Cell Cell;
    public Cells Cells;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Debug.Log("Left click");
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Cell.FlagAndUnflag();
        }
    }
}
