using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image BackgroundImage;
    private Image JoystickImage;
    public Vector2 InputDir;
    public float offset;

    private void Start()
    {
        BackgroundImage = GetComponent<Image>();
        JoystickImage = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        float bgImageSizeX = BackgroundImage.rectTransform.sizeDelta.x;
        float bgImageSizeY = BackgroundImage.rectTransform.sizeDelta.y;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(BackgroundImage.rectTransform,eventData.position,eventData.pressEventCamera, out pos))
        {
            pos.x /= bgImageSizeX;
            pos.y /= bgImageSizeY;
            InputDir = new Vector2(pos.x, pos.y);
            if(InputDir.magnitude > 1)
            {
                InputDir = InputDir.normalized;
            }
            JoystickImage.rectTransform.anchoredPosition = new Vector2(InputDir.x * (bgImageSizeX/offset), InputDir.y * (bgImageSizeY/offset));
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDir = Vector2.zero;
        JoystickImage.rectTransform.anchoredPosition = Vector2.zero;
    }
}
