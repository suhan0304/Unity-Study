using UnityEngine;

interface EnvObj
{
    public void Create(); //환경 오브젝트 생성
}

public abstract class Tree : EnvObj { 
    public abstract void Create();
}

class ForestTree : Tree
{
    public override void Create()
    {
        Debug.Log("Forest Tree 생성 완료");
    }
}

class DesertTree : Tree
{
    public override void Create()
    {
        Debug.Log("Desert Tree 생성 완료");
    }
}

class SwampTree : Tree
{
    public override void Create()
    {
        Debug.Log("Swamp Tree 생성 완료");
    }
}

/*-------------------------------------------------------*/

public abstract class Rock : EnvObj { 
    public abstract void Create();
}

class ForestRock : Rock
{
    public override void Create()
    {
        Debug.Log("Forest Rock 생성 완료");
    }
}

class DesertRock : Rock
{
    public override void Create()
    {
        Debug.Log("Desert Rock 생성 완료");
    }
}

class SwampRock : Rock
{
    public override void Create()
    {
        Debug.Log("Swamp Rock 생성 완료");
    }
}

/*-------------------------------------------------------*/

public abstract class Grass : EnvObj { 
    public abstract void Create();
}

class ForestGrass : Grass
{
    public override void Create()
    {
        Debug.Log("Forest Grass 생성 완료");
    }
}

class DesertGrass : Grass
{
    public override void Create()
    {
        Debug.Log("Desert Grass 생성 완료");
    }
}

class SwampGrass : Grass
{
    public override void Create()
    {
        Debug.Log("Swamp Grass 생성 완료");
    }
}