using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FixedJoystick : Joystick
{
    Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();

    public GameObject holder;
    public GameObject circle;

   // public GameObject gameController;

    void Start()
    {
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);

    }
   

    public override void OnDrag(PointerEventData eventData)
    {
        circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, .4f);
        holder.GetComponent<Image>().color = new Color(1f, 1f, 1f, .4f);



        //  joy.gameObject.GetComponentInChildren<Color>()= new Color(1f, 1f, 1f, .5f);


        // image.color = new Color(1f, 1f, 1f, .5f);




        Vector2 direction = eventData.position - joystickPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        ClampJoystick();
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;


       // Debug.Log(handle.anchoredPosition.x);

    }

    public override void OnPointerDown(PointerEventData eventData)
    {

        OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;


        circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        holder.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

    }
}