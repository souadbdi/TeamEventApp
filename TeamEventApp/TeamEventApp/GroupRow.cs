
using System.Collections.Generic;

namespace TeamEventApp.Droid
{
    public class GroupRow
    {
        // group row such as members, admins, events
        public string Row { get; set; }

        // List of GroupRow items = list of user.
        public List<GroupRowItem> RowItems { get; set; }
    }

    // Represents a group row item (list of user name) within agroup row:
    public class GroupRowItem
    {
        // Name of Group Row item
        public string Name { get; set; }
    }
}