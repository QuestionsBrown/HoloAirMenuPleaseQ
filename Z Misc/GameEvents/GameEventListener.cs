using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{



    [SerializeField] protected GameEvent _gameEvent;
    [SerializeField] protected UnityEvent _unityEvent;



    // Start is called before the first frame update
     void Awake()
    {
        _gameEvent.Register(gameEventListener: this);
      

    }

    private void OnDestroy()
    {
        _gameEvent.Deregister(gameEventListener: this);
    }

    public virtual void RaiseEvent()
    {
        _unityEvent.Invoke();
    }
}
