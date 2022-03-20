using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class RegularVehicles : Vehicle
    {
        private readonly float r_MaxFuelAmount;
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelAmount;

        public RegularVehicles(
    eFuelType i_FuelType,
    float i_CurrentFuelAmount,
    float i_MaxFuelAmount,
    string i_Model,
    string i_LicenseNumber,
    float i_LeftedEnergyPrecent)
    : base(i_Model, i_LicenseNumber, i_LeftedEnergyPrecent)
        {
            r_FuelType = i_FuelType;
            if (i_CurrentFuelAmount < i_MaxFuelAmount)
            {
                m_CurrentFuelAmount = i_CurrentFuelAmount;
                r_MaxFuelAmount = i_MaxFuelAmount;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    i_MaxFuelAmount,
                    0,
                    string.Format("Fuel amount {0} exceeds max fuel amount {1}!", m_CurrentFuelAmount, r_MaxFuelAmount));
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmount;
            }

            set
            {
                m_CurrentFuelAmount = value;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return r_MaxFuelAmount;
            }
        }

        public void AddFuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            bool fuelAmountValidation, fuelTypeValidation;

            fuelAmountValidation = m_CurrentFuelAmount + i_LitersToAdd <= r_MaxFuelAmount;
            fuelTypeValidation = r_FuelType == i_FuelType;

            if (fuelAmountValidation && fuelTypeValidation)
            {
                m_CurrentFuelAmount += i_LitersToAdd;
            }
            else if (!fuelAmountValidation)
            {
                throw new ValueOutOfRangeException(
                    r_MaxFuelAmount,
                    0,
                    string.Format("Fuel amount {0} exceeds max fuel amount {1}!", m_CurrentFuelAmount + i_LitersToAdd, r_MaxFuelAmount));
            }
            else
            {
                throw new ArgumentException(string.Format("Fuel Type '{0}' is not fit to requested fuel type '{1}'", i_FuelType, r_FuelType));
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0} 
Fuel Type: {1}
Current Fuel Amount: {2}
Max Fuel Amount: {3}",
                base.ToString(),
                r_FuelType.ToString(),
                m_CurrentFuelAmount,
                r_MaxFuelAmount);
        }
    }
}
