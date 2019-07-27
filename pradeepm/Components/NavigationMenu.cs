using Microsoft.AspNetCore.Mvc;
using pradeepm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pradeepm.Components
{
    [ViewComponent(Name = "NavigationMenu")]
    public class NavigationMenu : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(MainMenuItems childrens = null)
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
                            }
                        }
                    },
                    new Menus{
                        lavel="Accounts",
                        menuitems=new List<MainMenuItems>{
                            new MainMenuItems{
                                name="All Accounts",
                                icon="ti-menu",
                                    usertype="admin",
                                Controller="User",
                                Action="Index"
                            },
                            new MainMenuItems{
                                name="Blocked Accounts",
                                icon="ti-menu",
                                    usertype="admin",
                                Controller="User",
                                Action="Index"
                            },
                            new MainMenuItems{
                                name="Unblocked Accounts",
                                icon="ti-menu",
                                    usertype="admin",
                                Controller="User",
                                Action="Index"
                            },
                            new MainMenuItems{
                                name="Account joining",
                                icon="ti-user",
                                Controller="User",
                                Action="joining"
                            },
                            new MainMenuItems{
                                name="Account Tree",
                                icon="ti-menu-alt",
                                Controller="User",
                                Action="tree"
                            },
                            new MainMenuItems{
                                name="Magic Club Requests",
                                icon="ti-ticket",
                                usertype="admin",
                                Controller="MagicClub",
                                Action="Index"
                            }
                        }
                    },
                    new Menus{
                        lavel="Pins",
                        menuitems=new List<MainMenuItems>{
                            new MainMenuItems{
                                name="All Pins",
                                icon="ti-menu",
                                    usertype="admin",
                                Controller="User",
                                Action="Index"
                            },
                            new MainMenuItems{
                                name="Unused Pins",
                                icon="ti-user",
                                Controller="User",
                                Action="joining"
                            },
                            new MainMenuItems{
                                name="Used pins",
                                icon="ti-menu-alt",
                                Controller="User",
                                Action="tree"
                            },
                            new MainMenuItems{
                                name="Genrate pins",
                                icon="ti-ticket",
                                usertype="admin",
                                Controller="MagicClub",
                                Action="Index"
                            }
                        }
                    },
                    new Menus{
                        lavel="Payout",
                        menuitems=new List<MainMenuItems>{
                            new MainMenuItems{
                                name="All Payout",
                                icon="ti-menu",
                                    usertype="admin",
                                Controller="User",
                                Action="Index"
                            },
                            new MainMenuItems{
                                name="User wise income",
                                icon="ti-user",
                                Controller="User",
                                Action="joining"
                            },
                            new MainMenuItems{
                                name="User Payment",
                                icon="ti-menu-alt",
                                Controller="User",
                                Action="tree"
                            }
                        }
                    },
                    new Menus{
                        lavel="Profile",
                        usertype="user",
                        menuitems=new List<MainMenuItems>{
                            new MainMenuItems{
                                name="Show Profile",
                                icon="ti-user",
                                usertype="user",
                                Controller="profile",
                                Action="Index"
                            },
                            new MainMenuItems{
                                name="Update Profile",
                                icon="ti-user",
                                usertype="user",
                                Controller="profile",
                                Action="Index"
                            },
                            new MainMenuItems{
                                name="Upload Profile Pic",
                                icon="ti-user",
                                usertype="user",
                                Controller="profile",
                                Action="Index"
                            }
                        }
                    }
                };

                return menus;
            });
        }


    }
}
