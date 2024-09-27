public class TakeWeaponStrategy 
{
    public WeaponManager wp;

    public void setWeapon(WeaponManager wp) {
        this.wp = wp;
    }

    public void attack() {
        wp.offensive();
    }
}
