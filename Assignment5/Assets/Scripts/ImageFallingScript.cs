using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFallingScript : MonoBehaviour
{
    RectTransform rect;


    int offset;
    // Start is called before the first frame update
    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
        offset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Rect actualRect = rect.rect;
        actualRect.y -= 1;
        offset += 1;
        if (offset >= 1200)
        {
            offset = 0;
        }
        rect.position = new Vector3(0, offset, 0);

    }
}
