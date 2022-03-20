using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private float m_LeftedEnergyPrecent;
        private List<Wheel> m_Wheels;

        public Vehicle(string i_Model, string i_LicenseNumber, float i_LeftedEnergyPrecent)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            if (i_LeftedEnergyPrecent <= 0 && i_LeftedEnergyPrecent >= 100)
            {
                throw new ValueOutOfRangeException(
                    100,
                    0,
                    "Invalid precent value!");
            }
            else
            {
                m_LeftedEnergyPrecent = i_LeftedEnergyPrecent;
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }

            set
            {
                m_Model = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        public float LeftedEnergyPrecent
        {
            get
            {
                return m_LeftedEnergyPrecent;
            }

            set
            {
                m_LeftedEnergyPrecent = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

        public void FillAirPressureToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.FillAirPressure(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"Model Name: {0} 
Lisence Number: {1}
Lefted Energy Precent: {2}
Wheels: {3}",
                m_Model,
                m_LicenseNumber,
                m_LeftedEnergyPrecent,
                m_Wheels[0].ToString());
        }

        public void SetVehicleLicenseNumber(string i_LicenseNumber)
        {
            m_LicenseNumber = i_LicenseNumber;
        }
    }
}
