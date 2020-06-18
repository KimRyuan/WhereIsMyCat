using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{

    //*************************UI 변수*******************
    public Slider soundSlider;
    public Text soundSliderText;

    public Image volumeImage;

    public InputField removeAccountInputText;

    public GameObject accountRemovePanel;
    //***************************************************
    // public NetworkRouter networkRouter = null;
    // Start is called before the first frame update

    private void Awake()
    {
        SpriteSheetManager.Load("UIAtlas");
    }
    void Start()
    {
        OptionSetting();
    }

    public void OptionSetting()
    {
        int volume = PlayerPrefs.GetInt("VOLUME");

        soundSlider.value = volume / 100;
        soundSliderText.text = ((int)(soundSlider.value * 100)).ToString();
    }

    public void OptionSoundSlider()
    {
        int volume = (int)(soundSlider.value * 100);
        soundSliderText.text = volume.ToString();

        if (volume <= 0)
        {
            volumeImage.sprite = SpriteSheetManager.GetSpriteByName("UIAtlas", "SettingImages_3");
        }
        else
        {
            volumeImage.sprite = SpriteSheetManager.GetSpriteByName("UIAtlas", "SettingImages_5");
        }

    }



    #region 계정 삭제 창 버튼 UI
    public void AccountRemoveButton()
    {
        accountRemovePanel.SetActive(true);
    }

    public void AccountRemoveOKButton()
    {
        if (removeAccountInputText.text == "초기화 합니다")
        {
            //networkRouter.PostRouter(PostType.PLAYER_CHARACTER_REMOVE, usercodeText.text);
        }
    }

    public void AccountRemoveCancleButton()
    {
        removeAccountInputText.text = "";
        accountRemovePanel.SetActive(false);
    }

    public void BackButton()
    {
        gameObject.SetActive(false);
    }


    #endregion
}


