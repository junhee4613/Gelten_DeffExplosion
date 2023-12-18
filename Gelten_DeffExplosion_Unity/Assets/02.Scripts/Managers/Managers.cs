using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }
    // Start is called before the first frame update
    public static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
    GameManager _game = new GameManager();
    SoundManager _sound = new SoundManager();
    ResourceManager _resource = new ResourceManager();
    GridManager _grid = new GridManager();

    public static ResourceManager Resource { get { return Instance._resource; } }

    public static GameManager Game { get { return Instance._game; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static GridManager Grid { get { return Instance._grid; } }
}
