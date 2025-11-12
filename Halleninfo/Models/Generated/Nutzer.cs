
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Halleninfo {
    public partial class Nutzer: DBO {
        [Obsolete ("This constructor is for internal use only. Use DBO(IUserDB db) instead.")]
        public Nutzer () : base() { }
        public Nutzer (IUserDB db) : base (db) { }

		private System.String? _Nutzer_Bez;
		private System.String? _passwort;
		private System.Int32 _xtUsergroup_FK;
		private System.String? _htmlfile;
		private System.String? _xtUsergroup_FKList;


        [Column]
        [Key]
		public Int32 Nutzer_ID { get; set; }
        public override Int32 Id {
            get { return Nutzer_ID; }
        }

		[Column]
		[StringLength(50)]
		public System.String? Nutzer_Bez {
            get { return _Nutzer_Bez; }
            set {
                if (value != _Nutzer_Bez) {
                    var oldVal = _Nutzer_Bez;
                    _Nutzer_Bez = value;
                
                    OnFieldChanged(nameof(Nutzer_Bez), oldVal, value);
                }
            }
        }
		[Column]
		[StringLength(50)]
		public System.String? passwort {
            get { return _passwort; }
            set {
                if (value != _passwort) {
                    var oldVal = _passwort;
                    _passwort = value;
                
                    OnFieldChanged(nameof(passwort), oldVal, value);
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
		[StringLength(255)]
		public System.String? htmlfile {
            get { return _htmlfile; }
            set {
                if (value != _htmlfile) {
                    var oldVal = _htmlfile;
                    _htmlfile = value;
                
                    OnFieldChanged(nameof(htmlfile), oldVal, value);
                }
            }
        }
		[Column]
		[ForeignKey ("xtUsergroup_LST")]
		[StringLength(250)]
		public System.String? xtUsergroup_FKList {
            get { return _xtUsergroup_FKList; }
            set {
                if (value != _xtUsergroup_FKList) {
                    var oldVal = _xtUsergroup_FKList;
                    _xtUsergroup_FKList = value;
                _xtUsergroup_LST = null; // reset the foreign DBO
                    OnFieldChanged(nameof(xtUsergroup_FKList), oldVal, value);
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
		public List<xtUsergroup>? _xtUsergroup_LST;
       [GUIType(GUIType.Enum.Hidden)]
        public List<xtUsergroup>? xtUsergroup_LST {
            get {
                if (_xtUsergroup_LST == null) {
                    if (String.IsNullOrEmpty(xtUsergroup_FKList)) {
                        _xtUsergroup_LST = new();
                    } else {
                        _xtUsergroup_LST = Database.ReadMultiple<xtUsergroup> ($"xtUsergroup_ID IN ({xtUsergroup_FKList})");
                    }
                }
                return _xtUsergroup_LST;
            }
        }



        public override void SetData(SqlDataReader reader, string prefix="") {
    base.SetData (reader, prefix);
			Nutzer_ID = (int)reader[prefix + nameof (Nutzer_ID)];
			_Nutzer_Bez = reader.ToNullableString (prefix + nameof(Nutzer_Bez));
			_passwort = reader.ToNullableString (prefix + nameof(passwort));
			_xtUsergroup_FK = (System.Int32) reader[prefix + nameof(xtUsergroup_FK)];
			_htmlfile = reader.ToNullableString (prefix + nameof(htmlfile));
			_xtUsergroup_FKList = reader.ToNullableString (prefix + nameof(xtUsergroup_FKList));

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
