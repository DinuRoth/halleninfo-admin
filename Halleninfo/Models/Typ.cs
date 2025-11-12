using System.Collections.ObjectModel;
using xTend;
using xTend.Service;

namespace Halleninfo {
    public class Typ : StaticDBO {
        public Typ()  : base (null) { }
        public Typ(IUserDB? db) : base (db) {
            Typ_Bez = "";
        }
        
        public Typ(int id, string bez, IUserDB? db = null) : base (db) {
            Id = id;
            Typ_ID = id;
            Typ_Bez = bez;
        }
        public int Typ_ID { get; set; }
        public string Typ_Bez { get; set; }

        public static ReadOnlyDictionary<int, StaticDBO> All { get; set; } = new ReadOnlyDictionary<int, StaticDBO> (new Dictionary<int, StaticDBO> {
            { Immer, new Typ(Immer, "Immer") },
            { Schulbetrieb, new Typ(Schulbetrieb, "Schulbetrieb") },
            { Ferien, new Typ(Ferien, "Ferien") },
            { Sommer, new Typ(Sommer, "Sommer") },
            { Winter, new Typ(Winter, "Winter") },
        });

        public const int Immer = 1;
        public const int Schulbetrieb = 2;
        public const int Ferien = 3;
        public const int Sommer = 4;
        public const int Winter = 5;


        public override Permission Permission => Permission.Read;
    }

}