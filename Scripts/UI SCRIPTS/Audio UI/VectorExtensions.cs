using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class VectorExtensions
{
public static bool IsPointOverUIObject(this Vector2 pos)


    {


        if (EventSystem.current.IsPointerOverGameObject())
            {

            return false;

        }

        PointerEventData eventPos = new PointerEventData(EventSystem.current);

        eventPos.position = new Vector2(pos.x, pos.y);

        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventPos, results);

        return results.Count > 0;
    }


}
