﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.GameEngine
{
    public static class GameHandlerProvider
    {
        public static IGameHandler GetHandler() => GameHandler.GetHandler();
    }
}