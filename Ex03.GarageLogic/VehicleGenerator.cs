using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // $G$ DSN-011 (-5) if we added a new vehical type, this class will be modified.
    public class VehicleGenerator
    {
        public RegularMotorcycle CreateRegularMotorcycle(
            string i_WheelsManufacturer,
            float i_WheelsCurrentAirPressure,
            eLicenseType i_LicenseType,
            int i_EngineDisplacement,
            float i_CurrentFuelAmount,
            string i_Model,
            string i_LicenseNumber,
            float i_LeftedEnergyPrecent)
        {
            RegularMotorcycle regularMotorcycle;

            regularMotorcycle = new RegularMotorcycle(i_WheelsManufacturer, i_WheelsCurrentAirPressure, i_LicenseType, i_EngineDisplacement, i_CurrentFuelAmount, i_Model, i_LicenseNumber, i_LeftedEnergyPrecent);

            return regularMotorcycle;
        }

        public ElectricMotorcycle CreateElectricMotorcycle(
            string i_WheelsManufacturer,
            float i_WheelsCurrentAirPressure,
            eLicenseType i_LicenseType,
            int i_EngineDisplacement,
            float i_BatteryLeftTime,
            string i_Model,
            string i_LicenseNumber,
            float i_LeftedEnergyPrecent)
        {
            ElectricMotorcycle m_ElectricMotorcycle;

            m_ElectricMotorcycle = new ElectricMotorcycle(i_WheelsManufacturer, i_WheelsCurrentAirPressure, i_LicenseType, i_EngineDisplacement, i_BatteryLeftTime, i_Model, i_LicenseNumber, i_LeftedEnergyPrecent);

            return m_ElectricMotorcycle;
        }

        public RegularCar CreateRegularCar(
            string i_WheelsManufacturer,
            float i_WheelsCurrentAirPressure,
            eCarColors i_CarColor,
            eCarDoorsNumber i_DoorsNumber,
            float i_CurrentFuelAmount,
            string i_Model,
            string i_LicenseNumber,
            float i_LeftedEnergyPrecent)
        {
            RegularCar m_RegularCar;

            m_RegularCar = new RegularCar(i_WheelsManufacturer, i_WheelsCurrentAirPressure, i_CarColor, i_DoorsNumber, i_CurrentFuelAmount, i_Model, i_LicenseNumber, i_LeftedEnergyPrecent);

            return m_RegularCar;
        }

        public ElectricCar CreateElectricCar(
            string i_WheelsManufacturer,
            float i_WheelsCurrentAirPressure,
            eCarColors i_CarColor,
            eCarDoorsNumber i_DoorsNumber,
            float i_BatteryLeftTime,
            string i_Model,
            string i_LicenseNumber,
            float i_LeftedEnergyPrecent)
        {
            ElectricCar m_ElectricCar;

            m_ElectricCar = new ElectricCar(i_WheelsManufacturer, i_WheelsCurrentAirPressure, i_CarColor, i_DoorsNumber, i_BatteryLeftTime, i_Model, i_LicenseNumber, i_LeftedEnergyPrecent);

            return m_ElectricCar;
        }

        public Truck CreateTruck(
            string i_WheelsManufacturer,
            float i_WheelsCurrentAirPressure,
            bool i_IsTransportingRefrigeratedIngredient,
            float i_CargoCapacity,
            float i_CurrentFuelAmount,
            string i_Model,
            string i_LicenseNumber,
            float i_LeftedEnergyPrecent)
        {
            Truck m_Truck;

            m_Truck = new Truck(i_WheelsManufacturer, i_WheelsCurrentAirPressure, i_IsTransportingRefrigeratedIngredient, i_CargoCapacity, i_CurrentFuelAmount, i_Model, i_LicenseNumber, i_LeftedEnergyPrecent);

            return m_Truck;
        }
    }
}
