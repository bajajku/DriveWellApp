using DriveWellApp.BusinessLogic;

namespace DriveWellApp;

public partial class MainPage : ContentPage
{
	string carDetails = "";
	float netPrice = 0;
	public MainPage()
	{
		InitializeComponent();
	
	}

    private void OnAddCarClicked(object sender, EventArgs e)
    {
		string vin = EntVin.Text;
		string carMake = EntCarMake.Text;
		string type = SelectCarType.SelectedItem.ToString();
		if(type == "SUV")
		{
			CarImage.Source = "suv.png";
		}else if(type == "Coupe")
		{
			CarImage.Source = "coupe.png";

        }
        else if (type == "Sedan")
        {
            CarImage.Source = "sedan.png";

        }
        else if (type == "HatchBack")
        {
            CarImage.Source = "hatchback.png";

        }
        CarType carType = (CarType)Enum.Parse(typeof(CarType),type);
		float price = float.Parse(EntPrice.Text);
		int modelYear = int.Parse(SelectModelYear.SelectedItem.ToString());
		CarInventory inventory = new CarInventory();
		if (ClickBox.IsChecked)
		{
			int kilometer = int.Parse(EntDistanceKm.Text);
			UsedCar car = new UsedCar(kilometer, vin, carMake, carType, price, modelYear);
			inventory.AddCar(car);
			netPrice = car.NetPrice;
			carDetails = $"Used car - Vin: {vin} Car Make: {carMake} Car Type: {type} Net Price: {netPrice} ";
		}
		else
		{
			Car car = new Car(vin,carMake, carType, price, modelYear);
			netPrice = car.NetPrice;
			inventory.AddCar(car);
            carDetails = $"Vin: {vin} Car Make: {carMake} Car Type: {type} Net Price: {netPrice} ";
        }
		DisplayAlert("Car Added",$"Car Type:{type}\nModel Year:{modelYear}", "OK");
		if (Car1.Text == "Car1 Details Here")
		{
			Car1.Text = carDetails;
		}else if(Car1.Text != "Car1 Details Here" && Car2.Text == "Car2 Details Here")
		{
			Car2.Text = carDetails;
		}else if(Car2.Text != "Car2 Details Here" && Car3.Text == "Car3 Details Here")
		{
			Car3.Text = carDetails;
		}
		else
		{
			Car4.Text = carDetails;
		}
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
		EntVin.Text = null;
		EntDistanceKm.Text = null;
		EntCarMake.Text = null;
		EntPrice.Text = null;
		SelectCarType.SelectedItem = null;
		SelectModelYear.SelectedItem = null;
		ClickBox.IsChecked = false;
	}
}


