using BackUp1Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackUp1Final.Data
{
    public class TeamRepository
    { 
        public void Add(Team team)
        {
            using (var context = new Context())
            {
                context.Teams.Add(team);
                context.SaveChanges();
            }
        }

        public int Size()
        {
            using (var context = new Context())
            {
                return context.Teams.ToList().Count;
            }
        }

        public int GetLastId()
        {
            int count = Size();

            using (var context = new Context())
            {
                var _teams = context.Teams.ToList();
                return _teams[count-1].Id;
            }
        }

        public bool ExistsId(int id)
        {
            bool found = false;
            using (var context = new Context())
            {
                var _teams = context.Teams.ToList();
     
                for(int index=0; index<_teams.Count; index++)
                {
                    if (id == _teams[index].Id)
                    {
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        public Team GetTeam(int id)
        {
            Team team = null;

            using (var context = new Context())
            {
                var _teams = context.Teams.ToList();

                foreach (var t in _teams)
                {
                    if (t.Id == id)
                    {
                        team = t;
                        break;
                    }
                }
            }
            return team;
        }

        public List<Team> GetTeams()
        {
            using (var context = new Context())
            {
                return context.Teams.ToList();
            }
        }
        
        public void Update(Team team)
        {
            using (var context = new Context())
            {
                context.Teams.Attach(team);
                var teamEntry = context.Entry(team);
                teamEntry.State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var deletedTeam = context.Teams.Find(id);
                context.Teams.Attach(deletedTeam);
                var teamEntry = context.Entry(deletedTeam);
                teamEntry.State = System.Data.Entity.EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}