
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Halleninfo {
    public partial class Wochentag: DBO {
        [Obsolete ("This constructor is for internal use only. Use DBO(IUserDB db) instead.")]
        public Wochentag () : base() { }
        public Wochentag (IUserDB db) : base (db) { }

		private System.String _Wochentag_Bez;


        [Column]
        [Key]
		public Int32 Wochentag_ID { get; set; }
        public override Int32 Id {
            get { return Wochentag_ID; }
        }

		[Column]
		[StringLength(255)]
		public System.String Wochentag_Bez {
            get { return _Wochentag_Bez; }
            set {
                if (value != _Wochentag_Bez) {
                    var oldVal = _Wochentag_Bez;
                    _Wochentag_Bez = value;
                
                    OnFieldChanged(nameof(Wochentag_Bez), oldVal, value);
                }
            }
        }



        private List<Zeitfenster>? _Zeitfenster_Liste;
        [InverseProperty("Wochentag_FK")]
        [JsonIgnore]
        public List<Zeitfenster> Zeitfenster_Liste {
            get {
                if (_Zeitfenster_Liste == null) {
                    _Zeitfenster_Liste = Database.ReadMultiple<Zeitfenster> ($"{nameof (Zeitfenster.Wochentag_FK)} = {Wochentag_ID}");
                }
                return _Zeitfenster_Liste;
            }
            set {
                _Zeitfenster_Liste = value;
            }
        }


        public override void SetData(SqlDataReader reader, string prefix="") {
    base.SetData (reader, prefix);
			Wochentag_ID = (int)reader[prefix + nameof (Wochentag_ID)];
			_Wochentag_Bez = (System.String) reader[prefix + nameof(Wochentag_Bez)];

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
