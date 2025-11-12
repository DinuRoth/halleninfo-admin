using System.Collections.ObjectModel;
using xTend;
using xTend.Service;

namespace Halleninfo {
    public class Hallenstatus : xTend.StaticDBO {
        public Hallenstatus() : base (null) {
        }
        
        public Hallenstatus(IUserDB? db) : base (db) {
            Hallenstatus_Bez = "";
        }

        public Hallenstatus(int id, string bez, IUserDB? db = null) : base (db) {
            Hallenstatus_ID = id;
            Hallenstatus_Bez = bez;
        }

        public int Hallenstatus_ID { get; set; }
        public string Hallenstatus_Bez { get; set; }

        public static ReadOnlyDictionary<int, StaticDBO> All { get; set; } = new ReadOnlyDictionary<int, StaticDBO> (new Dictionary<int, StaticDBO> {
            { Geschlossen, new Hallenstatus(Geschlossen, "Geschlossen") },
            { Sommerbetrieb, new Hallenstatus(Sommerbetrieb, "Sommerbetrieb") },
            { Winterbetrieb, new Hallenstatus(Winterbetrieb, "Winterbetrieb") },
            { Ferienbetrieb, new Hallenstatus(Ferienbetrieb, "Ferienbetrieb") },
            { Sommerferienbetrieb, new Hallenstatus(Sommerferienbetrieb, "Sommerferienbetrieb") },
            { Winterferienbetrieb, new Hallenstatus(Winterferienbetrieb, "Winterferienbetrieb") },
        });
        
        public const int Geschlossen = 1;
        public const int Sommerbetrieb = 2;
        public const int Winterbetrieb = 3;
        public const int Ferienbetrieb = 4;
        public const int Sommerferienbetrieb = 5;
        public const int Winterferienbetrieb = 6;
        
        public override Permission Permission => Permission.Read;
    }
}