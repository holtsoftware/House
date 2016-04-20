using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;

namespace Sannel.House.Control.Data
{
	// Ported from Spark funs library located here https://github.com/sparkfun/SparkFun_BME280_Arduino_Library
	public class BME280 : IDisposable
	{
		#region Registers
		//Register names:
		public const byte BME280_DIG_T1_LSB_REG = 0x88;
		public const byte BME280_DIG_T1_MSB_REG = 0x89;
		public const byte BME280_DIG_T2_LSB_REG = 0x8A;
		public const byte BME280_DIG_T2_MSB_REG = 0x8B;
		public const byte BME280_DIG_T3_LSB_REG = 0x8C;
		public const byte BME280_DIG_T3_MSB_REG = 0x8D;
		public const byte BME280_DIG_P1_LSB_REG = 0x8E;
		public const byte BME280_DIG_P1_MSB_REG = 0x8F;
		public const byte BME280_DIG_P2_LSB_REG = 0x90;
		public const byte BME280_DIG_P2_MSB_REG = 0x91;
		public const byte BME280_DIG_P3_LSB_REG = 0x92;
		public const byte BME280_DIG_P3_MSB_REG = 0x93;
		public const byte BME280_DIG_P4_LSB_REG = 0x94;
		public const byte BME280_DIG_P4_MSB_REG = 0x95;
		public const byte BME280_DIG_P5_LSB_REG = 0x96;
		public const byte BME280_DIG_P5_MSB_REG = 0x97;
		public const byte BME280_DIG_P6_LSB_REG = 0x98;
		public const byte BME280_DIG_P6_MSB_REG = 0x99;
		public const byte BME280_DIG_P7_LSB_REG = 0x9A;
		public const byte BME280_DIG_P7_MSB_REG = 0x9B;
		public const byte BME280_DIG_P8_LSB_REG = 0x9C;
		public const byte BME280_DIG_P8_MSB_REG = 0x9D;
		public const byte BME280_DIG_P9_LSB_REG = 0x9E;
		public const byte BME280_DIG_P9_MSB_REG = 0x9F;
		public const byte BME280_DIG_H1_REG = 0xA1;
		public const byte BME280_CHIP_ID_REG = 0xD0; //Chip ID
		public const byte BME280_RST_REG = 0xE0;//Softreset Reg
		public const byte BME280_DIG_H2_LSB_REG = 0xE1;
		public const byte BME280_DIG_H2_MSB_REG = 0xE2;
		public const byte BME280_DIG_H3_REG = 0xE3;
		public const byte BME280_DIG_H4_MSB_REG = 0xE4;
		public const byte BME280_DIG_H4_LSB_REG = 0xE5;
		public const byte BME280_DIG_H5_MSB_REG = 0xE6;
		public const byte BME280_DIG_H6_REG = 0xE7;
		public const byte BME280_CTRL_HUMIDITY_REG = 0xF2; //Ctrl Humidity Reg
		public const byte BME280_STAT_REG = 0xF3; //Status Reg
		public const byte BME280_CTRL_MEAS_REG = 0xF4; //Ctrl Measure Reg
		public const byte BME280_CONFIG_REG = 0xF5; //Configuration Reg
		public const byte BME280_PRESSURE_MSB_REG = 0xF7; //Pressure MSB
		public const byte BME280_PRESSURE_LSB_REG = 0xF8; //Pressure LSB
		public const byte BME280_PRESSURE_XLSB_REG  = 0xF9; //Pressure XLSB
		public const byte BME280_TEMPERATURE_MSB_REG = 0xFA; //Temperature MSB
		public const byte BME280_TEMPERATURE_LSB_REG = 0xFB; //Temperature LSB
		public const byte BME280_TEMPERATURE_XLSB_REG = 0xFC; //Temperature XLSB
		public const byte BME280_HUMIDITY_MSB_REG = 0xFD;//Humidity MSB
		public const byte BME280_HUMIDITY_LSB_REG = 0xFE;//Humidity LSB
		#endregion
		private I2cDevice device;
		#region calibration
		private ushort digT1;
		private short digT2;
		private short digT3;
		#endregion
		public async Task<bool> Setup()
		{
			// Get a selector string for bus "I2C1"
			string aqs = I2cDevice.GetDeviceSelector("I2C1");

			// Find the I2C bus controller with our selector string
			var dis = await DeviceInformation.FindAllAsync(aqs);
			if (dis.Count == 0)
				return false; // bus not found

			var settings = new I2cConnectionSettings(0x76);
			device = await I2cDevice.FromIdAsync(dis[0].Id, settings);

			digT1 = (ushort)((ushort)(readRegister(BME280_DIG_T1_MSB_REG) << 8) + (ushort)readRegister(BME280_DIG_T1_LSB_REG));
			digT2 = (short)((short)(readRegister(BME280_DIG_T2_MSB_REG) << 8) + (short)readRegister(BME280_DIG_T2_LSB_REG));
			digT3 = (short)((short)(readRegister(BME280_DIG_T3_MSB_REG) << 8) + (short)readRegister(BME280_DIG_T3_LSB_REG));

			return device != null;
		}

		public byte readRegister(byte id)
		{
			if(device == null)
			{
				throw new Exception("please call Setup");
			}
			var bit = new byte[1];
			var result = device.WriteReadPartial(new byte[] { id }, bit);
			if(result.Status == I2cTransferStatus.FullTransfer)
			{
				return bit[0];
			}

			return 0;
		}

		public void Dispose()
		{
		}
	}
}
