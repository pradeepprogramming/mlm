using Microsoft.AspNetCore.Mvc;
using pradeepm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Components
{
    [ViewComponent(Name = "NavigationMenu")]
    public class NavigationMenu : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(ChildrenItems childrens = null)
        {
            if (childrens == null)
            {
                var menu = await getMenusAsync();
                return View("MainMenu", menu);
            }
            else
            {
                return View("SubMenu", childrens);
            }
        }
        public Task<IEnumerable<Menus>> getMenusAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                IEnumerable<Menus> menus = new List<Menus>(){
                    new Menus{
                        lavel="Navigations",
                        menuitems=new List<MainMenuItems>{
                            new MainMenuItems{
                                name="Dashboard",
                                icon="ti-view-grid",
                                Controller="Dashboard",
                                Action="Index"
                            },
                            new MainMenuItems{
                                name="Master",
                                icon="ti-settings",
                                usertype="admin"
                            },
                            new MainMenuItems{
                                name="Products",
                                icon="ti-home",
                                usertype="admin"
                            },
                            new MainMenuItems{
                                name="Accounts",
                                icon="ti-user",
                                childrens=new List<ChildrenItems>{
                                    new ChildrenItems{
                                        name="All Accounts",
                                        icon="ti-menu",
                                         usertype="admin",
                                        Controller="User",
                                        Action="Index"
                                    },
                                    new ChildrenItems{
                                        name="Account joining",
                                        icon="ti-user",
                                        Controller="User",
                                        Action="joining"
                                    },
                                    new ChildrenItems{
                                        name="Account Tree",
                                        icon="ti-menu-alt",
                                        Controller="User",
                                        Action="tree"
                                    },
                                    new ChildrenItems{
                                        name="Magic Club Requests",
                                        icon="ti-ticket",
                                        usertype="admin",
                                        Controller="MagicClub",
                                        Action="Index"
                                    }
                                }
                            },
                            new MainMenuItems{
                                name="Profile",
                                icon="ti-id-badge",
                                usertype="user"
                            }
                        }
                    }
                };
                return menus;
            });
        }


    }
}
