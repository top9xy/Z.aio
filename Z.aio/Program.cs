﻿using EnsoulSharp;

namespace Z.aio
{
    internal static class Program
    {
        internal static AIHeroClient Player { get { return ObjectManager.Player; } }

        internal static void Main(string[] args)
        {
            Bootstrap.Init();
        }
    }
}