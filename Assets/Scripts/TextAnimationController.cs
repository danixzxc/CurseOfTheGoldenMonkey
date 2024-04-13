using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TextAnimationController : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset _font;
    private GameObject _text;
    public void IncreaseScore(Item item)
    {
        _text = Instantiate(new GameObject());
        TextMeshPro text = _text.AddComponent<TextMeshPro>();
        text.text = item.itemInfo.score + " pts";
        text.alignment = TextAlignmentOptions.Center;
        text.fontSize = 5;
        _text.transform.position = item.gameObject.transform.position;
        _text.transform.Translate(new Vector3(0, 0, -1));
        text.gameObject.transform.DOLocalMoveY(text.gameObject.transform.position.y + 1, .5f).OnComplete(aftertween);
        text.font = _font;
    }

    void aftertween()
    {
        _text.gameObject.transform.DOShakePosition(0.1f, 0.2f);

        _text.transform.DOScale(1.33f, .1f).OnComplete(destroy);
    }

    void destroy()
    {
        Destroy(_text);
    }
}
