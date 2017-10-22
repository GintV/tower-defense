﻿using System.Numerics;
using TowerDefense.Source.Attacks.Projectiles.MoveTypes;

namespace TowerDefense.Source.Attacks.Projectiles
{
    public class Arrow : Projectile // TODO: to internal
    {
        public sealed override IMove MoveType { get; protected set; }

        public Arrow(int collisionDamage, double speed) : base(collisionDamage, speed)
        {
            MoveType = new ArchMove();
        }

        public override object Clone()
        {
            var arrow = (Arrow)MemberwiseClone();
            arrow.MoveType = (IMove)MoveType.Clone();
            return arrow;
        }

        public override void Upgrade()
        {
            CollisionDamage = (int)(CollisionDamage * Constants.ProjectileDamageMultiplier.Arrow);
        }
    }
}
