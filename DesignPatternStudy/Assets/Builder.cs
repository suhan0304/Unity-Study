using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPC
{
    private string name;
    private int level;

    private NPC(Builder builder)
    {
        this.name = builder.name;
        this.level = builder.level;
    }

    public string Name => name; 
    public int Level => level;  

    public class Builder
    {
        internal string name; 
        internal int level;

        public Builder Name(string name)
        {
            this.name = name;
            return this; 
        }

        public Builder Level(int level)
        {
            this.level = level;
            return this; 
        }

        public NPC Build()
        {
            return new NPC(this); 
        }
    }
}

public class Builder : MonoBehaviour
{
}
