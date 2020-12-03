using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonCustom : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public UnityEvent OnClick;
    public static ButtonCustom ButtonAnim;
    [Header("General")]
    protected bool ifText;
    public string discription;
    public int layer;
    public bool Selected;
    [Header("Colours")]
    public Color baseColor;
    public Color hoverColor;
    public Color baseTextColor;
    public Color hoverTextColor;
    public Color selectedTextColour;
    [Header("Sounds")]
    public AudioClip hover;
    public AudioClip click;
    AudioSource source;
    Text text;

    private void Start()
    {
        if (GetComponent<Text>())
        {
            ifText = true;
            text = GetComponent<Text>();
        }
        else
        {
            text = GetComponentInChildren<Text>();
        }
        baseTextColor = text.color;
        if (!ifText)
        {
            baseColor = this.GetComponent<Image>().color;
        }
        source = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        Check();
    }

    public void Check()
    {
        if (ButtonAnim != this && !Selected)
        {
            if (!ifText)
            {
                GetComponent<Image>().color = baseColor;
            }
            text.color = baseTextColor;
        }
        else if (Selected && ButtonAnim == this)
        {
            text.color = hoverTextColor;
        }
        else if (Selected && ButtonAnim != this)
        {
            text.color = selectedTextColour;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonAnim = this;
        if (!ifText)
        {
            GetComponent<Image>().color = hoverColor;
        }
        text.color = hoverTextColor;
        source.clip = hover;
        source.Play();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(Selected)
        {
            GetComponent<Image>().color = baseColor;
        }
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Click();
        OnClick.Invoke();
    }

    public void Click()
    {
        source.clip = click;
        source.Play();
    }
}


