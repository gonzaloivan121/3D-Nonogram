using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ToogleSwitch : MonoBehaviour, IPointerDownHandler {
    [SerializeField]
    private bool _isOn = false;
    public bool isOn {
        get {
            return _isOn;
        }
    }

    [SerializeField]
    private RectTransform indicator;
    [SerializeField]
    private Image backgroundImage;

    [SerializeField]
    private Color onColor, offColor;

    private float offY, onY;

    [SerializeField]
    private float tweenTime = .25f;

    public delegate void ValueChanged(bool value);
    public event ValueChanged valueChanged;

    AudioSource audioSource;
    public AudioClip switchOnClip;
    public AudioClip switchOffClip;

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
        offY = indicator.anchoredPosition.y; // start position
        onY = backgroundImage.rectTransform.rect.height - indicator.rect.height - indicator.rect.height / 2;
    }

    private void OnEnable() {
        Toogle(isOn); // make sure the switch is set correctly
    }

    private void Toogle(bool value) {
        if (value != isOn) {
            _isOn = value;

            ToogleColor(isOn);
            MoveIndicator(isOn);

            if (valueChanged != null) valueChanged(isOn);

            if (value) {
                PlaySound(switchOnClip);
            } else {
                PlaySound(switchOffClip);
            }
        }
    }

    private void PlaySound(AudioClip a) {
        if (audioSource.clip != a) {
            audioSource.clip = a;
        }
        audioSource.Play();
    }

    private void ToogleColor(bool value) {
        if (value) {
            backgroundImage.DOColor(onColor, tweenTime);
        } else {
            backgroundImage.DOColor(offColor, tweenTime);
        }
            
    }

    private void MoveIndicator(bool value) {
        if (value) {
            indicator.DOAnchorPosY(onY, tweenTime);
        } else {
            indicator.DOAnchorPosY(offY, tweenTime);
        }

    }

    public void OnPointerDown(PointerEventData eventData) {
        Toogle(!isOn); // flips the switch when clicked
        //throw new System.NotImplementedException();
    }
}
