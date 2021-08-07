using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : Button
{
    public static string ChangeButtonType => nameof(_animationButtonType);
    public static string CurveEase => nameof(_curveEase);
    public static string Duration => nameof(_duration);

    [SerializeField]
    private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;

    [SerializeField]
    private Ease _curveEase = Ease.Linear;

    [SerializeField]
    private float _duration = 0.6f;

    private float _strength = 30.0f;
    private RectTransform _rectTransform;

    protected override void Awake()
    {
        base.Awake();
        _rectTransform = GetComponent<RectTransform>();
    }

    public override void OnPointerClick(PointerEventData eventData) 
    {
        base.OnPointerClick(eventData);
        ActivateAnimation();
    }

    private void ActivateAnimation()
    {
        switch (_animationButtonType)
        {
            case AnimationButtonType.ChangeRotation:
                var sequence = DOTween.Sequence();
                sequence.Insert(0.0f, _rectTransform.DOShakeRotation(_duration, Vector3.forward * _strength).SetEase(_curveEase));
                sequence.OnComplete(() => 
                {
                    //необходимо, так как при множественном клике кнопка изменяет свое стандартное положение(в параметре rotation)
                    _rectTransform.DORotate(Vector3.zero, 0.1f); 
                });
                break;
            case AnimationButtonType.ChangePosition:
                _rectTransform.DOShakeAnchorPos(_duration, Vector2.one * _strength).SetEase(_curveEase);
                break;
            default:
                break;
        }
    }
}
