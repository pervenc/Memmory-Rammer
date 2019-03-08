using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float requiredHoldTime;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;

    public Button button;

   // public GameObject gameController;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        //  Debug.Log("OnPointerDown");

        button.GetComponent<Image>().color = new Color(1f, 1f, 1f, .4f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

        Reset();
        // Debug.Log("OnPointerUp");
    }

    private void Update()
    {
     


        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                Reset();
            }
            //  fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        // fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }


}