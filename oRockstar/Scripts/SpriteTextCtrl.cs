using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SpriteTextCtrl : MonoBehaviour {

    public GameObject spriteElementPrefab;
    public int spacing = 33;
    public string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    public bool ignoreCase = true;
    public List<Sprite> sprites;
    public string editorText;
    public bool clearFlag = false;
    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
            editorText = value;
            ApplyText();
        }
    }
    
    private string _text;
    public List<Image> _images = new List<Image>();

	// Use this for initialization
	void Start () {
        //Text = "PERFECT SCORE IS 12936490";
        //Text = "SCORE 0";
	}

    public void SetSprites(List<Sprite> newSprites)
    {
        sprites = newSprites;
    }
	
	// Update is called once per frame
	void Update () {

        if (clearFlag)
        {
            clearFlag = false;
            
            foreach (var item in _images)
            {
                if (item != null)
                    DestroyImmediate(item.gameObject);
            }
            _text = "";
            _images.Clear();
        }

	    if (_text != editorText)
        {
            Text = editorText;
        }
	}

    void AddOneImage()
    {
        int id = _images.Count;
        var obj = Instantiate(spriteElementPrefab, transform) as GameObject;
        var _image = obj.GetComponent<Image>();
        var templateTrans = spriteElementPrefab.GetComponent<RectTransform>();
        var pos = templateTrans.localPosition;
        pos.x = id * spacing;
        _image.rectTransform.localPosition = pos;
        _image.rectTransform.localScale = templateTrans.localScale;
        _image.rectTransform.localRotation = templateTrans.localRotation;
        var sizeDelta = templateTrans.sizeDelta;
        _image.rectTransform.sizeDelta = sizeDelta;

        _images.Add(_image);
    }

    void ApplyText()
    {
        string show_text = _text;
        if (ignoreCase)
            show_text = show_text.ToUpper();
        int new_count = show_text.Length - _images.Count;
        if (new_count > 0)
        {
            for (int i = 0;i < new_count; i ++)
            {
                AddOneImage();
            }
        }

        for (int i = 0; i < show_text.Length; i ++)
        {
            var c = show_text[i];
            var index = characters.IndexOf(c);
            if (index < 0)
            {
                _images[i].gameObject.SetActive(false);
            }
            else
            {
                _images[i].gameObject.SetActive(true);
                _images[i].sprite = sprites[index];
            }
        }

        for (int i = show_text.Length; i < _images.Count; i++)
            _images[i].gameObject.SetActive(false);
    }
}
