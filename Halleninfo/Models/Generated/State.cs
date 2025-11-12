
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Halleninfo {
    public partial class State: DBO {
        [Obsolete ("This constructor is for internal use only. Use DBO(IUserDB db) instead.")]
        public State () : base() { }
        public State (IUserDB db) : base (db) { }

		private System.Int32 _xtUsergroup_FK;
		private System.Int32 _Hallenstatus_FK;


        [Column]
        [Key]
		public Int32 State_ID { get; set; }
        public override Int32 Id {
            get { return State_ID; }
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
		[ForeignKey ("Hallenstatus")]
		public System.Int32 Hallenstatus_FK {
            get { return _Hallenstatus_FK; }
            set {
                if (value != _Hallenstatus_FK) {
                    var oldVal = _Hallenstatus_FK;
                    _Hallenstatus_FK = value;
                _Hallenstatus = null; // reset the foreign DBO
                    OnFieldChanged(nameof(Hallenstatus_FK), oldVal, value);
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
		public Hallenstatus? _Hallenstatus;
       [GUIType(GUIType.Enum.Hidden)]
        [JsonIgnore]
        public Hallenstatus? Hallenstatus {
            get {
                if (_Hallenstatus == null) {
                    _Hallenstatus = Database.Read<Hallenstatus> (Hallenstatus_FK);
                }
                return _Hallenstatus;
            }
            set {
                Hallenstatus_FK = value.Id;
                _Hallenstatus = value;

            }
        }



        public override void SetData(SqlDataReader reader, string prefix="") {
    base.SetData (reader, prefix);
			State_ID = (int)reader[prefix + nameof (State_ID)];
			_xtUsergroup_FK = (System.Int32) reader[prefix + nameof(xtUsergroup_FK)];
			_Hallenstatus_FK = (System.Int32) reader[prefix + nameof(Hallenstatus_FK)];

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
