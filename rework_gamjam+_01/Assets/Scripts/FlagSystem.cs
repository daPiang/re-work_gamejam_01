using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSystem : MonoBehaviour
{
    public static FlagSystem instance;

    public Flag[] flags;

    void Awake()
    {
        if(instance==null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public Flag GetFirstIncompleteFlag()
    {
        foreach (Flag flag in flags)
        {
            if (!flag.completed)
            {
                return flag;
            }
        }

        // If no incomplete flag is found, you can return null or a default Flag object.
        return null; // Or return a default Flag with flagName = "" and flagState = false.
    }

    public void SetFlag(string flagName, bool state)
    {
        foreach (Flag flag in flags)
        {
            if (flag.flagName == flagName)
            {
                flag.completed = state;
            }
        }
    }
}

[System.Serializable]

public class Flag
{
    public string flagName;
    public bool completed;
}
