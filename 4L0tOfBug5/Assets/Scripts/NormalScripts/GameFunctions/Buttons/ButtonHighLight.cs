using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHighLight : MonoBehaviour, ISelectHandler, IPointerEnterHandler , IPointerExitHandler
{
    [SerializeField] UnityEvent OnOver;
    [SerializeField] UnityEvent OnExit;
    [SerializeField] UnityEvent OnClick;
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnOver.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit.Invoke();
    }

    // When selected.
    public void OnSelect(BaseEventData eventData)
    {
        OnClick.Invoke();
    }

    
}