using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console.Repository
{
    public class MenuRepo
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>();
        public bool AddMenuToDirectory(Menu menu)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(menu);
            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Menu> GetMenu()
        {
            return _menuDirectory;
        }
        public Menu GetMenuByName(string name)
        {
            foreach (Menu menu in _menuDirectory)
            {
                if (menu.Name.ToLower() == name.ToLower())
                {
                    return menu;
                }
            }
            return null;
        }
        public Menu GetMenuByNumber(int number)
        {
            foreach (Menu menu in _menuDirectory)
            {
                if (menu.Number == number)
                {
                    return menu;
                }
            }
            return null;
        }
        public bool UpdateExistingMenu(string originalProfile, Menu menu)
        {
            Menu oldProfile = GetMenuByName(originalProfile);

            if (oldProfile != null)
            {
                oldProfile.Description = menu.Description;
                oldProfile.Name = menu.Name;

                return true;
            }
            else
                return false;
        }
        public bool DeleteExistingMenu(Menu existingMenu)
        {
            bool deleteMenu = _menuDirectory.Remove(existingMenu);
            return deleteMenu;
        }
        internal bool Remove(Menu menu)
        {
            bool deleteMenu = _menuDirectory.Remove(menu);
            return deleteMenu;
        }
    }
}
