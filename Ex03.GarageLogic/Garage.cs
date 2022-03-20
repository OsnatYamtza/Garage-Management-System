using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehiclesInGarage> m_VehicleInGarageDict;

        public Garage()
        {
            m_VehicleInGarageDict = new Dictionary<string, VehiclesInGarage>();
        }

        public Dictionary<string, VehiclesInGarage> VehiclesInGarageDict
        {
            get
            {
                return m_VehicleInGarageDict;
            }

            set
            {
                m_VehicleInGarageDict = value;
            }
        }

        public void EnterNewVehicle(Vehicle i_VehicleInGarage, string i_VehicleOwner, string i_VehicleOwnerPhone)
        {
            VehiclesInGarage VehicleInGarage = new VehiclesInGarage(i_VehicleInGarage, i_VehicleOwner, i_VehicleOwnerPhone, eVehicleStatus.InRepair);
            if (!m_VehicleInGarageDict.ContainsKey(VehicleInGarage.Vehicle.LicenseNumber))
            {
                m_VehicleInGarageDict.Add(VehicleInGarage.Vehicle.LicenseNumber, VehicleInGarage);
            }
            else
            {
                throw new ArgumentException(string.Format("The vehicle with the license number {0} is already in the garage!", VehicleInGarage.Vehicle.LicenseNumber));
            }
        }

        public List<string> GetAllVehiclesInGarage()
        {
            List<string> vehiclesInGarageList = new List<string>();

            foreach (string licenseNumber in m_VehicleInGarageDict.Keys)
            {
                vehiclesInGarageList.Add(licenseNumber);
            }

            return vehiclesInGarageList;
        }

        public List<string> GetVehiclesInGarageByStatus(string i_VehiclesStatusToShow)
        {
            List<string> filteredVehiclesInGarageList = new List<string>();
            eVehicleStatus statusToShow;

            statusToShow = InputValidation<eVehicleStatus>(i_VehiclesStatusToShow);

            foreach (string licenseNumber in m_VehicleInGarageDict.Keys)
            {
                if (statusToShow == m_VehicleInGarageDict[licenseNumber].VehicleStatus)
                {
                    filteredVehiclesInGarageList.Add(licenseNumber);
                }
            }

            return filteredVehiclesInGarageList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, string i_NewVehicleStatus)
        {
            bool vehicleInGarage = false;
            eVehicleStatus newVehicleStatus;

            vehicleInGarage = VehicleIsExistInGarage(i_LicenseNumber);
            if (vehicleInGarage)
            {
                newVehicleStatus = InputValidation<eVehicleStatus>(i_NewVehicleStatus);
                m_VehicleInGarageDict[i_LicenseNumber].VehicleStatus = newVehicleStatus;
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }
        }

        public void FillAirPressureToMax(string i_LicenseNumber)
        {
            bool vehicleInGarage = false;

            vehicleInGarage = VehicleIsExistInGarage(i_LicenseNumber);
            if (vehicleInGarage)
            {
                m_VehicleInGarageDict[i_LicenseNumber].Vehicle.FillAirPressureToMax();
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }
        }

        public void AddFuelToVehicle(string i_LicenseNumber, float i_LitersToAdd, string i_FuelType)
        {
            bool vehicleInGarage = false;
            eFuelType vehicleFuelType;
            RegularVehicles regularVehicle;

            vehicleInGarage = VehicleIsExistInGarage(i_LicenseNumber);
            if (vehicleInGarage)
            {
                vehicleFuelType = InputValidation<eFuelType>(i_FuelType);
                regularVehicle = m_VehicleInGarageDict[i_LicenseNumber].Vehicle as RegularVehicles;
                if (regularVehicle != null)
                {
                    regularVehicle.AddFuel(i_LitersToAdd, vehicleFuelType);
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with license number '{0}' is an electric vehicle that can not be refueled", i_LicenseNumber));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }
        }

        public void ChargeBatteryCharge(string i_LicenseNumber, int i_MinutesToAdd)
        {
            bool vehicleInGarage = false;
            ElectricVehicles electricVehicle;

            vehicleInGarage = VehicleIsExistInGarage(i_LicenseNumber);
            if (vehicleInGarage)
            {
                electricVehicle = m_VehicleInGarageDict[i_LicenseNumber].Vehicle as ElectricVehicles;
                if (electricVehicle != null)
                {
                    electricVehicle.BatteryCharge(i_MinutesToAdd / 60);
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with license number '{0}' is a regular vehicle that can not be charged", i_LicenseNumber));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }
        }

        public string GetVehicleDetails(string i_LicenseNumber)
        {
            bool vehicleInGarage = false;
            string vehicleInGarageDetails, vehicleAllDetails;

            vehicleInGarage = VehicleIsExistInGarage(i_LicenseNumber);
            if (vehicleInGarage)
            {
                vehicleInGarageDetails = string.Format(
                @"Vehicle Owner: {0}
Vehicle Status: {1}
",
                m_VehicleInGarageDict[i_LicenseNumber].VehicleOwner,
                m_VehicleInGarageDict[i_LicenseNumber].VehicleStatus.ToString());
                vehicleAllDetails = vehicleInGarageDetails + m_VehicleInGarageDict[i_LicenseNumber].Vehicle.ToString();
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }

            return vehicleAllDetails;
        }

        public bool VehicleIsExistInGarage(string i_LicenseNumber)
        {
            return m_VehicleInGarageDict.ContainsKey(i_LicenseNumber);
        }

        public T InputValidation<T>(string i_VehiclesStatusToShow)
        {
            T statusToShow = default(T);

            if (Enum.IsDefined(typeof(T), i_VehiclesStatusToShow))
            {
                statusToShow = (T)Enum.Parse(typeof(T), i_VehiclesStatusToShow);
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid parameter - {0}", i_VehiclesStatusToShow));
            }

            return (T)statusToShow;
        }
    }
}
