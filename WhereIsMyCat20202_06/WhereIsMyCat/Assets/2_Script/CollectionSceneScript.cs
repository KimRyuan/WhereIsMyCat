using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSceneScript : MonoBehaviour
{
    public GameObject Description;

    public Text catNameText;
    public Image catnameImage;
    public Text catDescripton;

    public void DescriptionClick()
    {

        DescriptionSetting();
        Description.SetActive(true);
    }

    public void DescriptionSetting()
    {

    }

    public void DescriptImageUnlock()
    {

    }

}


