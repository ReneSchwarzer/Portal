﻿using Cocpit.Model;
using WebExpress.Html;
using WebExpress.Pages;
using WebExpress.UI.Controls;
using WebExpress.UI.Pages;

namespace Cocpit.Pages
{
    public class PageBase : PageTemplateWebApp
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="title">Der Titel der Seite</param>
        public PageBase(string title)
            : base()
        {
            Title = "Cocpit";

            if (!string.IsNullOrWhiteSpace(title))
            {
                Title += " - " + title;
            }

            Favicons.Add(new Favicon("/Assets/img/Favicon.png", TypesFavicon.PNG));
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public override void Init()
        {
            base.Init();

            Head.Content.Add(HamburgerMenu);

            HamburgerMenu.HorizontalAlignment = TypesHorizontalAlignment.Left;
            HamburgerMenu.Image = GetPath(0, "Assets/img/Logo.png");
            HamburgerMenu.Add(new ControlLink(this) { Text = "Home", Icon = Icon.Home, Url = GetPath(0) });
            HamburgerMenu.AddSeperator();
            HamburgerMenu.Add(new ControlLink(this) { Text = "Logging", Icon = Icon.Book, Url = GetPath(0, "log") });
            HamburgerMenu.Add(new ControlLink(this) { Text = "Einstellungen", Icon = Icon.Cog, Url = GetPath(0, "settings") });
            HamburgerMenu.AddSeperator();
            HamburgerMenu.Add(new ControlLink(this) { Text = "Hilfe", Icon = Icon.InfoCircle, Url = GetPath(0, "help") });

            // SideBar
            ToolBar = new ControlToolBar(this)
            {
                Class = "sidebar bg-success",
                HorizontalAlignment = TypesHorizontalAlignment.Left
            };

            ToolBar.Add(new ControlLink(this) { Url = GetPath(0), Icon =  Icon.TachometerAlt, Class = "active", Tooltip = "Zentrale" }); // Home
            foreach(var webSite in ViewModel.Instance.Settings.WebSites)
            {
                ToolBar.Add(new ControlLink(this) { Url = new Path(null, webSite.Url), Icon = Icon.Sun, Tooltip = webSite.Name }); 
            }

            

            Head.Content.Add(new ControlPanelCenter(this, new ControlText(this)
            {
                Text = Title,
                Color = TypesTextColor.White,
                Format = TypesTextFormat.H1,
                Size = TypesSize.Default,
                Class = "p-1 mb-0",
                Style = "font-size:190%; height: 50px;"
            }));

            Main.Class = "pl-3 pr-3 content";
            PathCtrl.Class = "content";


            Foot.Content.Add(new ControlText(this, "now")
            {
                Text = string.Format("{0}", ViewModel.Instance.Now),
                Color = TypesTextColor.Muted,
                Format = TypesTextFormat.Center,
                Size = TypesSize.Small
            });
        }

        /// <summary>
        /// Verarbeitung
        /// </summary>
        public override void Process()
        {
            base.Process();
        }
    }
}
