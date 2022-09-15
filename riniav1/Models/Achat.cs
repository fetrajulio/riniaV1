using System;
using System.Collections.Generic;

#nullable disable

namespace riniav1
{
    public partial class Achat
    {
        public int IdAchat { get; set; }
        public int IdArticle { get; set; }
        public int Nbr { get; set; }
        public int PrixTotal { get; set; }
        public DateTime Date { get; set; }
    }
}
