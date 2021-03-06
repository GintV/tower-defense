﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using TowerDefense.GameEngine;
using TowerDefense.UI.Stylers;

namespace TowerDefense.UI
{
    public sealed class Shop : ClickableContainer
    {
        public Shop(Styler styler) : base(styler)
        {
            Position = Config.ShopPosition;
            Size = Config.ShopSize;
            Clickables = new List<IClickable>
            {
                new Button(new ClickableStyler(), _ => GameHandler.GetHandler().GameControls.CreateGuardian("Wizard", "Ice"), Config.ShopBlockSize)
                {
                    Description = "IW",
                    Position = BlockPositionByIndex(0)
                },
                new Button(new ClickableStyler(), _ => GameHandler.GetHandler().GameControls.CreateGuardian("Wizard", "Fire"), Config.ShopBlockSize)
                {
                    Description = "FW",
                    Position = BlockPositionByIndex(1)
                },
                new Button(new ClickableStyler(), _ => GameHandler.GetHandler().GameControls.CreateGuardian("Archer", "Light"), Config.ShopBlockSize)
                {
                    Description = "LA",
                    Position = BlockPositionByIndex(2)
                },
                new Button(new ClickableStyler(), _ => GameHandler.GetHandler().GameControls.CreateGuardian("Archer", "Dark"), Config.ShopBlockSize)
                {
                    Description = "DA",
                    Position = BlockPositionByIndex(3)
                },
                new Button(new ClickableStyler(), _ => GameHandler.GetHandler().GameControls.UpgradeTower(), Config.ShopBlockSize)
                {
                    Description = "UT",
                    Position = BlockPositionByIndex(4)
                },
                new Button(new ClickableStyler(), _ => GameHandler.GetHandler().GameControls.UndoLastPurchase(), Config.ShopBlockSize)
                {
                    Description = "Undo",
                    Position = BlockPositionByIndex(5)
                }
            };
            Draw();
        }

        protected override void Draw()
        {
            Image = new Bitmap((int)Size.X, (int)Size.Y);
            var g = Graphics.FromImage(Image);
            Styler.DrawRectangle(g, Vector2.Zero, Size);
            foreach (var block in Clickables)
            {
                g.DrawImage(block.Image, block.Position.X, block.Position.Y);
            }
            g.Dispose();
        }

        private static Vector2 BlockPositionByIndex(int i)
        {
            return new Vector2(Config.ShopBlockMargins.X * (i + 1) + Config.ShopBlockSize.X * i, Config.ShopBlockMargins.Y);
        }
    }
}
