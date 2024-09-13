using System;
using System.Collections;
using System.Collections.Generic;

public interface EnvObjAbstractFactoryMethod
{
    Tree CreateTree();
    Rock CreateRock();
    Grass CreateGrass();

    public List<EnvObj> createOperation()
    {
        Tree tree = CreateTree();
        Rock rock = CreateRock();
        Grass grass = CreateGrass();
        
        // tree.추가세팅(); //후처리
        // rock.추가세팅(); //후처리
        // grass.추가세팅(); //후처리
        
        return new List<EnvObj> { tree, rock, grass };
    }
}

class ForestFactoryMethod : EnvObjAbstractFactoryMethod
{
    private ForestFactoryMethod() { }

    private static class SingleInstanceHolder
    {
        public static readonly ForestFactoryMethod INSTANCE = new ForestFactoryMethod();
    }

    public static ForestFactoryMethod GetInstance()
    {
        return SingleInstanceHolder.INSTANCE;
    }

    public Tree CreateTree() {
        return new ForestTree();
    }
    public Rock CreateRock() {
        return new ForestRock();
    }
    public Grass CreateGrass() {
        return new ForestGrass();
    }
}

class DesertFactoryMethod : EnvObjAbstractFactoryMethod
{ 
    private DesertFactoryMethod() { }

    private static class SingleInstanceHolder
    {
        public static readonly DesertFactoryMethod INSTANCE = new DesertFactoryMethod();
    }

    public static DesertFactoryMethod GetInstance()
    {
        return SingleInstanceHolder.INSTANCE;
    }

    public Tree CreateTree() {
        return new DesertTree();
    }
    public Rock CreateRock() {
        return new DesertRock();
    }
    public Grass CreateGrass() {
        return new DesertGrass();
    }
}

class SwampFactoryMethod : EnvObjAbstractFactoryMethod
{ 
    private SwampFactoryMethod() { }

    private static class SingleInstanceHolder
    {
        public static readonly SwampFactoryMethod INSTANCE = new SwampFactoryMethod();
    }

    public static SwampFactoryMethod GetInstance()
    {
        return SingleInstanceHolder.INSTANCE;
    }
    
    public Tree CreateTree() {
        return new SwampTree();
    }
    public Rock CreateRock() {
        return new SwampRock();
    }
    public Grass CreateGrass() {
        return new SwampGrass();
    }
}