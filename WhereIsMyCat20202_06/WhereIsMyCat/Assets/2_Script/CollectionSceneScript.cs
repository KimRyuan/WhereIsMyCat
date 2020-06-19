using System.Collections;
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

    private void Awake()
    {
        SpriteSheetManager.Load("UIAtlas");
    }


    public void CollectionBoard(int index)
    {
        if (collectionInfoListScript.collectionInfoList[index].isCollected)
        {
            catNameText.text = collectionInfoListScript.collectionInfoList[index].catName;
            catDescriptionText.text = collectionInfoListScript.collectionInfoList[index].catDescription;
            //이미지 설정
            catImage.sprite = SpriteSheetManager.GetSpriteByName("UIAtlas", "Cat" + collectionInfoListScript.collectionInfoList[index].catCode.ToString());
            collection.SetActive(true);
        }
    }

    public void CollectionScrollViewSetting()
    {
        //개수 확인해서 넘어가면 안보이게.
        Debug.Log("count : " + collectionInfoListScript.collectionInfoList.Count);
        for (int i = 0; i < collectionInfoListScript.collectionInfoList.Count; i++)
        {
            scrollViewImage[i].sprite = SpriteSheetManager.GetSpriteByName("UIAtlas", "Cat" + collectionInfoListScript.collectionInfoList[i].catCode.ToString());
            scrollViewImage[i].transform.parent.gameObject.SetActive(true);

            if (collectionInfoListScript.collectionInfoList[i].isCollected)
            {
                scrollViewImage[i].color = Color.white;
            }
            else
            {
                scrollViewImage[i].color = Color.black;
            }

            for (int j = collectionInfoListScript.collectionInfoList.Count; j < scrollViewImage.Length; j++)
            {
                scrollViewImage[j].transform.parent.gameObject.SetActive(false);
            }
        }
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


