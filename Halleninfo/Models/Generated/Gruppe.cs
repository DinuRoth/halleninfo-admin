
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Halleninfo {
    public partial class Gruppe: DBO {
        [Obsolete ("This constructor is for internal use only. Use DBO(IUserDB db) instead.")]
        public Gruppe () : base() { }
        public Gruppe (IUserDB db) : base (db) { }

		private System.String _Gruppe_Bez;
		private System.Int32 _xtUsergroup_FK;
		private System.Int32? _GruppeTyp_FK;


        [Column]
        [Key]
		public Int32 Gruppe_ID { get; set; }
        public override Int32 Id {
            get { return Gruppe_ID; }
        }

		[Column]
		[StringLength(50)]
		public System.String Gruppe_Bez {
            get { return _Gruppe_Bez; }
            set {
                if (value != _Gruppe_Bez) {
                    var oldVal = _Gruppe_Bez;
                    _Gruppe_Bez = value;
                
                    OnFieldChanged(nameof(Gruppe_Bez), oldVal, value);
                }
            }
        }
		[Column]
		[ForeignKey ("xtUsergroup")]
		public System.Int32 xtUsergroup_FK {
            get { return _xtUsergroup_FK; }
            set {
                if (value != _xtUsergroup_FK) {
                    var oldVal = _xtUsergroup_FK;
                    _xtUsergroup_FK = value;
                _xtUsergroup = null; // reset the foreign DBO
                    OnFieldChanged(nameof(xtUsergroup_FK), oldVal, value);
                }
            }
        }
		[Column]
		[ForeignKey ("GruppeTyp")]
		public System.Int32? GruppeTyp_FK {
            get { return _GruppeTyp_FK; }
            set {
                if (value != _GruppeTyp_FK) {
                    var oldVal = _GruppeTyp_FK;
                    _GruppeTyp_FK = value;
                _GruppeTyp = null; // reset the foreign DBO
                    OnFieldChanged(nameof(GruppeTyp_FK), oldVal, value);
                }
            }
        }

		public xtUsergroup? _xtUsergroup;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public xtUsergroup? xtUsergroup {
            get {
                if (_xtUsergroup == null) {
                    _xtUsergroup = Database.Read<xtUsergroup> (xtUsergroup_FK);
                }
                return _xtUsergroup;
            }
            set {
                xtUsergroup_FK = value.Id;
                _xtUsergroup = value;

            }
        }
		public GruppeTyp? _GruppeTyp;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public GruppeTyp? GruppeTyp {
            get {
                if (_GruppeTyp == null) {
                    _GruppeTyp = Database.Read<GruppeTyp> (GruppeTyp_FK ?? 0);
                }
                return _GruppeTyp;
            }
            set {
                GruppeTyp_FK = value?.Id;
                _GruppeTyp = value;

            }
        }


        private List<Belegung>? _Belegung_Liste;
        [InverseProperty("Gruppe_FK")]
        [JsonIgnore]
        public List<Belegung> Belegung_Liste {
            get {
                if (_Belegung_Liste == null) {
                    _Belegung_Liste = Database.ReadMultiple<Belegung> ($"{nameof (Belegung.Gruppe_FK)} = {Gruppe_ID}");
                }
                return _Belegung_Liste;
            }
            set {
                _Belegung_Liste = value;
            }
        }


        public override void SetData(SqlDataReader reader, string prefix="") {
    base.SetData (reader, prefix);
			Gruppe_ID = (int)reader[prefix + nameof (Gruppe_ID)];
			_Gruppe_Bez = (System.String) reader[prefix + nameof(Gruppe_Bez)];
			_xtUsergroup_FK = (System.Int32) reader[prefix + nameof(xtUsergroup_FK)];
			_GruppeTyp_FK = reader.ToNullableInt (prefix + nameof(GruppeTyp_FK));

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
