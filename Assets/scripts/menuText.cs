using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelectableText : MonoBehaviour,
    ISelectHandler,
    IDeselectHandler,
    IPointerClickHandler
{
    [Header("Colours")]
    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;
    public Color pressedColor = Color.red;

    private UnityEngine.UI.Image img;

    private void Awake()
    {
        img = GetComponent<UnityEngine.UI.Image>();
        img.color = normalColor;
    }

    // controller hover
    public void OnSelect(BaseEventData eventData)
    {
        img.color = selectedColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        img.color = normalColor;
    }

    // on click (?)
    public void OnPointerClick(PointerEventData eventData)
    {
        img.color = pressedColor;
    }
}