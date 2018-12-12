using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Todo
{
    public class InsertStaticItems
    {
        readonly DBContext context = new DBContext();
        public InsertStaticItems()
        {
            if (context.GetAll().Count() == 0)
                CreateAndInserStatictItems();
        }

        public void CreateAndInserStatictItems()
        {
            var list = new List<UnitTestModel>
            {
                new UnitTestModel(){Name="Ali",Surname="Panzer",FavoutireHero="Man of Stell",Address="Xanık",Status=true},
                new UnitTestModel(){Name="Melik",Surname="Çarpan",FavoutireHero="The Slap",Address="Xanık",Status=true},
                new UnitTestModel(){Name="Le Burhan",Surname="James",FavoutireHero="Lebron James",Address="Xanık",Status=true},
                new UnitTestModel(){Name="Tom",Surname="Hardy",FavoutireHero="The Rock",Address="LA",Status=true},
                new UnitTestModel(){Name="Red",Surname="Kit",FavoutireHero="The Daltons",Address="Texas",Status=true},
                new UnitTestModel(){Name="Maykil",Surname="Man",FavoutireHero="Batman",Address="Batman",Status=true}
            };

            context.InsertStaticItems(list);

        }
    }
}
