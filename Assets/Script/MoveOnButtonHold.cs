using UnityEngine;
using UnityEngine.EventSystems;

public class MoveOnButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameManager manager;
    
    private bool isButtonHeld = false; // 이동 속도

    public enum ButtonAction { LeftButton, RightButton }
    public ButtonAction buttonAction;
    
    void Update()
    {
        if (isButtonHeld)
        {
            switch (buttonAction)
            {
                case ButtonAction.LeftButton:
                    manager.LeftCar();
                    break;
                case ButtonAction.RightButton:
                    manager.RightCar();
                    break;
            }
        }
    }

    // 버튼을 누르면 실행
    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonHeld = true;
    }

    // 버튼을 떼면 실행
    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonHeld = false;
    }
}