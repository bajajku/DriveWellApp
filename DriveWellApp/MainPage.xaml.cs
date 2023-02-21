using DriveWellApp.BusinessLogic;

namespace DriveWellApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void OnAddCarClicked(object sender, EventArgs e)
    {
		string vin = EntVin.Text;
		string carMake = EntCarMake.Text;
		string type = SelectCarType.SelectedItem.ToString();
		CarType carType = (CarType)Enum.Parse(typeof(CarType),type);
		float price = float.Parse(EntPrice.Text);
		int modelYear = int.Parse(SelectModelYear.SelectedItem.ToString());
		CarInventory inventory = new CarInventory();
		if (ClickBox.IsChecked)
		{
			int kilometer = int.Parse(EntDistanceKm.Text);
			UsedCar car = new UsedCar(kilometer, vin, carMake, carType, price, modelYear);
			inventory.AddCar(car);
		}
		else
		{
			EntDistanceKm.IsReadOnly = true;
			Car car = new Car(vin,carMake, carType, price, modelYear);
			inventory.AddCar(car);
		}
		DisplayAlert("notification", "Car added", "OK");
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
		EntVin.Text = null;
		EntDistanceKm.Text = null;
		EntCarMake.Text = null;
		EntPrice.Text = null;
		SelectCarType.SelectedItem = null;
		SelectModelYear.SelectedItem = null;
	}
}


