using Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Pages
{
    public class Pages : ContentPage
    {
        ListView lsvData = new ListView()
        {
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.White,
            HasUnevenRows = true,
        };
        List<string> lstData = new List<string>();
        public Pages()
        {
            #region DataTemplate
            DataTemplate ListDataTemplate = new DataTemplate(() =>
            {
                #region DataArea of Template
                SwipeGestureGrid gridData = new SwipeGestureGrid()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 60,
                    RowDefinitions =
                        {
                            new RowDefinition { },
                        },
                    ColumnDefinitions =
                        {
                            new ColumnDefinition { },
                        }
                };
                #endregion
                #region Base of Template
                Grid gridBase = new Grid()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 60,
                    RowDefinitions =
                    {
                        new RowDefinition { },
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { },                                                   //Put Cells Data here
                        new ColumnDefinition { Width = new GridLength(0, GridUnitType.Absolute)},   //Button for Cells here
                    },
                };
                #endregion
                Label lblText = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    FontAttributes = FontAttributes.Bold,
                    VerticalTextAlignment = TextAlignment.End,
                    TextColor = Color.Black,
                    BackgroundColor = Color.Silver,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    FontSize = 18,
                };
                lblText.SetBinding(Label.TextProperty, ".");

                ImageButton btnCellDelete = new ImageButton() { Source = "Delete" };

                gridData.Children.Add(lblText, 0, 0);

                gridBase.Children.Add(gridData, 0, 0);
                gridBase.Children.Add(btnCellDelete, 1, 0);

                gridData.SwipeLeft += GridTemplate_SwipeLeft;
                gridData.SwipeRight += GridTemplate_SwipeRight; ;
                gridData.Tapped += GridTemplate_Tapped; ;
                btnCellDelete.Clicked += BtnCellDelete_Clicked; ;

                return new ViewCell
                {
                    View = gridBase,
                    Height = 60,
                };
            });

            #endregion
            for (int i = 1; i <= 100; i++)
            {
                lstData.Add(i.ToString());
            }
            lsvData.ItemTemplate = ListDataTemplate;
            lsvData.ItemsSource = lstData;
            Content = lsvData;
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
