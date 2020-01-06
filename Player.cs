using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KortSpel
{
    public class Player
    {
        public string Name { get; private set; }
        private int score;

        public Player(string name)
        {
            this.Name = name;
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
