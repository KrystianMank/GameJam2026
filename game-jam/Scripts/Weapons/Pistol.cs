using Godot;

public partial class Pistol: Weapon
{
	[Export] public PackedScene ProjectileScene;

    public override void FireWeapon()
    {
        base.FireWeapon();

		Projectile projectile = ProjectileScene.Instantiate<Projectile>();
		projectile.Position = GlobalPosition;
		GetTree().Root.AddChild(projectile);
    }

}
