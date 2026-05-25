using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpriteTextButton : MonoBehaviour,
IPointerClickHandler,
IPointerEnterHandler,
IPointerExitHandler
{
    public Image image;

    public Color normalColor = Color.white;
    public Color hoverColor = Color.grey;
    public Color clickColor = Color.green;

    private void Start()
    {
        if (image == null)
            image = GetComponent<Image>();

        image.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = clickColor;
    }
}