

using System.Collections.ObjectModel;
using xTend;
using xTend.Service;


namespace Halleninfo {
    public class GruppeTyp : StaticDBO {
        public GruppeTyp() : base(null) {
            GruppeTyp_Bez = "";
        }
        
        public GruppeTyp(IUserDB? db) : base (db) {
            GruppeTyp_Bez = "";
        }
        
        public GruppeTyp(int id, string bez, IUserDB? db = null) : base (db) {
            Id = id;
            GruppeTyp_ID = id;
            GruppeTyp_Bez = bez;
        }
        public int GruppeTyp_ID { get; set; }
        public string GruppeTyp_Bez { get; set; }
        

        public static ReadOnlyDictionary<int, StaticDBO> All { get; set; } = new ReadOnlyDictionary<int, StaticDBO> (new Dictionary<int, StaticDBO> {
            { Schule, new GruppeTyp(Schule, "Schule") },
            { Verein, new GruppeTyp(Verein, "Verein") },
            { Kurs, new GruppeTyp(Kurs, "Kurs") },
        });
        
        public const int Schule = 1;
        public const int Verein = 2;
        public const int Kurs = 3;
        
        public override Permission Permission => Permission.Read;
        
    }

}