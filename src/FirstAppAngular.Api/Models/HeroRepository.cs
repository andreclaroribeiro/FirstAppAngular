using System.Collections.Generic;
using System.Linq;

namespace FirstAppAngular.Api.Models
{
    public class HeroRepository
    {
        private static IList<Hero> _dbHeroes;

        public IList<Hero> FindAll()
        {
            if (_dbHeroes != null && _dbHeroes.Count() > 0)
            {
                return _dbHeroes;
            }

            _dbHeroes = new List<Hero>() {
                new Hero { Id= 11, Name= "Mr. Nice" },
                new Hero { Id = 12, Name = "Narco" },
                new Hero { Id = 13, Name = "Bombasto" },
                new Hero { Id = 14, Name = "Celeritas" },
                new Hero { Id = 15, Name = "Magneta" },
                new Hero { Id = 16, Name = "RubberMan" },
                new Hero { Id = 17, Name = "Dynama" },
                new Hero { Id = 18, Name = "Dr IQ" },
                new Hero { Id = 19, Name = "Magma" },
                new Hero { Id = 20, Name = "Tornado" }
            };

            return _dbHeroes;
        }

        public Hero FindById(int id)
        {
            return FindAll().ToList().FirstOrDefault(x => x.Id == id);
        }

        public void SaveOrUpdate(Hero hero)
        {
            var heroes = FindAll();

            if (hero.Id == 0)
            {
                hero.Id = _dbHeroes.Max(x => x.Id) + 1;
                _dbHeroes.Add(hero);
                return;
            }

            var heroCurrent = heroes.FirstOrDefault(x => x.Id == hero.Id);

            foreach (var item in _dbHeroes)
            {
                if (item.Id == hero.Id)
                {
                    item.Name = hero.Name;
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            _dbHeroes.Remove(_dbHeroes.FirstOrDefault(x => x.Id == id));
        }

        public IList<Hero> FindByName(string name)
        {
            return FindAll().Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}