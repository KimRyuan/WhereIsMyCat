﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSceneScript : MonoBehaviour
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
        catImage.sprite = SpriteSheetManager.GetSpriteByName("SpriteAtlas", "Cat_" + collectionInfoListScript.collectionInfoList[index].catCode.ToString());
    }

    public void CollectionScrollViewSetting()
    {
        //개수 확인해서 넘어가면 안보이게.
        Debug.Log("count : " + collectionInfoListScript.collectionInfoList.Count);
        for (int i = 0; i < collectionInfoListScript.collectionInfoList.Count; i++)
        {
            scrollViewImage[i].sprite = SpriteSheetManager.GetSpriteByName("SpriteAtlas", "Cat_" + collectionInfoListScript.collectionInfoList[i].catCode.ToString());
            if (collectionInfoListScript.collectionInfoList[i].isCollected.Equals(false))
            {
                scrollViewImage[i].color = Color.black;
            }
        }
    }

    public void CatCollected(int catCode)
    {
        collection.SetActive(true);
        collectionInfoListScript.collectionInfoList[catCode].isCollected = true;
        //이미지 변경
        scrollViewImage[catCode].color = Color.white;

    }


    public void BackButton()
    {
        collection.SetActive(false);
    }

    private void Start()
    {
        SpriteSheetManager.Load("SpriteAtlas");
        CollectionScrollViewSetting();
    }

}


