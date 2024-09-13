public interface EnvObjAbstractFactory
{
    Tree CreateTree();
    Rock CreateRock();
    Grass CreateGrass();
}

class ForestFactory : EnvObjAbstractFactory
{
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