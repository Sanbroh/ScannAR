using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class togglePlacement : MonoBehaviour
{
    public GameObject Source;
    public AR_Cursor_Script cursorScript;
    public Sprite plusSprite;
    public Sprite moveSprite;

    private bool placement;

    void Start()
    {
        Source.GetComponent<Image>().overrideSprite = plusSprite;
        placement = true;
    }

    public void toggleMode()
    {
        if (!placement)
        {
            Source.GetComponent<Image>().overrideSprite = plusSprite;
            placement = true;
        }
        else
        {
            Source.GetComponent<Image>().overrideSprite = moveSprite;
            placement = false;
            cursorScript.deleteOld();
        }
        cursorScript.togglePlacing();
    }

    public void forceToggleTrue()
    {
        Source.GetComponent<Image>().overrideSprite = plusSprite;
        placement = true;
    }
}
