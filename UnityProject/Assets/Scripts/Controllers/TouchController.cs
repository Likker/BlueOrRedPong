using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPosition
{
    TOP,
    BOTTOM
}

public class TouchController : MonoBehaviour
{
    public Transform playerTransform;
    Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        var tapCount = Input.touchCount;
        for (var i = 0; i < tapCount; i++)
        {
            var touch = Input.GetTouch(i);
            Vector2 pos = new Vector2(touch.position.x, touch.position.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(GlobalInfo.instance.mainCamera.ScreenToWorldPoint(pos), Vector2.zero);
            if (hitInfo)
            {
                if (hitInfo.collider.Equals(col))
                {
                    float sizeOfBar = Screen.width * 0.3f / 2.5f;
                    if (pos.x > Screen.width - sizeOfBar)
                        playerTransform.localPosition = new Vector3(GlobalInfo.instance.mainCamera.ScreenToWorldPoint(new Vector3(sizeOfBar, 0, 0)).x * -1, playerTransform.localPosition.y, 0);
                    else if (pos.x < sizeOfBar)
                        playerTransform.localPosition = new Vector3(GlobalInfo.instance.mainCamera.ScreenToWorldPoint(new Vector3(sizeOfBar, 0, 0)).x, playerTransform.localPosition.y, 0);
                    else
                        playerTransform.localPosition = new Vector3(GlobalInfo.instance.mainCamera.ScreenToWorldPoint(pos).x, playerTransform.localPosition.y, 0);
                }

            }
        }
    }

}

