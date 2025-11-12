
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Halleninfo {
    public partial class Halle: DBO {
        [Obsolete ("This constructor is for internal use only. Use DBO(IUserDB db) instead.")]
        public Halle () : base() { }
        public Halle (IUserDB db) : base (db) { }

		private System.String? _Halle_Bez;
		private System.Int32 _xtUsergroup_FK;


        [Column]
        [Key]
		public Int32 Halle_ID { get; set; }
        public override Int32 Id {
            get { return Halle_ID; }
        }

		[Column]
		[StringLength(255)]
		public System.String? Halle_Bez {
            get { return _Halle_Bez; }
            set {
                if (value != _Halle_Bez) {
                    var oldVal = _Halle_Bez;
                    _Halle_Bez = value;
                
                    OnFieldChanged(nameof(Halle_Bez), oldVal, value);
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
        [InverseProperty("Halle_FK")]
        [JsonIgnore]
        public List<Belegung> Belegung_Liste {
            get {
                if (_Belegung_Liste == null) {
                    _Belegung_Liste = Database.ReadMultiple<Belegung> ($"{nameof (Belegung.Halle_FK)} = {Halle_ID}");
                }
                return _Belegung_Liste;
            }
            set {
                _Belegung_Liste = value;
            }
        }


        public override void SetData(SqlDataReader reader, string prefix="") {
    base.SetData (reader, prefix);
			Halle_ID = (int)reader[prefix + nameof (Halle_ID)];
			_Halle_Bez = reader.ToNullableString (prefix + nameof(Halle_Bez));
			_xtUsergroup_FK = (System.Int32) reader[prefix + nameof(xtUsergroup_FK)];

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
