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
using System.Windows.Shapes;
using TBQuestGame.PresentationLayer;
using WageSlave.Models;
using WageSlave.Models.GameObjects;
using WageSlave.PresentationLayer;
using static TBQuestGame.PresentationLayer.GameSessionView;

namespace WageSlave.PresentationLayer
{
    /// <summary>
    /// Interaction logic for ItemDetailsView.xaml
    /// </summary>
    public partial class ItemDetailsView : Window
    {
        public ItemDetailsView(GameSessionViewModel gameSessionViewModel, AssetTypes selectedAssetType, bool isLocationItem)
        {
            GameItem gameItem = new GameItem();

            if (isLocationItem)
            {
                gameItem = gameSessionViewModel.CurrentLocationGameItem;
            }
            else
            {
                gameItem = gameSessionViewModel.CurrentGameItem;
            }


            InitializeComponent();

            Label_ItemDetailView_Item_Name.Content = gameItem.Name + " Details";

            // Creates a list of Item Detail View's Grids (that contain different info boxes, depending on Item Type)
            List<Grid> itemDetailsViewGrids = new List<Grid> { Grid_ItemDetailView_Business, Grid_ItemDetailView_OtherItem, Grid_ItemDetailView_RealEstate, Grid_ItemDetailView_Stocks, Grid_ItemDetailView_Vehicles };

            // Makes all grids hidden, initially
            foreach (Grid grid in itemDetailsViewGrids)
            {
                grid.Visibility = Visibility.Hidden;
            }

            // Shows appropriate grid and assigns textboxes
            switch (selectedAssetType)
            {
                case AssetTypes.Businesses:
                    //Allows Business Properties to be accessed
                    Business business = (Business)gameItem;

                    Grid_ItemDetailView_Business.Visibility = Visibility.Visible; // Makes grid visible

                    //Assigns textboxes appropriate Item values
                    TextBox_ItemDetailView_Business_Industry.Text = business.Industry;
                    TextBox_ItemDetailView_Business_YearsInBusiness.Text = business.YearsInBusiness.ToString();
                    TextBox_ItemDetailView_Business_NetIncome.Text = business.NetIncome.ToString();
                    TextBox_ItemDetailView_Business_GrowthRate.Text = business.GrowthRate.ToString();
                    TextBox_ItemDetailView_Business_Price.Text = business.Price.ToString();
                    TextBox_ItemDetailView_Business_Value.Text = business.Value.ToString();

                    break;

                case AssetTypes.OtherItems:
                    Grid_ItemDetailView_OtherItem.Visibility = Visibility.Visible;
                    break;

                case AssetTypes.RealEstate:
                    RealEstate realEastate = (RealEstate)gameItem;

                    Grid_ItemDetailView_RealEstate.Visibility = Visibility.Visible; // Makes grid visible

                    //Assigns textboxes appropriate Item values
                    TextBox_ItemDetailView_RealEstate_Bedrooms.Text = realEastate.Bedrooms.ToString();
                    TextBox_ItemDetailView_RealEstate_Bathrooms.Text = realEastate.Bathrooms.ToString();
                    TextBox_ItemDetailView_RealEstate_YearBuilt.Text = realEastate.YearBuilt.ToString();
                    TextBox_ItemDetailView_RealEstate_SqFootage.Text = realEastate.SqFootage.ToString();
                    TextBox_ItemDetailView_RealEstate_Condition.Text = realEastate.condition.ToString();
                    TextBox_ItemDetailView_RealEstate_RentPrice.Text = realEastate.RentPrice.ToString();
                    TextBox_ItemDetailView_RealEstate_Appreciation.Text = ((realEastate.AppreciationMax + realEastate.AppreciationMin) / 2).ToString();
                    TextBox_ItemDetailView_RealEstate_FamiliesAllowed.Text = realEastate.FamiliesAllowed.ToString();
                    TextBox_ItemDetailView_RealEstate_MilesFromTown.Text = realEastate.MilesFromTown.ToString();
                    TextBox_ItemDetailView_RealEstate_HappinessImpact.Text = realEastate.HappinessFactor.ToString();
                    TextBox_ItemDetailView_RealEstate_Price.Text = realEastate.Price.ToString();
                    TextBox_ItemDetailView_RealEstate_Value.Text = realEastate.Value.ToString();
                    TextBox_ItemDetailView_RealEstate_Description.Text = realEastate.Description;

                    break;

                case AssetTypes.Stocks:
                    Grid_ItemDetailView_Stocks.Visibility = Visibility.Visible;
                    break;
                case AssetTypes.Vehicles:
                    Grid_ItemDetailView_Vehicles.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
    }
}
