using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : RegularVehicles
    {
        private const float k_MaxFuelTank = 130f;
        private const int k_MaxAirPressure = 25;
        private const int k_WheelsNumber = 16;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;
        private bool m_IsTransportingRefrigeratedIngredient;
        private float m_CargoCapacity;
        private List<Wheel> m_TruckWheels;

        public Truck(
    string i_WheelsManufacturer,
    float i_WheelsCurrentAirPressure,
    bool i_IsTransportingRefrigeratedIngredient,
    float i_CargoCapacity,
    float i_CurrentFuelAmount,
    string i_Model,
    string i_LicenseNumber,
    float i_LeftedEnergyPrecent)
    : base(k_TruckFuelType, i_CurrentFuelAmount, k_MaxFuelTank, i_Model, i_LicenseNumber, i_LeftedEnergyPrecent)
        {
            m_IsTransportingRefrigeratedIngredient = i_IsTransportingRefrigeratedIngredient;
            m_CargoCapacity = i_CargoCapacity;
            m_TruckWheels = new List<Wheel>();
            for (int i = 0; i < k_WheelsNumber; i++)
            {
                m_TruckWheels.Add(new Wheel(i_WheelsManufacturer, i_WheelsCurrentAirPressure, k_MaxAirPressure));
            }

            Wheels = m_TruckWheels;
        }

        public bool IsTransportingRefrigeratedIngredient
        {
            get
            {
                return m_IsTransportingRefrigeratedIngredient;
            }

            set
            {
                m_IsTransportingRefrigeratedIngredient = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }

            set
            {
                m_CargoCapacity = value;
            }
        }

        public override string ToString()
        {
            string truckDetails;

            if (m_IsTransportingRefrigeratedIngredient)
            {
                truckDetails = string.Format(
                @"{0} 
                Truck Transporting Refrigerated Ingredient
                Cargo Capacity: {1}",
                base.ToString(),
                m_CargoCapacity);
            }
            else
            {
                truckDetails = string.Format(
                    @"{0} 
Truck Is Not Transporting Refrigerated Ingredient
Cargo Capacity: {1}
",
                    base.ToString(),
                    m_CargoCapacity);
            }

            return truckDetails;
        }
    }
}
