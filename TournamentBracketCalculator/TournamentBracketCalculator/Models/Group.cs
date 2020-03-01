using System;
using System.Collections.Generic;

namespace TournamentBracketCalculator.Models
{
    public class Group
    {
        public Category Category { get; set; }
        public List<Player> Players { get; set; }
        public int Size { get; set; }

        public Group()
        {
            Players = new List<Player>();
        }
    }
}
