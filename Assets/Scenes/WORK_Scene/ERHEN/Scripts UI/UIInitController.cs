using UnityEngine;
using UnityEngine.Events;

public class UIInitController : MonoBehaviour
{
    [SerializeField] private UnityEvent uiEvent;

    private void Awake() {
uiEvent.Invoke();
}
}
