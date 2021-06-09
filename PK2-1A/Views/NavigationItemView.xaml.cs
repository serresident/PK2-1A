﻿using PK2_1A.ViewModels;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PK2_1A.Views
{
    /// <summary>
    /// Interaction logic for NavigationItemView.xaml
    /// </summary>
    public partial class NavigationItemView : UserControl
    {
        private Uri navViewUri, toolViewUri;
        private IRegionManager regionManager;
        public NavigationItemView(IRegionManager regionManager, string uri, string toolUri, string caption)
        {
            InitializeComponent();

            this.regionManager = regionManager;
            this.navViewUri = new Uri(uri, UriKind.Relative);
            this.toolViewUri = new Uri(toolUri, UriKind.Relative);
            NavigateRadioButton.Content = caption;

            IRegion mainContentRegion = this.regionManager.Regions["ContentRegion"];
            if (mainContentRegion != null && mainContentRegion.NavigationService != null)
            {
                mainContentRegion.NavigationService.Navigated += this.MainContentRegion_Navigated;
            }

        }

        public void MainContentRegion_Navigated(object sender, RegionNavigationEventArgs e)
        {
            this.UpdateNavigationButtonState(e.Uri);
        }

        private void UpdateNavigationButtonState(Uri uri)
        {
            this.NavigateRadioButton.IsChecked = (uri == navViewUri);
            if (uri == navViewUri)
            {
                var shellWindows = FindParentWindow(this);
                (shellWindows.DataContext as ShellViewModel).Title = " [ " + NavigateRadioButton.Content + " ] ";
                regionManager.RequestNavigate("ToolRegion", toolViewUri);
            }

        }


        private void NavigateTo_Click(object sender, RoutedEventArgs e)
        {
            regionManager.RequestNavigate("ContentRegion", navViewUri);
        }

        public static Window FindParentWindow(DependencyObject child)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            //CHeck if this is the end of the tree
            if (parent == null) return null;

            Window parentWindow = parent as Window;
            if (parentWindow != null)
            {
                return parentWindow;
            }
            else
            {
                //use recursion until it reaches a Window
                return FindParentWindow(parent);
            }
        }


    }

}
