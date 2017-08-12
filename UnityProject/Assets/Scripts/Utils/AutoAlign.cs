using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAlign : MonoBehaviour
{
    public Vector2 referencePos = new Vector2(1, 1);
    public Vector2 referenceScale = new Vector2(1, 1);

    private void Start()
    {
        UpdateAlignment();
    }

    private void OnEnable()
    {
        Events.Instance.AddListener<OnInitializeGameEvent>(OnInitializeGame);
    }

    private void OnDisable()
    {
        Events.Instance.RemoveListener<OnInitializeGameEvent>(OnInitializeGame);
    }

    public void OnInitializeGame(OnInitializeGameEvent e)
    {
        UpdateAlignment();
    }

    public void UpdateAlignment()
    {
        float width = GlobalInfo.instance.mainCamera.orthographicSize * 2 * Screen.width / Screen.height;

        transform.localScale = new Vector3(width * referenceScale.x, width * referenceScale.y, 0);
        Vector3 pos = new Vector3(Screen.width * referencePos.x, Screen.height * referencePos.y, GlobalInfo.instance.mainCamera.transform.position.z * -1);
        transform.localPosition = GlobalInfo.instance.mainCamera.ScreenToWorldPoint(pos);
    }

}
