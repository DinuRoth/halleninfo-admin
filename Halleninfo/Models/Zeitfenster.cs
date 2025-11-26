using System.Reflection;
using xTend;

namespace Halleninfo {
    public partial class Zeitfenster {
        public override Permission Permission {
            get {
                if (Database.CurrentUser.IsAdmin()) return Permission.All;
                if (Database.CurrentUser.Usergroups.Contains(xtUsergroup)) return Permission.All;
                if (Database.CurrentUser.Usergroups.Any()) return Permission.Read | Permission.Change | Permission.New;
                return Permission.None;
            }
        }

        public override string? AdditionalSQLFilter {
            get {
                if (Database.CurrentUser.IsAdmin()) return null;
                return $"{nameof(Zeitfenster)}.{nameof(xtUsergroup_FK)} = {Database.CurrentUser.Usergroups.First().xtUsergroup_ID}";
            }
        }

        public override void FilterForeignData(PropertyInfo prop, List<DBO> foreignDBOs) {
            base.FilterForeignData(prop, foreignDBOs);

            if (!Database.CurrentUser.IsAdmin() && prop.Name == nameof(xtUsergroup_FK)) {
                foreignDBOs.Clear();
                foreignDBOs.AddRange(Database.CurrentUser.Usergroups);
            }
        }
        
        public override List<PropertyInfo> EditableProperties {
            get {
                var list = base.ShowProperties;

                if (!Database.CurrentUser.IsAdmin()) {
                    list.RemoveAll(l => l.Name == nameof(Zeitfenster_ID));
                    list.RemoveAll(l => l.Name == nameof(xtUsergroup_FK));
                }

                return list;
            }
        }

        public override void OnCreated() {
            xtUsergroup_FK = Database.CurrentUser.Usergroups.First().xtUsergroup_ID;
            base.OnCreated();
        }
    }
}