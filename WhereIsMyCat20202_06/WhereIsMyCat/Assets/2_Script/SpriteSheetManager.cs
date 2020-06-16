using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class SpriteSheetManager : MonoBehaviour
{
    //스프라이트 시트에 포함된 스프라이트를 캐시하는 딕셔너리
    //private static Dictionary<string, Dictionary<string, Sprite>> spriteSheets =
    //    new Dictionary<string, Dictionary<string, Sprite>>();

    private static Dictionary<string, SpriteAtlas> spriteSheets =
    new Dictionary<string, SpriteAtlas>();

    //스프라이트 시트에 포함된 스프라이트를 읽어서 캐시하는 메서드
    public static void Load(string path)
    {
       
        if (!spriteSheets.ContainsKey(path))
        {
            SpriteAtlas atlas = Resources.Load<SpriteAtlas>(path);
            if(atlas != null)
            {
                spriteSheets.Add(path, atlas);
            }
        }
    }

    public static Sprite GetSpriteByName(string path, string name)
    {
        //if (spriteSheets.ContainsKey(path) && spriteSheets[path].ContainsKey(name))
        if(spriteSheets.ContainsKey(path) && spriteSheets[path].GetSprite(name))
        { 
            return spriteSheets[path].GetSprite(name);
        }
        return null;

    }

}
