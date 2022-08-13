﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class StartMenu : MonoBehaviour
{
    [SerializeField]
    RectTransform Chosecenter;

    [SerializeField]
    RectTransform Equipment;

    [SerializeField]
    RectTransform Otheritem;

    [SerializeField]
    RectTransform Config;

    [SerializeField]
    RectTransform Information;

    [SerializeField]
    RectTransform cursol;

    [SerializeField]
    Transform[] iconinform;

    int nowcolum = 0;

    [SerializeField]
    TextMeshProUGUI[] tmpro;

    [SerializeField]
    GameObject Equipmentpanel;

    [SerializeField]
    GameObject Otherpanel;

    [SerializeField]
    GameObject Infomationpanel;

    [SerializeField]
    GameObject Configpanel;

    public enum cursolstate {active,sleep}
    private int cout = 0;
    public cursolstate cursols = cursolstate.active;

    static protected StartMenu s_startmenu;
    static public StartMenu menuInstance { get { return s_startmenu; } }

    void Start()
    {
        s_startmenu = this;
    }

    private void OnEnable()
    {
        Equipmentpanel.SetActive(false);
        Otherpanel.SetActive(false);
        Infomationpanel.SetActive(false);
        for (int i = 0; i < iconinform.Length; i++)
        {

            {
                iconinform[i].GetComponent<Image>().DOFade(1f, 0f);
                tmpro[i].DOFade(1f, 1f);

            }
        }
        cursol.GetComponent<Image>().DOFade(1f, 0f);
        Equipment.gameObject.SetActive(true);
        Otheritem.gameObject.SetActive(true);
        Information.gameObject.SetActive(true);

        for (int i = 0; i < tmpro.Length; i++)
            tmpro[i].DOText(tmpro[i].text, 2f, false, ScrambleMode.Uppercase).SetEase(Ease.Linear).SetUpdate(true);
        cursol.DOMove(iconinform[0].position, 0f).SetUpdate(true);

    }

    public void OnReset()
    {
        cursols = cursolstate.active;
           nowcolum = 0;
        Equipmentpanel.SetActive(false);
        Otherpanel.SetActive(false);
        Infomationpanel.SetActive(false);
        for (int i = 0; i < iconinform.Length; i++)
        {

            {
                iconinform[i].GetComponent<Image>().DOFade(1f, 0f);
                tmpro[i].DOFade(1f, 1f);

            }
        }
        cursol.GetComponent<Image>().DOFade(1f, 0f);
        Equipment.gameObject.SetActive(true);
        Otheritem.gameObject.SetActive(true);
        Information.gameObject.SetActive(true);

        for (int i = 0; i < tmpro.Length; i++)
            tmpro[i].DOText(tmpro[i].text, 2f, false, ScrambleMode.Uppercase).SetEase(Ease.Linear).SetUpdate(true);
        cursol.DOMove(iconinform[0].position, 0f).SetUpdate(true);

    }



    void Update()
    {

        if (cursols == cursolstate.active)
        {
            
            if (Playerinput.Instance.Select_Vert.Value <0&&cout==0)
            {
                cout = 1;
                Debug.Log("downs");
                cursoldown();
                
            }

            if (Playerinput.Instance.Select_Vert.Value ==1 && cout == 0)
            {
                cout = 1;
                cursolup();
            }

            if (Playerinput.Instance.Skill.Down)
            {
                cursoldecide();
            }

            if (Playerinput.Instance.Select_Vert.Value == 0)
                cout = 0;
        }
        else {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //Reset();
            }
        
        }

    }

    private void OnDisable()
    {
        iconinform[nowcolum ].GetComponent<Image>().DOPause();
        iconinform[nowcolum ].GetComponent<Image>().DOColor(Color.white, 1f); //tweenを止めてから消す
        nowcolum = 0;
        Equipmentpanel.SetActive(false);
        Otherpanel.SetActive(false);
        Infomationpanel.SetActive(false);
        Equipment.gameObject.SetActive(true);
        Otheritem.gameObject.SetActive(true);
        Information.gameObject.SetActive(true);
        cursols = cursolstate.active;
        //Configpanel.SetActive(false);
    }

    void cursoldown()
    {
        if (0 <= nowcolum && nowcolum < iconinform.Length - 1)
        {
           
            nowcolum++;
            cursol.DOMove(iconinform[nowcolum].position, 0.4f).SetUpdate(true);
            iconinform[nowcolum].GetComponent<Image>().DOColor(Color.black, 1f).SetLoops(-1, LoopType.Yoyo);
            iconinform[nowcolum-1].GetComponent<Image>().DOPause();
            iconinform[nowcolum - 1].GetComponent<Image>().DOColor(Color.white, 1f);
        }
        cout = 1;
    }

    void cursolup()
    {
        if (0 < nowcolum && nowcolum <= iconinform.Length)
        {
           
            nowcolum--;
            cursol.DOMove(iconinform[nowcolum].position, 0.4f).SetUpdate(true);
            iconinform[nowcolum].GetComponent<Image>().DOColor(Color.black, 1f).SetLoops(-1, LoopType.Yoyo);
            iconinform[nowcolum + 1].GetComponent<Image>().DOPause();
            iconinform[nowcolum + 1].GetComponent<Image>().DOColor(Color.white, 1f);
        }
        cout = 1;
    }

    void cursoldecide()
    {
        switch (nowcolum)
        {
            case 0:
                Equipmentpanel.SetActive(true);
                fadeout(nowcolum);
                cursol.GetComponent<Image>().DOFade(0f,1f);
                cursols = cursolstate.sleep;
                break;
            case 1:
                Otherpanel.SetActive(true);
                fadeout(nowcolum);
                cursol.GetComponent<Image>().DOFade(0f, 1f);
                cursols = cursolstate.sleep;
                break;
            case 2:
                Infomationpanel.SetActive(true);
                fadeout(nowcolum);
                cursol.GetComponent<Image>().DOFade(0f, 1f);
                cursols = cursolstate.sleep;
                break;
            case 3:
                Configpanel.SetActive(true);
                fadeout(nowcolum);
                cursol.GetComponent<Image>().DOFade(0f, 1f);
                cursols = cursolstate.sleep;
                break;
        }

    }

    void fadeout(int rest) {

        for (int i = 0; i <iconinform.Length; i++)
        {
            //iconinform[i].gameObject.SetActive(false);
            if (i != rest)
            {
                iconinform[i].GetComponent<Image>().DOFade(0f, 1f);
                tmpro[i].DOFade(0f, 1f).SetUpdate(true);

            }
            else
            {
                iconinform[i].GetComponent<Image>().gameObject.SetActive(false);
                tmpro[i].DOFade(0f, 1f).SetUpdate(true);

            }

        }
    
    }

    public void Reset()
    {
        for (int i = 0; i < iconinform.Length; i++)
        {

            {
                iconinform[i].gameObject.SetActive(true);
                iconinform[i].GetComponent<Image>().DOFade(1f, 1f);
                tmpro[i].DOFade(1f, 1f);

            }
        }
        cursol.GetComponent<Image>().DOFade(1f, 1f);
        Equipmentpanel.SetActive(false);
        Otherpanel.SetActive(false);
        Infomationpanel.SetActive(false);
        cursols = cursolstate.active;
        //Configpanel.SetActive(false);
    }

    public void Setcursolreturn()
    {
        cursols = cursolstate.active;  
    }

    public cursolstate Getcursolreturn()
    {
        return cursols;
    }

}
