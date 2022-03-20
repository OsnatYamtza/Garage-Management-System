using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // $G$ DSN-001 (-5) Code duplication. except in energy type, gas and electric car are identical. 
    public class ElectricCar : ElectricVehicles
    {
        private const int k_WheelsNumber = 4;
        private const int k_MaxAirPressure = 29;
        private const float k_BatteryMaxTime = 2.6f;
        private eCarColors m_CarColor;
        private eCarDoorsNumber m_DoorsNumber;
        private List<Wheel> m_CarWheels;

        public ElectricCar(
    string i_WheelsManufacturer,
    float i_WheelsCurrentAirPressure,
    eCarColors i_CarColor,
    eCarDoorsNumber i_DoorsNumber,
    float i_BatteryLeftTime,
    string i_Model,
    string i_LicenseNumber,
    float i_LeftedEnergyPrecent)
    : base(i_BatteryLeftTime, k_BatteryMaxTime, i_Model, i_LicenseNumber, i_LeftedEnergyPrecent)
        {
            m_CarColor = i_CarColor;
            m_DoorsNumber = i_DoorsNumber;
            m_CarWheels = new List<Wheel>();
            for (int i = 0; i < k_WheelsNumber; i++)
            {
                m_CarWheels.Add(new Wheel(i_WheelsManufacturer, i_WheelsCurrentAirPressure, k_MaxAirPressure));
            }

            Wheels = m_CarWheels;
        }

        public eCarColors CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public eCarDoorsNumber DoorsNumber
        {
            get
            {
                return m_DoorsNumber;
            }

            set
            {
                m_DoorsNumber = value;
            }
        }

        public List<Wheel> CarWheels
        {
            get
            {
                return m_CarWheels;
            }

            set
            {
                m_CarWheels = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0} 
Car Color: {1}
Doors Number: {2}
",
                base.ToString(),
                m_CarColor.ToString(),
                m_DoorsNumber.ToString());
        }
    }
}
