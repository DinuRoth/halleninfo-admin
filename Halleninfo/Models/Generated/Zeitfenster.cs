
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Halleninfo {
    public partial class Zeitfenster: DBO {
        [Obsolete ("This constructor is for internal use only. Use DBO(IUserDB db) instead.")]
        public Zeitfenster () : base() { }
        public Zeitfenster (IUserDB db) : base (db) { }

		private System.String? _Zeitfenster_Bez;
		private System.String? _Von;
		private System.String? _Bis;
		private System.Int32? _Wochentag_FK;
		private System.Int32 _xtUsergroup_FK;


        [Column]
        [Key]
		public Int32 Zeitfenster_ID { get; set; }
        public override Int32 Id {
            get { return Zeitfenster_ID; }
        }

		[Column]
		[StringLength(100)]
		public System.String? Zeitfenster_Bez {
            get { return _Zeitfenster_Bez; }
            set {
                if (value != _Zeitfenster_Bez) {
                    var oldVal = _Zeitfenster_Bez;
                    _Zeitfenster_Bez = value;
                
                    OnFieldChanged(nameof(Zeitfenster_Bez), oldVal, value);
                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Von {
            get { return _Von; }
            set {
                if (value != _Von) {
                    var oldVal = _Von;
                    _Von = value;
                
                    OnFieldChanged(nameof(Von), oldVal, value);
                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Bis {
            get { return _Bis; }
            set {
                if (value != _Bis) {
                    var oldVal = _Bis;
                    _Bis = value;
                
                    OnFieldChanged(nameof(Bis), oldVal, value);
                }
            }
        }
		[Column]
		[ForeignKey ("Wochentag")]
		public System.Int32? Wochentag_FK {
            get { return _Wochentag_FK; }
            set {
                if (value != _Wochentag_FK) {
                    var oldVal = _Wochentag_FK;
                    _Wochentag_FK = value;
                _Wochentag = null; // reset the foreign DBO
                    OnFieldChanged(nameof(Wochentag_FK), oldVal, value);
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

		public Wochentag? _Wochentag;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public Wochentag? Wochentag {
            get {
                if (_Wochentag == null) {
                    _Wochentag = Database.Read<Wochentag> (Wochentag_FK ?? 0);
                }
                return _Wochentag;
            }
            set {
                Wochentag_FK = value?.Id;
                _Wochentag = value;

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


        private List<Belegung>? _Belegung_Liste;
        [InverseProperty("Zeitfenster_FK")]
        [JsonIgnore]
        public List<Belegung> Belegung_Liste {
            get {
                if (_Belegung_Liste == null) {
                    _Belegung_Liste = Database.ReadMultiple<Belegung> ($"{nameof (Belegung.Zeitfenster_FK)} = {Zeitfenster_ID}");
                }
                return _Belegung_Liste;
            }
            set {
                _Belegung_Liste = value;
            }
        }


        public override void SetData(SqlDataReader reader, string prefix="") {
    base.SetData (reader, prefix);
			Zeitfenster_ID = (int)reader[prefix + nameof (Zeitfenster_ID)];
			_Zeitfenster_Bez = reader.ToNullableString (prefix + nameof(Zeitfenster_Bez));
			_Von = reader.ToNullableString (prefix + nameof(Von));
			_Bis = reader.ToNullableString (prefix + nameof(Bis));
			_Wochentag_FK = reader.ToNullableInt (prefix + nameof(Wochentag_FK));
			_xtUsergroup_FK = (System.Int32) reader[prefix + nameof(xtUsergroup_FK)];

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
