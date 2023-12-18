using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using static Define;


public class GameManager
{
    public GameData _gameData = new GameData();
    public void Init()
    {

    }

    public bool BGMOn
    {
        get { return _gameData.BGMOn; }
        set
        {
            _gameData.BGMOn = value;
        }
    }
    public bool EffectSoundOn 
    {
        get { return _gameData.EffectSoundOn; }
        set
        {
            _gameData.EffectSoundOn = value;
        }

    }


}
