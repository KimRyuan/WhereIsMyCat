using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionUIScript : MonoBehaviour
{
    public Text catNameText;
    public Text catDescriptionText;
    public Image catImage;
    public Image[] scrollViewImage;
    public CollectionInfoList collectionInfoListScript;
    public GameObject collection;

    public void CollectionBoard(int index)
    {
        catNameText.text = collectionInfoListScript.collectionInfoList[index].catName;
        catDescriptionText.text = collectionInfoListScript.collectionInfoList[index].catDescription;
        //이미지 설정
        catImage.sprite = SpriteSheetManager.GetSpriteByName("SptriteAtlas", "Chapter1Cat_" + collectionInfoListScript.collectionInfoList[index].catCode.ToString());
    }

    public void CollectionScrollViewSetting()
    {
        for (int i = 0; i < collectionInfoListScript.collectionInfoList.Count; i++)
        {
            scrollViewImage[i].sprite = SpriteSheetManager.GetSpriteByName("SptriteAtlas", "Chapter1Cat_" + collectionInfoListScript.collectionInfoList[i].catCode.ToString());
        }
    }

    public void CatCollected(int catCode)
    {
        collectionInfoListScript.collectionInfoList[catCode].isCollected = true;
        //이미지 변경

    }


    public void BackButton()
    {
        collection.SetActive(false);
    }

    private void Start()
    {
        CollectionScrollViewSetting();
    }
}
