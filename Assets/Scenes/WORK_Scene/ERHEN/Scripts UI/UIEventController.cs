using UnityEngine;
using UnityEngine.Events;

public class UIEventController : MonoBehaviour
{
    [SerializeField] private UnityEvent uiAnimEventOne;
    [SerializeField] private UnityEvent uiAnimEventTwo;
    [SerializeField] private UnityEvent uiAnimEventThree;
    public int uiActionToPlay;

public void SetAction(int newAction)
{uiActionToPlay = newAction;}

    public void SendEvent() {
	switch (uiActionToPlay)
{
case 0 : uiAnimEventOne.Invoke(); break;
case 1 : uiAnimEventTwo.Invoke(); break;
case 2 : uiAnimEventThree.Invoke(); break;

}  
    }
}
