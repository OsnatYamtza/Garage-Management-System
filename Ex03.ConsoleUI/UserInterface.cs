using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // $G$ DSN-011 (-5) if we added a new vehical type, this class will be modified.
    public class UserInterface
    {
        private readonly GarageLogic.Garage m_Garage;
        private readonly InputValidation m_InputValidation;

        public UserInterface()
        {
            m_Garage = new GarageLogic.Garage();
            m_InputValidation = new InputValidation();
        }

        public void RunApp()
        {
            bool exitGarage = false;

            while (!exitGarage)
            {
                showMainMenu();
                exitGarage = GetUserChoise();
            }

            Console.WriteLine("Thanks for using our Garage Management! GoogBye..");
        }

        public void CreateNewVehicleInGarge(int i_vehicleType, string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            eVehicleType vehcileType;

            vehcileType = (eVehicleType)Enum.ToObject(typeof(eVehicleType), i_vehicleType);
            switch (vehcileType)
            {
                case eVehicleType.RegularMotorcycle:
                    {
                        CreateRegularMotorcycle(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber);
                        break;
                    }

                case eVehicleType.ElectricMotorcycle:
                    {
                        CreateElectricMotorcycle(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber);
                        break;
                    }

                case eVehicleType.RegularCar:
                    {
                        CreateRegularCar(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber);
                        break;
                    }

                case eVehicleType.ElectricCar:
                    {
                        CreateElectricCar(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber);
                        break;
                    }

                case eVehicleType.Truck:
                    {
                        CreateTruck(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber);
                        break;
                    }
            }
        }

        public void CreateRegularMotorcycle(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string wheelsManufacturer, model;
            int engineDisplacement;
            float wheelsCurrentAirPressure, currentFuelAmount, leftedEnergyPrecent;
            bool isAirPressureValid, isEngineDisplacementValid, isCurrentFuelAmountValid, isleftedEnergyPrecentValid;
            eLicenseType licenseType;
            RegularMotorcycle regularMotorcycle;
            VehicleGenerator vehicleGenerator = new VehicleGenerator();

            Console.Write(@"
Please enter the following parameters for Regular Motorcycle:
        1. Wheels Manufacturer 
        2. Wheels Current Air Pressure
        3. License Type
        4. Engine Displacement
        5. Current Fuel Amount
        6. Model
        7. Lefted Energy Precent
parameters:
");

            wheelsManufacturer = Console.ReadLine();
            isAirPressureValid = float.TryParse(Console.ReadLine(), out wheelsCurrentAirPressure);
            licenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), Console.ReadLine());
            isEngineDisplacementValid = int.TryParse(Console.ReadLine(), out engineDisplacement);
            isCurrentFuelAmountValid = float.TryParse(Console.ReadLine(), out currentFuelAmount);
            model = Console.ReadLine();
            isleftedEnergyPrecentValid = float.TryParse(Console.ReadLine(), out leftedEnergyPrecent);
            if (isAirPressureValid && isEngineDisplacementValid && isCurrentFuelAmountValid && isleftedEnergyPrecentValid)
            {
                regularMotorcycle = vehicleGenerator.CreateRegularMotorcycle(
                    wheelsManufacturer,
                    wheelsCurrentAirPressure,
                    licenseType,
                    engineDisplacement,
                    currentFuelAmount,
                    model,
                    i_LicenseNumber,
                    leftedEnergyPrecent);
                m_Garage.EnterNewVehicle(regularMotorcycle, i_OwnerName, i_OwnerPhoneNumber);
            }
            else
            {
                throw new FormatException("Invalid Input parameters!");
            }
        }

        public void CreateElectricMotorcycle(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string wheelsManufacturer, model;
            int engineDisplacement;
            float wheelsCurrentAirPressure, batteryLeftTime, leftedEnergyPrecent;
            bool isAirPressureValid, isEngineDisplacementValid, isBatteryLeftTimeValid, isleftedEnergyPrecentValid;
            eLicenseType licenseType;
            ElectricMotorcycle electricMotorcycle;
            VehicleGenerator vehicleGenerator = new VehicleGenerator();

            Console.Write(@"
Please enter the following parameters for Electric Motorcycle:
        1. Wheels Manufacturer 
        2. Wheels Current Air Pressure
        3. License Type
        4. Engine Displacement
        5. Battery Left Time
        6. Model
        7. Lefted Energy Precent
parameters:
");

            wheelsManufacturer = Console.ReadLine();
            isAirPressureValid = float.TryParse(Console.ReadLine(), out wheelsCurrentAirPressure);
            licenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), Console.ReadLine());
            isEngineDisplacementValid = int.TryParse(Console.ReadLine(), out engineDisplacement);
            isBatteryLeftTimeValid = float.TryParse(Console.ReadLine(), out batteryLeftTime);
            model = Console.ReadLine();
            isleftedEnergyPrecentValid = float.TryParse(Console.ReadLine(), out leftedEnergyPrecent);
            if (isAirPressureValid && isEngineDisplacementValid && isBatteryLeftTimeValid && isleftedEnergyPrecentValid)
            {
                electricMotorcycle = vehicleGenerator.CreateElectricMotorcycle(
                    wheelsManufacturer,
                    wheelsCurrentAirPressure,
                    licenseType,
                    engineDisplacement,
                    batteryLeftTime,
                    model,
                    i_LicenseNumber,
                    leftedEnergyPrecent);
                m_Garage.EnterNewVehicle(electricMotorcycle, i_OwnerName, i_OwnerPhoneNumber);
            }
            else
            {
                throw new FormatException("Invalid Input parameters!");
            }
        }

        public void CreateRegularCar(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string wheelsManufacturer, model;
            float wheelsCurrentAirPressure, currentFuelAmount, leftedEnergyPrecent;
            bool isAirPressureValid, isCurrentFuelAmountValid, isleftedEnergyPrecentValid;
            eCarColors carColor;
            eCarDoorsNumber doorsNumber;
            RegularCar regularCar;
            VehicleGenerator vehicleGenerator = new VehicleGenerator();

            Console.Write(@"
Please enter the following parameters for Regular Car:
        1. Wheels Manufacturer 
        2. Wheels Current Air Pressure
        3. Car Color
        4. Doors Number
        5. Current Fuel Amount
        6. Model
        7. Lefted Energy Precent
parameters:
");

            wheelsManufacturer = Console.ReadLine();
            isAirPressureValid = float.TryParse(Console.ReadLine(), out wheelsCurrentAirPressure);
            carColor = (eCarColors)Enum.Parse(typeof(eCarColors), Console.ReadLine());
            doorsNumber = (eCarDoorsNumber)Enum.Parse(typeof(eCarDoorsNumber), Console.ReadLine());
            isCurrentFuelAmountValid = float.TryParse(Console.ReadLine(), out currentFuelAmount);
            model = Console.ReadLine();
            isleftedEnergyPrecentValid = float.TryParse(Console.ReadLine(), out leftedEnergyPrecent);
            if (isAirPressureValid && isCurrentFuelAmountValid && isleftedEnergyPrecentValid)
            {
                regularCar = vehicleGenerator.CreateRegularCar(
                    wheelsManufacturer,
                    wheelsCurrentAirPressure,
                    carColor,
                    doorsNumber,
                    currentFuelAmount,
                    model,
                    i_LicenseNumber,
                    leftedEnergyPrecent);
                m_Garage.EnterNewVehicle(regularCar, i_OwnerName, i_OwnerPhoneNumber);
            }
            else
            {
                throw new FormatException("Invalid Input parameters!");
            }
        }

        public void CreateElectricCar(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string wheelsManufacturer, model;
            float wheelsCurrentAirPressure, batteryLeftTime, leftedEnergyPrecent;
            bool isAirPressureValid, isBatteryLeftTimeValid, isleftedEnergyPrecentValid;
            eCarColors carColor;
            eCarDoorsNumber doorsNumber;
            ElectricCar electricCar;
            VehicleGenerator vehicleGenerator = new VehicleGenerator();

            Console.Write(@"
Please enter the following parameters for Electric Car:
        1. Wheels Manufacturer 
        2. Wheels Current Air Pressure
        3. Car Color
        4. Doors Number
        5. Battery Left Time
        6. Model
        7. Lefted Energy Precent
parameters:
");

            wheelsManufacturer = Console.ReadLine();
            isAirPressureValid = float.TryParse(Console.ReadLine(), out wheelsCurrentAirPressure);
            carColor = (eCarColors)Enum.Parse(typeof(eCarColors), Console.ReadLine());
            doorsNumber = (eCarDoorsNumber)Enum.Parse(typeof(eCarDoorsNumber), Console.ReadLine());
            isBatteryLeftTimeValid = float.TryParse(Console.ReadLine(), out batteryLeftTime);
            model = Console.ReadLine();
            isleftedEnergyPrecentValid = float.TryParse(Console.ReadLine(), out leftedEnergyPrecent);
            if (isAirPressureValid && isBatteryLeftTimeValid && isleftedEnergyPrecentValid)
            {
                electricCar = vehicleGenerator.CreateElectricCar(
                    wheelsManufacturer,
                    wheelsCurrentAirPressure,
                    carColor,
                    doorsNumber,
                    batteryLeftTime,
                    model,
                    i_LicenseNumber,
                    leftedEnergyPrecent);
                m_Garage.EnterNewVehicle(electricCar, i_OwnerName, i_OwnerPhoneNumber);
            }
            else
            {
                throw new FormatException("Invalid Input parameters!");
            }
        }

        public void CreateTruck(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string wheelsManufacturer, model;
            float wheelsCurrentAirPressure, currentFuelAmount, leftedEnergyPrecent, cargoCapacity;
            bool isAirPressureValid, isCurrentFuelAmountValid, isleftedEnergyPrecentValid, isCargoCapacityValid, isTransportingRefrigeratedIngredientAnswer, isTransportingRefrigeratedIngredient = false;
            Truck truck;
            VehicleGenerator vehicleGenerator = new VehicleGenerator();

            Console.Write(@"
Please enter the following parameters for Truck:
        1. Wheels Manufacturer 
        2. Wheels Current Air Pressure
        3. Is the truck Transporting Refrigerated Ingredient (enter Y / N)
        4. cargo Capacity
        5. Current Fuel Amount
        6. Model
        7. Lefted Energy Precent
parameters:
");

            wheelsManufacturer = Console.ReadLine();
            isAirPressureValid = float.TryParse(Console.ReadLine(), out wheelsCurrentAirPressure);
            isTransportingRefrigeratedIngredientAnswer = m_InputValidation.ConvertStringToBool(Console.ReadLine());
            isCargoCapacityValid = float.TryParse(Console.ReadLine(), out cargoCapacity);
            isCurrentFuelAmountValid = float.TryParse(Console.ReadLine(), out currentFuelAmount);
            model = Console.ReadLine();
            isleftedEnergyPrecentValid = float.TryParse(Console.ReadLine(), out leftedEnergyPrecent);
            if (isAirPressureValid && isCargoCapacityValid && isCurrentFuelAmountValid && isleftedEnergyPrecentValid)
            {
                truck = vehicleGenerator.CreateTruck(
                    wheelsManufacturer,
                    wheelsCurrentAirPressure,
                    isTransportingRefrigeratedIngredient,
                    cargoCapacity,
                    currentFuelAmount,
                    model,
                    i_LicenseNumber,
                    leftedEnergyPrecent);
                m_Garage.EnterNewVehicle(truck, i_OwnerName, i_OwnerPhoneNumber);
            }
            else
            {
                throw new FormatException("Invalid Input parameters!");
            }
        }

        public void fillAirPressureToMax()
        {
            string licenseNumber;

            licenseNumber = getLicenseNumber();
            m_Garage.FillAirPressureToMax(licenseNumber);
            Console.WriteLine(string.Format("Wheels in vehicle with license number {0} were filled", licenseNumber));
        }

        public void refuelVehicle()
        {
            string licenseNumber, fuelType;
            float fuelAmount;
            bool isValidInput;

            licenseNumber = getLicenseNumber();
            Console.Write(@"Please enter vehicle's fuel type: 
        1. Octan98
        2. Octan96
        3. Octan95
        4. Soler             
Your choice: ");
            fuelType = Console.ReadLine();
            Console.Write("Please enter amount of fuel to add: ");
            isValidInput = float.TryParse(Console.ReadLine(), out fuelAmount);
            if (isValidInput)
            {
                m_Garage.AddFuelToVehicle(licenseNumber, fuelAmount, fuelType);
            }
            else
            {
                throw new FormatException("Invalid Input parameters!");
            }

            Console.WriteLine(string.Format("Vehcile with license number {0} was refueled", licenseNumber));
        }

        public void chargeBatteryVehicle()
        {
            string licenseNumber;
            int minToCharge;
            bool isValidInput;

            licenseNumber = getLicenseNumber();
            Console.Write("Please enter num of minutes to charge: ");
            isValidInput = int.TryParse(Console.ReadLine(), out minToCharge);
            if (isValidInput)
            {
                m_Garage.ChargeBatteryCharge(licenseNumber, minToCharge);
            }
            else
            {
                throw new FormatException("Invalid Input parameters!");
            }

            Console.WriteLine(string.Format("Vehcile with license number {0} was charged", licenseNumber));
        }

        public void printVehicleDetails()
        {
            string licenseNumber;

            licenseNumber = getLicenseNumber();
            Console.WriteLine(m_Garage.GetVehicleDetails(licenseNumber));
        }

        private void showMainMenu()
        {
            Console.Write(@"
Welcome to our Garage.
Please choose an option:
        1. Enter a vehicle to the garage 
        2. Show vehicles' License numbers in garage
        3. Change vehicle status
        4. Fill air pressure to Max
        5. Refuel vehicle
        6. Charge Battert vehicle
        7. Show vehicle's data
        8. Exit
Your choice: ");
        }

        private bool GetUserChoise()
        {
            bool exit = false;
            string userInput;
            eUserChoice userChoise;

            try
            {
                userInput = Console.ReadLine();
                userChoise = (eUserChoice)Enum.Parse(typeof(eUserChoice), userInput);

                switch (userChoise)
                {
                    case eUserChoice.One:
                        addVehicleToGarage();
                        break;
                    case eUserChoice.Two:
                        showVehicleInGarage();
                        break;
                    case eUserChoice.Three:
                        changeVehicleStatus();
                        break;
                    case eUserChoice.Four:
                        fillAirPressureToMax();
                        break;
                    case eUserChoice.Five:
                        refuelVehicle();
                        break;
                    case eUserChoice.Six:
                        chargeBatteryVehicle();
                        break;
                    case eUserChoice.Seven:
                        printVehicleDetails();
                        break;
                    case eUserChoice.Eight:
                        exit = true;
                        break;
                    default:
                        Console.Write("Invalid choice - {0}, please try again.{1}Your choice: ", userInput, Environment.NewLine);
                        GetUserChoise();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return exit;
        }

        // $G$ SFN-002 (-5) How the user can know what types of vehicles there are? and what he choose?
        private void addVehicleToGarage()
        {
            bool vehicleInGarage, validInput;
            string licenseNumber, vehicleTypeInput, ownerName, ownerPhoneNumber;
            int vehicleType;

            Console.WriteLine("Please enter the license number:");
            licenseNumber = Console.ReadLine();
            m_InputValidation.ValidateNumber(licenseNumber);
            vehicleInGarage = m_Garage.VehicleIsExistInGarage(licenseNumber);
            if (!vehicleInGarage)
            {
                Console.WriteLine("Please enter the owner name, owner phone number and vehicle type:");
                ownerName = Console.ReadLine();
                m_InputValidation.ValidateString(ownerName);
                ownerPhoneNumber = Console.ReadLine();
                m_InputValidation.ValidateNumber(ownerPhoneNumber);
                vehicleTypeInput = Console.ReadLine();
                validInput = int.TryParse(vehicleTypeInput, out vehicleType);
                if (!validInput)
                {
                    throw new FormatException("Invalid Vehicle type!");
                }
                else
                {
                    CreateNewVehicleInGarge(vehicleType, licenseNumber, ownerName, ownerPhoneNumber);
                }
            }
            else
            {
                Console.WriteLine("The Vehicle is already in the Garage. Vehicle status was change to 'In Repair'");
            }
        }

        private void showVehicleInGarage()
        {
            bool showAllVehicles;

            Console.Write("Do you want to see all garage vehicles? (Y / N): ");
            showAllVehicles = m_InputValidation.ConvertStringToBool(Console.ReadLine());

            if (showAllVehicles)
            {
                showAllVehicleInGarage();
            }
            else
            {
                showVehicleInGarageByStatus();
            }
        }

        private void showAllVehicleInGarage()
        {
            StringBuilder listToPrint = new StringBuilder();

            List<string> garageVehicles = m_Garage.GetAllVehiclesInGarage();

            if (garageVehicles.Count != 0)
            {
                listToPrint.AppendLine("Vehicles' License number in the Garage: ");
                foreach (string vehicleLicenseNum in garageVehicles)
                {
                    listToPrint.AppendLine(vehicleLicenseNum);
                }
            }
            else
            {
                listToPrint.AppendLine("There are no vehicle in the garage.");
            }

            Console.WriteLine(listToPrint);
        }

        private void showVehicleInGarageByStatus()
        {
            StringBuilder listToPrint = new StringBuilder();
            string status;

            Console.Write(
                    @"Please enter the requested status:
        1. InRepair
        2. Paid
        3. Done
Your choice: ");
            status = Console.ReadLine();
            List<string> filteredVehicleList = m_Garage.GetVehiclesInGarageByStatus(status);
            eVehicleStatus vehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), status);

            if (filteredVehicleList.Count != 0)
            {
                listToPrint.AppendLine(string.Format("Vehicles' License number with status {0}", vehicleStatus.ToString()));
                foreach (string vehicleLicenseNum in filteredVehicleList)
                {
                    listToPrint.AppendLine(vehicleLicenseNum);
                }
            }
            else
            {
                listToPrint.AppendLine(string.Format("There are no vehicle with status {0} in the garage.", vehicleStatus.ToString()));
            }

            Console.WriteLine(listToPrint);
        }

        private void changeVehicleStatus()
        {
            string licenseNumber, newStatus;

            licenseNumber = getLicenseNumber();
            Console.Write(
                    @"Please enter new status:
        1. InRepair
        2. Paid
        3. Done
Your choice: ");
            newStatus = Console.ReadLine();
            m_Garage.ChangeVehicleStatus(licenseNumber, newStatus);
            Console.WriteLine("Vehicle status was changed!");
        }

        private string getLicenseNumber()
        {
            string licenseNumber;

            Console.Write("Please enter the vehicle's license number: ");
            licenseNumber = Console.ReadLine();

            m_InputValidation.ValidateNumber(licenseNumber);
            return licenseNumber;
        }
    }
}
