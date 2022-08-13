using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
[CreateAssetMenu(fileName = "Flag", menuName = "flag")]
public class Flag_content : ScriptableObject
{
    public bool flag;
    public enum eventstate
    {
        colid, defeat, talk,
    }
   
    [System.Serializable]
    public class colidtype
    {
        public string colidname;
        public string colidtag;
        public GameObject target;
    }

    [System.Serializable]
    public class talktype
    {
        public string counter;
        public string countertype;

    }
    // Start is called before the first frame update

    public talktype Talktype;
    public colidtype Colidtype;
    public eventstate state;
    public Flag_content_List[] referenceflag;
    public int[] reference_listnumber;
    public string selfname;


}
