using Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageXaml : ContentPage
    {
        List<string> lstData { get; set; } = new List<string>();
        public PageXaml()
        {
            try
            {
                InitializeComponent();

                #region Import Data
                for (int i = 1; i <= 100; i++)
                {
                    lstData.Add(i.ToString());
                }
                lsvData.ItemsSource = lstData;
                #endregion
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        /// <summary>
        /// SwipeLeft to Show DeleteButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridTemplate_SwipeLeft(object sender, EventArgs e)
        {
            try
            {
                if (sender is SwipeGestureGrid)
                {
                    var templateGrid = ((SwipeGestureGrid)sender).Parent;
                    if (templateGrid != null && templateGrid is Grid)
                    {
                        var CellTemplateGrid = (Grid)templateGrid;
                        CellTemplateGrid.ColumnDefinitions[1].Width = new GridLength(60, GridUnitType.Absolute);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// SwipeRight to Hide DeleteButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridTemplate_SwipeRight(object sender, EventArgs e)
        {
            try
            {
                if (sender is SwipeGestureGrid)
                {
                    var templateGrid = ((SwipeGestureGrid)sender).Parent;
                    if (templateGrid != null && templateGrid is Grid)
                    {
                        var CellTemplateGrid = (Grid)templateGrid;
                        CellTemplateGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// DeleteButton Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCellDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (sender is ImageButton)
                {
                    var templateGrid = ((ImageButton)sender);
                    //templateGrid.Parent = gridBase
                    //templateGrid.Parent.Parent = cell
                    if (templateGrid.Parent != null && templateGrid.Parent.Parent != null && templateGrid.Parent.Parent.BindingContext != null && templateGrid.Parent.Parent.BindingContext is string)
                    {
                        var deletedate = templateGrid.Parent.Parent.BindingContext as string;
                        lstData.RemoveAll(f => f == deletedate);
                        lsvData.ItemsSource = null;
                        lsvData.ItemsSource = lstData;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GridTemplate_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (sender is SwipeGestureGrid)
                {
                    var templateGrid = ((SwipeGestureGrid)sender);
                    if (templateGrid.Parent != null && templateGrid.Parent.Parent != null && templateGrid.Parent.Parent.BindingContext != null && templateGrid.Parent.Parent.BindingContext is string)
                    {
                        Debug.WriteLine(templateGrid.Parent.Parent.BindingContext.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}