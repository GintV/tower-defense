﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TowerDefense.Source.Attacks.Projectiles.MoveTypes
{
    internal class LineMove : MoveType
    {

        public bool Move(ref Vector2 currentLocation, Vector2 targetLocation, int speed)
        {
            var trajectory = targetLocation - currentLocation;
            var distance = Math.Abs(trajectory.Length());
            if (distance <= speed)
            {
                currentLocation = targetLocation;
                return true;
            }
            currentLocation += Vector2.Normalize(trajectory) * speed;
            return false;
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override Vector2 Move()
        {
            throw new NotImplementedException();
        }
    }
}
