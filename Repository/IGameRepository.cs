﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazar.Domain.Entities;

namespace Bazar
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetGames();
        Game GetGame(int id);
        Game GetGame(string slug);

        void Add(Game game);
        void Remove(Game game);

    }
}
