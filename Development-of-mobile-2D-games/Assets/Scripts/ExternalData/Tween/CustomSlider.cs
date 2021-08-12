using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomSlider : Slider
{
    public static string ColorOnClick => nameof(_colorOnClick);
    public static string ImageBur => nameof(_imageBur);
    public static string Duration => nameof(_duration);

    [SerializeField]
    private Image _colorOnClick;
    [SerializeField]
    private Image _imageBur;
    [SerializeField]
    private float _duration;

    private Color _color;

    protected override void Awake()
    {
        base.Awake();
        _imageBur.fillAmount = this.value;
        _color = _colorOnClick.color;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        _imageBur.fillAmount = this.value;
        _color.r = this.value;
        _colorOnClick.DOColor(_color, _duration);
        //он регитрирует нажатие, но я не понимаю почему не двигается ползунок
    }




}
