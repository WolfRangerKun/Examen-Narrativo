using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLisent : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 direction = mouseOnScreen - positionOnScreen;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
       transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));


    }
}
