using System;
using System.Collections.Generic;
using System.Text;

namespace MuseeMe.Model
{
    public enum MenuItemTypeEnum
    {
        Home,
        Audios,
        About
    }

    public class MainMenuItem
    {
        public MenuItemTypeEnum MenuItem { get; set; }

        public string Title { get; set; }
    }
}
