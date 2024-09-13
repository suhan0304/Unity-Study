public interface EnvObjAbstractFactory
{
    Tree CreateTree();
    Rock CreateRock();
    Grass CreateGrass();
}

class ForestFactory : EnvObjAbstractFactory
{
    private ForestFactory() { }

    private static class SingleInstanceHolder
    {
        public static readonly ForestFactory INSTANCE = new ForestFactory();
    }

    public static ForestFactory GetInstance()
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

class DesertFactory : EnvObjAbstractFactory
{ 
    private DesertFactory() { }

    private static class SingleInstanceHolder
    {
        public static readonly DesertFactory INSTANCE = new DesertFactory();
    }

    public static DesertFactory GetInstance()
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

class SwampFactory : EnvObjAbstractFactory
{ 
    private SwampFactory() { }

    private static class SingleInstanceHolder
    {
        public static readonly SwampFactory INSTANCE = new SwampFactory();
    }

    public static SwampFactory GetInstance()
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