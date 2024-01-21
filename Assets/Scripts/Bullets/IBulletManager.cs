namespace ShootEmUp
{
    public interface IBulletManager
    {
        void Init();
        void FixedUpdate();
        void FlyBulletByArgs(BulletSystem.Args args);
    }
}