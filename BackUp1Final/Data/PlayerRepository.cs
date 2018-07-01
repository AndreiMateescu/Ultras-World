using BackUp1Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackUp1Final.Data
{
    public class PlayerRepository
    {
        public void Add(Player player)
        {
            using (var context = new Context())
            {
                context.Players.Add(player);
                context.SaveChanges();
            }
        }

        public int Size()
        {
            using (var context = new Context())
            {
                return context.Players.ToList().Count;
            }   
        }

        public int GetLastId()
        {
            int count = Size();

            using (var context = new Context())
            {
                var _players = context.Players.ToList();
                return _players[count - 1].Id;
            }
        }

        public bool ExistsId(int id)
        {
            bool found = false;
            using (var context = new Context())
            {
                var _players = context.Players.ToList();

                for (int index = 0; index < _players.Count; index++)
                {
                    if (id == _players[index].Id)
                    {
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        public Player GetPlayer(int id)
        {
            Player player = null;

            using (var context = new Context())
            {
                var _players = context.Players.ToList();

                foreach (var p in _players)
                {
                    if (p.Id == id)
                    {
                        player = p;
                        break;
                    }
                }
            }
            return player;
        }

        public List<Player> GetPlayers()
        {
            using (var context = new Context())
            {
                return context.Players.ToList();
            }
        }

        public void Update(Player player)
        {
            using (var context = new Context())
            {
                context.Players.Attach(player);
                var playerEntry = context.Entry(player);
                playerEntry.State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var deletedPlayer = context.Players.Find(id);
                context.Players.Attach(deletedPlayer);
                var playerEntry = context.Entry(deletedPlayer);
                playerEntry.State = System.Data.Entity.EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}