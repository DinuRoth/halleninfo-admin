
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Halleninfo {
    public partial class Freitext: DBO {
        [Obsolete ("This constructor is for internal use only. Use DBO(IUserDB db) instead.")]
        public Freitext () : base() { }
        public Freitext (IUserDB db) : base (db) { }

		private System.String? _Freitext_Bez;
		private System.DateTime? _Von;
		private System.DateTime? _Bis;
		private System.String? _Text;
		private System.Int32 _xtUsergroup_FK;
		private System.Boolean _IsLauf;
		private System.Boolean _Aktiv;


        [Column]
        [Key]
		public Int32 Freitext_ID { get; set; }
        public override Int32 Id {
            get { return Freitext_ID; }
        }

		[Column]
		[StringLength(255)]
		public System.String? Freitext_Bez {
            get { return _Freitext_Bez; }
            set {
                if (value != _Freitext_Bez) {
                    var oldVal = _Freitext_Bez;
                    _Freitext_Bez = value;
                
                    OnFieldChanged(nameof(Freitext_Bez), oldVal, value);
                }
            }
        }
		[Column]
		public System.DateTime? Von {
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
		public System.DateTime? Bis {
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
		[StringLength(2147483647)]
        [GUIType(GUIType.Enum.RichTextEditor)]
		public System.String? Text {
            get { return _Text; }
            set {
                if (value != _Text) {
                    var oldVal = _Text;
                    _Text = value;
                
                    OnFieldChanged(nameof(Text), oldVal, value);
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
		public System.Boolean IsLauf {
            get { return _IsLauf; }
            set {
                if (value != _IsLauf) {
                    var oldVal = _IsLauf;
                    _IsLauf = value;
                
                    OnFieldChanged(nameof(IsLauf), oldVal, value);
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



        public override void SetData(SqlDataReader reader, string prefix="") {
    base.SetData (reader, prefix);
			Freitext_ID = (int)reader[prefix + nameof (Freitext_ID)];
			_Freitext_Bez = reader.ToNullableString (prefix + nameof(Freitext_Bez));
			_Von = reader.ToNullableDateTime (prefix + nameof(Von));
			_Bis = reader.ToNullableDateTime (prefix + nameof(Bis));
			_Text = reader.ToNullableString (prefix + nameof(Text));
			_xtUsergroup_FK = (System.Int32) reader[prefix + nameof(xtUsergroup_FK)];
			_IsLauf = (System.Boolean) reader[prefix + nameof(IsLauf)];
			_Aktiv = (System.Boolean) reader[prefix + nameof(Aktiv)];

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
