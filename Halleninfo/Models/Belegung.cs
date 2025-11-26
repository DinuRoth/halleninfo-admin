using System.Reflection;
using xTend;

namespace Halleninfo {
    public partial class Belegung {
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
                return $"{nameof(Belegung)}.{nameof(xtUsergroup_FK)} = {Database.CurrentUser.Usergroups.First().xtUsergroup_ID}";
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
                    list.RemoveAll(l => l.Name == nameof(Belegung_ID));
                    list.RemoveAll(l => l.Name == nameof(xtUsergroup_FK));
                }

                return list;
            }
        }

        public override void OnCreated() {
            xtUsergroup_FK = Database.CurrentUser.Usergroups.First().xtUsergroup_ID;
            base.OnCreated();
        }

        public override List<PropertyInfo>? GetIsUnique() {
            List<PropertyInfo>? result = new();
            result.Add(Connector.GetProperty<Belegung>(x => x.Zeitfenster_FK));
            result.Add(Connector.GetProperty<Belegung>(x => x.Raum_FK));
            result.Add(Connector.GetProperty<Belegung>(x => x.Halle_FK));
            result.Add(Connector.GetProperty<Belegung>(x => x.Gruppe_FK));
            result.Add(Connector.GetProperty<Belegung>(x => x.Typ_FK));

            var existing = Database.ReadMultiple<Belegung>(
                $"{nameof(Zeitfenster_FK)} = {Zeitfenster_FK} AND {nameof(Raum_FK)} = {Raum_FK} AND {nameof(Halle_FK)} = {Halle_FK} AND {nameof(Gruppe_FK)} = {Gruppe_FK} AND {nameof(Belegung_ID)} <> {Belegung_ID} AND {nameof(Aktiv)} = 1");
            
            if (existing.Count > 0 && existing.Any(e => e.Typ_FK == Typ_FK)) {
                return result;
            }

            return base.GetIsUnique();
        }
    }
}