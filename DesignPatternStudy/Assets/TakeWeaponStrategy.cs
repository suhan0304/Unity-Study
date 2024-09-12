public class TakeWeaponStrategy 
{
    public Weapon wp;

    public void setWeapon(Weapon wp) {
        this.wp = wp;
    }

    public void attack() {
        wp.offensive();
    }
}
