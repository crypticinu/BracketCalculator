using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketCalculator.Models
{
    public class Player
    {
        public string FullName { get; set; }
        public int Points { get; set; }
        public Category Category { get; set; }
    }
}
