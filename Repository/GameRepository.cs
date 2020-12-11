using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bazar.Domain.Entities;
//using System.Data.Entity;
using Bazar.Data;
using Microsoft.EntityFrameworkCore;

namespace Bazar
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Game> GetGames()
        {
            return _context.Games.
                Include(g=>g.MediaResources).
                Include(g=>g.Genres).
                Include(g=>g.Modes).
                Include(g => g.Platforms);
        }

        public Game GetGame(int id)
        {
            return _context.Games.
                Include(g => g.MediaResources).
                Include(g=>g.Genres).
                Include(g => g.SystemRequirements).
                Include(g => g.Modes).
                Include(g => g.Platforms).
                SingleOrDefault(g => g.Id == id);
        }

        public Game GetGame(string slug)
        {
            return _context.Games.
                Include(g => g.MediaResources).
                Include(g => g.Genres).
                Include(g=>g.SystemRequirements).
                Include(g => g.Modes).
                Include(g => g.Platforms).
                SingleOrDefault(g => g.Slug.Equals(slug));
        }

        public void Add(Game game)
        {
            _context.Games.Add(game);
        }

        public void Remove(Game game)
        {
            _context.Games.Remove(game);
        }
    }
}