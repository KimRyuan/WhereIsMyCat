using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionInfo
{
    public int catCode;
    public string catName;
    public string catDescription;
    public bool isCollected;
    //public Image catImage;

    public CollectionInfo(int _catCode, string _catName, string _catDescription, bool _isCollected)
    {
        catCode = _catCode;
        catName = _catName;
        catDescription = _catDescription;
        isCollected = _isCollected;
    }
}

public class CollectionInfoList : MonoBehaviour
{
    public List<CollectionInfo> collectionInfoList = new List<CollectionInfo>();

    void CollectionInfoListSettnig()
    {
        //0~9 : 일반 냥이 10~19 : C1L1 20~30 C1L2
        collectionInfoList.Add(new CollectionInfo(0, "윙크냥이", "당신을 보고 윙크를 합니다! 매력적이군요.", true));
        collectionInfoList.Add(new CollectionInfo(1, "산책냥이", "산책을 하고 있는 산책냥이입니다. 혼자서도 길을 잃지 않습니다.", false));
        collectionInfoList.Add(new CollectionInfo(2, "나는냥이", "날개를 활짝펴고~ 세상을 자유롭게 날거야~! 노래하며 춤추는~ 나는 아름다운 냥이↗↗↗!!!!!!", false));
        collectionInfoList.Add(new CollectionInfo(3, "저기봐냥이", "저기에 뭔가 있다고 가르키고 있습니다. 옛부터 동물들은 귀신을 본다는데.. 혹시…?", false));
        collectionInfoList.Add(new CollectionInfo(4, "멍뎅냥이", "나는 존재한다 고로 냥이한다. -르네 냥카르트-", false));
        collectionInfoList.Add(new CollectionInfo(5, "착붙냥이", "착 붙어 있습니다. 거미냥이가 꿈일지도 모르겠군요!", false));
        collectionInfoList.Add(new CollectionInfo(6, "누운냥이", "벌러덩 누운 귀여운 냥이입니다. 누워만 있어도 신나는 것 같군요.", false));
        collectionInfoList.Add(new CollectionInfo(7, "쿨쿨냥이", "불편해보이는 자세로 편히 자고있습니다. 흠.. 냥이들의 신비한 점중 하나죠.", false));
        collectionInfoList.Add(new CollectionInfo(8, "점프냥이", "냥이 점프! 냥이 점프! 와냥냥냥냥냥냥!!", false));
        collectionInfoList.Add(new CollectionInfo(9, "놀란냥이", "경악한 건지 경이로운 건지 아무튼 놀란 것 같습니다. 당신 쪽을 보고 놀란 것 같은데.. 혹시 뭔가 하셨나요?", false));


        //0~9 : 일반 냥이 10~19 : C1L1 20~30 C1L2
        collectionInfoList.Add(new CollectionInfo(10, "빨래속냥이", "빨래 속에 숨어있던 냥이입니다. 바지까지 입다니.. 땡땡이가 잘 어울리는군요!", false));
        collectionInfoList.Add(new CollectionInfo(11, "얼음요정냥", "냉장고가 차가운 이유를 알고 계시나요? 대부분은 얼음요정냥의 덕분입니다! 물론 고장 나는 것 도요!", false));
        collectionInfoList.Add(new CollectionInfo(12, "솜쿨쿨냥", "포근하게 자고 있군요. 저 사랑스러운 하트 무늬를 눌러보고 싶지만.. 대신 자장가라도 한 곡 불러주는 건 어떨까요?", false));
        collectionInfoList.Add(new CollectionInfo(13, "솜스쿠버냥이", "이 스쿠버냥이는 솜 속이 바다라고 생각하고 있습니다. 언제쯤 진정한 바다를 알게 될까요?", false));
        collectionInfoList.Add(new CollectionInfo(14, "슬픈베개냥이", "8ㅅ8) 인생이 서럽습니다.", false));
        collectionInfoList.Add(new CollectionInfo(15, "커텐냥이", "최선을 다해 숨었는데! 아! 잔인한 사람!", false));
        collectionInfoList.Add(new CollectionInfo(16, "구름냥이", "보송보송하다 못해 구름이 되어버린 냥이입니다.", false));
        collectionInfoList.Add(new CollectionInfo(17, "책냥이", "끼여서 하는 독서가 집중에 좋다는 이야기를 아시나요? 최소한 이 냥이에게 그 말은 맞는 말입니다.", false));
        collectionInfoList.Add(new CollectionInfo(18, "첩보원냥이", "‘띵띠리딩 딩딩딩 띙띠리딩 딍딍딍..’ ♬007 : James Bond : Theme♬", false));
        collectionInfoList.Add(new CollectionInfo(19, "그냥눕냥", "그냥 누워있는 것처럼 보이는 냥이지만.. 사실 당신에게 인사하고 있었습니다!", false));


        collectionInfoList.Add(new CollectionInfo(20, "로봇청소기냥이", "로봇청소기를 제2의 집사로 두고 있습니다. 제2의 집사가 가끔 어딘 가에 부딪히지만.. 상냥하게도 집사를 꾸짖지 않습니다!", false));
        collectionInfoList.Add(new CollectionInfo(21, "진짜스쿠버냥이", "스쿠버냥이는 결국 진정한 바다를 찾았습니다! 수족관 안 물고기가 겁먹어 보이는 것은 착각이겠죠?", false));
        collectionInfoList.Add(new CollectionInfo(22, "흙냥이", "흙을 잔뜩 뒤집어쓴 채 신나 하고 있습니다. 곧 집사의 잔소리를 잔뜩 듣게 생겼군요!", false));
        collectionInfoList.Add(new CollectionInfo(23, "TV앞냥이", "TV 앞에 앉아있는 걸 가장 좋아하는 냥이입니다. 아무도 냥이의 존재를 모르고 있었습니다.. 당신이 찾기 전까진!", false));
        collectionInfoList.Add(new CollectionInfo(24, "휴지냥이", "휴지냥이는 재밌게 놀고 있었습니다만.. 지금은 꽁꽁 묶여서 당황했습니다. 자신이 미라가 됐다는 사실을 모르는 것 같군요! ", false));
        collectionInfoList.Add(new CollectionInfo(25, "캣휠냥이", "열심히 달리던 캣휠냥이는 순간 이런 생각이 들었습니다. ‘어?’", false));
        collectionInfoList.Add(new CollectionInfo(26, "휴식냥이", "아주 편안한 자세로 휴식을 취하고 있습니다. 보기만 해도 편안해지는 것 같군요..!", false));
        collectionInfoList.Add(new CollectionInfo(27, "구석냥이", "작은 흔들의자의 구석에 끼여있던 냥이입니다. 간식을 챙겨오는 것을 깜빡해서 어찌할지 생각 중이군요.", false));
        collectionInfoList.Add(new CollectionInfo(28, "생각하는냥이", "생각에 잠겨 있던 고양이입니다. 공상은 생각하는 냥이의 가장 친한 친구라고 하네요.", false));
        collectionInfoList.Add(new CollectionInfo(29, "난간냥이", "난간에 달라붙는 것까진 좋았는데.. 저런, 이제 떨어질 일만 남았군요.", false));
        collectionInfoList.Add(new CollectionInfo(30, "장난감냥이", "녀석을 강력하게 제압했다고 생각했는데 사실 제압 당한 건 이쪽이었습니다.", false));

    }


    private void Awake()
    {
        CollectionInfoListSettnig();
    }
}
