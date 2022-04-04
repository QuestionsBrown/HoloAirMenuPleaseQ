using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerWithDelay : GameEventListener
{

    [SerializeField] float _delay = 3f;
    [SerializeField] UnityEvent _delayedUnityevent;



    public virtual void RaiseEvent()
    {
        _unityEvent.Invoke();
        StartCoroutine(routine: RunDelayedEvent());
    }


    private IEnumerator RunDelayedEvent()
    {

        yield return new WaitForSeconds(_delay);
        _delayedUnityevent.Invoke();
    }
  
}
