using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MovetimeMaker : MonoBehaviour
{
    public enum state { play,pause,stop}
    public state State = state.play;
    public PlayableDirector playableDirector;
    public void puase()
    {
        playableDirector.Pause();
        State = state.pause;
    }
    public void restart()
    {

        if (Playerinput.Instance.Intract.Down)
            State=state.pause;
    }

    private void Update()
    {
       if(playableDirector.state == PlayState.Paused && Playerinput.Instance.Intract.Down)
        {
            playableDirector.Resume();
            State = state.play;
        }
    }

}
