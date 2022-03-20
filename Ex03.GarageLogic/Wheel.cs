using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float m_MaxAirPressure;
        private string m_Manufacturer;
        private float m_CurrentAirPressure;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_MaxAirPressure = i_MaxAirPressure;
            if (i_CurrentAirPressure <= i_MaxAirPressure)
            {
                m_CurrentAirPressure = i_CurrentAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    m_MaxAirPressure,
                    0,
                    "Current wheel air pressure exceeds the maximum air pressure!");
            }
        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }

            set
            {
                m_Manufacturer = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                if (value < m_MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(
                        m_MaxAirPressure,
                        0,
                        "Current wheel air pressure exceeds the maximum air pressure!");
                }
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public void FillAirPressure(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    m_MaxAirPressure,
                    0,
                    "wheel air pressure exceeds the maximum air pressure!");
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"Manufacture: {0}
        Current Air Pressure: {1}
        Max Air Pressure: {2}",
                m_Manufacturer,
                m_CurrentAirPressure.ToString(),
                m_MaxAirPressure.ToString());
        }
    }
}
