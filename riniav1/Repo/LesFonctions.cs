using System.Collections.Generic;
using System.Linq;

namespace riniav1.Repo
{
    public class LesFonctions
    {
        public readonly riniaContext _context;
        public LesFonctions(riniaContext context)
        {
            _context = context;
        }

        public List<Achat> GetAllAchat()
        {
            List<Achat> achats = _context.Achats.ToList();
            return achats;
        }
        public Article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(x => x.IdArt == id);
        }
    }
}
