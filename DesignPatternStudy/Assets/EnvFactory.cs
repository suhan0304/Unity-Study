interface EnvObjFactoryMethod 
{
    EnvObj CreateOperation(string type); // 템플릿
    EnvObj CreateEnvObj(string type); // 팩토리 메서드
}

class TreeFactory : EnvObjFactoryMethod
{
    public EnvObj CreateOperation(string type)
    {
        EnvObj tree = CreateEnvObj(type);
        //tree.후처리();
        return tree;
    }

    public EnvObj CreateEnvObj(string type)
    {
        Tree tree = null;

        switch (type)
        {
            case "Forest" :
                tree = new ForestTree();
                break;
            case "Desert" :
                tree = new DesertTree();
                break;
        }
        return tree;
    }
}

class RockFactory : EnvObjFactoryMethod
{
    public EnvObj CreateOperation(string type)
    {
        EnvObj rock = CreateEnvObj(type);
        //rock.후처리();
        return rock;
    }

    public EnvObj CreateEnvObj(string type)
    {
        Rock rock = null;

        switch (type)
        {
            case "Forest" :
                rock = new ForestRock();
                break;
            case "Desert" :
                rock = new DesertRock();
                break;
        }
        return rock;
    }
}

class GrassFactory : EnvObjFactoryMethod
{
    public EnvObj CreateOperation(string type)
    {
        EnvObj grass = CreateEnvObj(type);
        //tree.후처리();
        return grass;
    }

    public EnvObj CreateEnvObj(string type)
    {
        Grass grass = null;

        switch (type)
        {
            case "Forest" :
                grass = new ForestGrass();
                break;
            case "Desert" :
                grass = new DesertGrass();
                break;
        }
        return grass;
    }
}