
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Halleninfo {
    public partial class Belegung: DBO {
        [Obsolete ("This constructor is for internal use only. Use DBO(IUserDB db) instead.")]
        public Belegung () : base() { }
        public Belegung (IUserDB db) : base (db) { }

		private System.Int32 _Zeitfenster_FK;
		private System.Int32 _Halle_FK;
		private System.Int32 _Raum_FK;
		private System.Int32 _xtUsergroup_FK;
		private System.Boolean _Aktiv;
		private System.Int32 _Typ_FK;
		private System.Int32? _Gruppe_FK;
		private System.String? _GruppeStrinh;


        [Column]
        [Key]
		public Int32 Belegung_ID { get; set; }
        public override Int32 Id {
            get { return Belegung_ID; }
        }

		[Column]
		[ForeignKey ("Zeitfenster")]
		public System.Int32 Zeitfenster_FK {
            get { return _Zeitfenster_FK; }
            set {
                if (value != _Zeitfenster_FK) {
                    var oldVal = _Zeitfenster_FK;
                    _Zeitfenster_FK = value;
                _Zeitfenster = null; // reset the foreign DBO
                    OnFieldChanged(nameof(Zeitfenster_FK), oldVal, value);
                }
            }
        }
		[Column]
		[ForeignKey ("Halle")]
		public System.Int32 Halle_FK {
            get { return _Halle_FK; }
            set {
                if (value != _Halle_FK) {
                    var oldVal = _Halle_FK;
                    _Halle_FK = value;
                _Halle = null; // reset the foreign DBO
                    OnFieldChanged(nameof(Halle_FK), oldVal, value);
                }
            }
        }
		[Column]
		[ForeignKey ("Raum")]
		public System.Int32 Raum_FK {
            get { return _Raum_FK; }
            set {
                if (value != _Raum_FK) {
                    var oldVal = _Raum_FK;
                    _Raum_FK = value;
                _Raum = null; // reset the foreign DBO
                    OnFieldChanged(nameof(Raum_FK), oldVal, value);
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
		public System.Boolean Aktiv {
            get { return _Aktiv; }
            set {
                if (value != _Aktiv) {
                    var oldVal = _Aktiv;
                    _Aktiv = value;
                
                    OnFieldChanged(nameof(Aktiv), oldVal, value);
                }
            }
        }
		[Column]
		[ForeignKey ("Typ")]
		public System.Int32 Typ_FK {
            get { return _Typ_FK; }
            set {
                if (value != _Typ_FK) {
                    var oldVal = _Typ_FK;
                    _Typ_FK = value;
                _Typ = null; // reset the foreign DBO
                    OnFieldChanged(nameof(Typ_FK), oldVal, value);
                }
            }
        }
		[Column]
		[ForeignKey ("Gruppe")]
		public System.Int32? Gruppe_FK {
            get { return _Gruppe_FK; }
            set {
                if (value != _Gruppe_FK) {
                    var oldVal = _Gruppe_FK;
                    _Gruppe_FK = value;
                _Gruppe = null; // reset the foreign DBO
                    OnFieldChanged(nameof(Gruppe_FK), oldVal, value);
                }
            }
        }
		[Column]
		[StringLength(90)]
		public System.String? GruppeStrinh {
            get { return _GruppeStrinh; }
            set {
                if (value != _GruppeStrinh) {
                    var oldVal = _GruppeStrinh;
                    _GruppeStrinh = value;
                
                    OnFieldChanged(nameof(GruppeStrinh), oldVal, value);
                }
            }
        }

		public Zeitfenster? _Zeitfenster;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public Zeitfenster? Zeitfenster {
            get {
                if (_Zeitfenster == null) {
                    _Zeitfenster = Database.Read<Zeitfenster> (Zeitfenster_FK);
                }
                return _Zeitfenster;
            }
            set {
                Zeitfenster_FK = value.Id;
                _Zeitfenster = value;

            }
        }
		public Halle? _Halle;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public Halle? Halle {
            get {
                if (_Halle == null) {
                    _Halle = Database.Read<Halle> (Halle_FK);
                }
                return _Halle;
            }
            set {
                Halle_FK = value.Id;
                _Halle = value;

            }
        }
		public Raum? _Raum;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public Raum? Raum {
            get {
                if (_Raum == null) {
                    _Raum = Database.Read<Raum> (Raum_FK);
                }
                return _Raum;
            }
            set {
                Raum_FK = value.Id;
                _Raum = value;

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
		public Typ? _Typ;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public Typ? Typ {
            get {
                if (_Typ == null) {
                    _Typ = Database.Read<Typ> (Typ_FK);
                }
                return _Typ;
            }
            set {
                Typ_FK = value.Id;
                _Typ = value;

            }
        }
		public Gruppe? _Gruppe;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public Gruppe? Gruppe {
            get {
                if (_Gruppe == null) {
                    _Gruppe = Database.Read<Gruppe> (Gruppe_FK ?? 0);
                }
                return _Gruppe;
            }
            set {
                Gruppe_FK = value?.Id;
                _Gruppe = value;

            }
        }



        public override void SetData(SqlDataReader reader, string prefix="") {
    base.SetData (reader, prefix);
			Belegung_ID = (int)reader[prefix + nameof (Belegung_ID)];
			_Zeitfenster_FK = (System.Int32) reader[prefix + nameof(Zeitfenster_FK)];
			_Halle_FK = (System.Int32) reader[prefix + nameof(Halle_FK)];
			_Raum_FK = (System.Int32) reader[prefix + nameof(Raum_FK)];
			_xtUsergroup_FK = (System.Int32) reader[prefix + nameof(xtUsergroup_FK)];
			_Aktiv = (System.Boolean) reader[prefix + nameof(Aktiv)];
			_Typ_FK = (System.Int32) reader[prefix + nameof(Typ_FK)];
			_Gruppe_FK = reader.ToNullableInt (prefix + nameof(Gruppe_FK));
			_GruppeStrinh = reader.ToNullableString (prefix + nameof(GruppeStrinh));

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
