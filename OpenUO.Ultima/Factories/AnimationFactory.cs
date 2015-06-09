﻿#region License Header

// /***************************************************************************
//  *   Copyright (c) 2011 OpenUO Software Team.
//  *   All Right Reserved.
//  *
//  *   AnimationFactory.cs
//  *
//  *   This program is free software; you can redistribute it and/or modify
//  *   it under the terms of the GNU General Public License as published by
//  *   the Free Software Foundation; either version 3 of the License, or
//  *   (at your option) any later version.
//  ***************************************************************************/

#endregion

#region Usings

using System.Threading.Tasks;

using OpenUO.Core.Patterns;
using OpenUO.Ultima.Adapters;

#endregion

namespace OpenUO.Ultima
{
    public class AnimationFactory : AdapterFactoryBase
    {
        public AnimationFactory(InstallLocation install, IContainer container)
            : base(install, container)
        {
        }

        public Frame<T>[] GetAnimation<T>(int body, int action, int direction, int hue, bool preserveHue)
        {
            return GetAdapter<IAnimationStorageAdapter<T>>().GetAnimation(body, action, direction, hue, preserveHue);
        }

        public Task<Frame<T>[]> GetAnimationAsync<T>(int body, int action, int direction, int hue, bool preserveHue)
        {
            return Task.Run(async () =>
            {
                var adapter = await GetAdapterAsync<IAnimationStorageAdapter<T>>().ConfigureAwait(false);

                return await adapter.GetAnimationAsync(body, action, direction, hue, preserveHue).ConfigureAwait(false);
            });
        }
    }
}