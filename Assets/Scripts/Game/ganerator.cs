using System;
using System.Collections.Generic;
using UnityEngine;

public class ganerator : MonoBehaviour
{
    public List<GameObject> levels = new List<GameObject>();
    public List<bool> maps = new List<bool>(3000);
    public Transform player;
    public float platform_size = 17.75f;

    // Update is called once per frame
    void Update()
    {
        if (player.position.x < 17.75f && !maps[0])
        {
            transform.position = Vector3.zero;
            Instantiate(levels[UnityEngine.Random.Range(1, levels.Count-1)]);
            maps[0] = true;
        }
        else if (!maps[Convert.ToInt16(Mathf.Ceil(player.position.x/platform_size))])
        {
            transform.position = new Vector3(Mathf.Ceil(player.position.x / platform_size)*platform_size, 0, 0);
            var a = Instantiate(levels[UnityEngine.Random.Range(0, levels.Count - 1)], transform);
            a.transform.parent = null;
            maps[Convert.ToInt16(Mathf.Ceil(player.position.x / platform_size))] = true;
        }
    }
}
