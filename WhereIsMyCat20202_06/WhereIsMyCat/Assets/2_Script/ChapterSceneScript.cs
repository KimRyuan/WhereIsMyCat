using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSceneScript : MonoBehaviour
{

    public GameObject scrollbar;
    public List<GameObject> ChapterImage;
    float scroll_pos = 0;
    float[] pos;
    [SerializeField] int posisi = 0;



    public GameObject[] ChapterStageBtn;

    public void ChapterNextButton()
    {
        if (posisi < pos.Length - 1)
        {
            posisi += 1;
            scroll_pos = pos[posisi];
        }
        // ChapterImageCopy();
    }

    public void ChapterPrevButton()
    {
        if (posisi > 0)
        {
            posisi -= 1;
            scroll_pos = pos[posisi];

        }
        // ChapterImageCopy();
    }
    private void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)

        {
            pos[i] = distance * i;

        }
        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }

        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {

                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.15f);

                    posisi = i;
                    //ChapterImageCopy();
                }
            }
        }
    }

    //public void ChapterImageCopy()
    //{
    //    if (posisi == pos.Length-1)
    //    {
    //        GameObject FirstImage = Instantiate(ChapterImage[0], this.gameObject.transform);
    //        ChapterImage.Add(FirstImage);
    //        ChapterImage.RemoveAt(0);
    //        DestroyImmediate(ChapterImage[0]);
    //        FirstImage.transform.localPosition = new Vector2(gameObject.transform.localPosition.x + 1500, 0);
    //        posisi = 0;
    //    }

    //    else if (posisi == 0)
    //    {
    //        GameObject LastImage = Instantiate(ChapterImage[pos.Length], this.gameObject.transform);
    //        ChapterImage.Add(LastImage);
    //        ChapterImage.RemoveAt(pos.Length);
    //        DestroyImmediate(ChapterImage[pos.Length]);
    //        LastImage.transform.localPosition = new Vector2(gameObject.transform.localPosition.x - 1500, 0);
    //        posisi = pos.Length;
    //    }
    //}

    #region Chapter Iamge 아래 버튼 설정
    public void StageButtonSetting()
    {
        int btnCount = 0;

        switch (posisi)
        {
            case 0:
                btnCount = 6;
                break;
            case 1:
                btnCount = 4;
                break;


                //ChapterStageBtn
        }

        for (int i = 0; i < ChapterStageBtn.Length; i++)
        {
            if (i <= btnCount)
                ChapterStageBtn[i].SetActive(true);
            else
                ChapterStageBtn[i].SetActive(false);
        }


    }
    #endregion

    #region 챕터 텍스트 이미지 설정


    #endregion
}