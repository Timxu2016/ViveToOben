using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public static class BatchAddSprites
{
    static int ToNumber(string spriteName)
    {
        return int.Parse(spriteName.Substring(spriteName.LastIndexOf('_')+1));
    }

    [MenuItem("MJTools/Add sprites to ScoreText")]
    public static void BatchAddSpritesToScoreText()
    {
        Debug.Log("hello");
        List<Sprite> sprites = new List<Sprite>();
        foreach (var item in Selection.objects)
        {
            var sprite = item as Sprite;
            if (sprite != null)
            {
                sprites.Add(sprite);
                Debug.Log("Add sprite:" + sprite.name);
            }
        }
        sprites.Sort((a, b) => ToNumber(a.name).CompareTo(ToNumber(b.name)));
        var spriteText = GameObject.Find("ScoreText").GetComponent<SpriteTextCtrl>();
        spriteText.sprites = sprites;

    }
}
