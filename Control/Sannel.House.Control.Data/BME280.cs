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
		private ushort digP1;
		private short digP2;
		private short digP3;
		private short digP4;
		private short digP5;
		private short digP6;
		private short digP7;
		private short digP8;
		private short digP9;

		private byte digH1;
		private short digH2;
		private byte digH3;
		private short digH4;
		private short digH5;
		private byte digH6;
		#endregion

		#region Settings
		//renMode can be:
		//  0, Sleep mode
		//  1 or 2, Forced mode
		//  3, Normal mode
		private const byte runMode = 3;

		//tStandby can be:
		//  0, 0.5ms
		//  1, 62.5ms
		//  2, 125ms
		//  3, 250ms
		//  4, 500ms
		//  5, 1000ms
		//  6, 10ms
		//  7, 20ms
		private const byte tStandby = 0;

		//filter can be off or number of FIR coefficients to use:
		//  0, filter off
		//  1, coefficients = 2
		//  2, coefficients = 4
		//  3, coefficients = 8
		//  4, coefficients = 16
		private const byte filter = 0;

		//tempOverSample can be:
		//  0, skipped
		//  1 through 5, oversampling *1, *2, *4, *8, *16 respectively
		private const byte tempOverSample = 1;

		//pressOverSample can be:
		//  0, skipped
		//  1 through 5, oversampling *1, *2, *4, *8, *16 respectively
		private const byte pressOverSample = 1;

		//humidOverSample can be:
		//  0, skipped
		//  1 through 5, oversampling *1, *2, *4, *8, *16 respectively
		private const byte humidOverSample = 1;
		#endregion

		private long tFine = -9999;

		public bool IsSetup { get { return device != null; } }
		public async Task<bool> SetupAsync()
		{
			// Get a selector string for bus "I2C1"
			string aqs = I2cDevice.GetDeviceSelector("I2C1");

			// Find the I2C bus controller with our selector string
			var dis = await DeviceInformation.FindAllAsync(aqs);
			if (dis.Count == 0)
				return false; // bus not found

			var settings = new I2cConnectionSettings(0x76);
			device = await I2cDevice.FromIdAsync(dis[0].Id, settings);
			if(device == null)
			{
				return false;
			}

			digT1 = (ushort)((ushort)(readRegister(BME280_DIG_T1_MSB_REG) << 8) + (ushort)readRegister(BME280_DIG_T1_LSB_REG));
			digT2 = (short)((short)(readRegister(BME280_DIG_T2_MSB_REG) << 8) + (short)readRegister(BME280_DIG_T2_LSB_REG));
			digT3 = (short)((short)(readRegister(BME280_DIG_T3_MSB_REG) << 8) + (short)readRegister(BME280_DIG_T3_LSB_REG));

			digP1 = ((ushort)((readRegister(BME280_DIG_P1_MSB_REG) << 8) + readRegister(BME280_DIG_P1_LSB_REG)));
			digP2 = ((short)((readRegister(BME280_DIG_P2_MSB_REG) << 8) + readRegister(BME280_DIG_P2_LSB_REG)));
			digP3 = ((short)((readRegister(BME280_DIG_P3_MSB_REG) << 8) + readRegister(BME280_DIG_P3_LSB_REG)));
			digP4 = ((short)((readRegister(BME280_DIG_P4_MSB_REG) << 8) + readRegister(BME280_DIG_P4_LSB_REG)));
			digP5 = ((short)((readRegister(BME280_DIG_P5_MSB_REG) << 8) + readRegister(BME280_DIG_P5_LSB_REG)));
			digP6 = ((short)((readRegister(BME280_DIG_P6_MSB_REG) << 8) + readRegister(BME280_DIG_P6_LSB_REG)));
			digP7 = ((short)((readRegister(BME280_DIG_P7_MSB_REG) << 8) + readRegister(BME280_DIG_P7_LSB_REG)));
			digP8 = ((short)((readRegister(BME280_DIG_P8_MSB_REG) << 8) + readRegister(BME280_DIG_P8_LSB_REG)));
			digP9 = ((short)((readRegister(BME280_DIG_P9_MSB_REG) << 8) + readRegister(BME280_DIG_P9_LSB_REG)));

			digH1 = readRegister(BME280_DIG_H1_REG);
			digH2 = ((short)((readRegister(BME280_DIG_H2_MSB_REG) << 8) + readRegister(BME280_DIG_H2_LSB_REG)));
			digH3 = readRegister(BME280_DIG_H3_REG);
			digH4 = ((short)((readRegister(BME280_DIG_H4_MSB_REG) << 4) + (readRegister(BME280_DIG_H4_LSB_REG) & 0x0F)));
			digH5 = ((short)((readRegister(BME280_DIG_H5_MSB_REG) << 4) + ((readRegister(BME280_DIG_H4_LSB_REG) >> 4) & 0x0F)));
			digH6 = readRegister(BME280_DIG_H6_REG);
			//Set the oversampling control words.
			//config will only be writeable in sleep mode, so first insure that.
			writeRegister(BME280_CTRL_MEAS_REG, 0x00);

			//Set the config word
			byte dataToWrite = (tStandby << 0x5) & 0xE0;
			dataToWrite |= (filter << 0x02) & 0x1C;
			writeRegister(BME280_CONFIG_REG, dataToWrite);

			//Set ctrl_hum first, then ctrl_meas to activate ctrl_hum
			dataToWrite = humidOverSample & 0x07; //all other bits can be ignored
			writeRegister(BME280_CTRL_HUMIDITY_REG, dataToWrite);

			//set ctrl_meas
			//First, set temp oversampling
			dataToWrite = (tempOverSample << 0x5) & 0xE0;
			//Next, pressure oversampling
			dataToWrite |= (pressOverSample << 0x02) & 0x1C;
			//Last, set mode
			dataToWrite |= (runMode) & 0x03;
			//Load the byte
			writeRegister(BME280_CTRL_MEAS_REG, dataToWrite);
			return true;
		}

		private void writeRegister(byte offset, byte dataToWrite)
		{
			device.Write(new byte[] { offset, dataToWrite });
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

		public float ReadTemperatureCelsius()
		{
			// Returns temperature in DegC, resolution is 0.01 DegC. Output value of “5123” equals 51.23 DegC.
			// t_fine carries fine temperature as global value

			//get the reading (adc_T);
			int adc_T = (int)(((uint)readRegister(BME280_TEMPERATURE_MSB_REG) << 12) | ((uint)readRegister(BME280_TEMPERATURE_LSB_REG) << 4) | (((uint)readRegister(BME280_TEMPERATURE_XLSB_REG) >> 4) & 0x0F));

			//By datasheet, calibrate
			long var1, var2;

			var1 = ((((adc_T >> 3) - (digT1 << 1))) * (digT2) >> 11);
			var2 = ((((adc_T >> 4) - (digT1) * ((adc_T >> 4) - (digT1))) >> 12) *
			(digT3) >> 14);
			tFine = var1 + var2;
			float output = (tFine * 5 + 128) >> 8;

			output = output / 100;

			return output;
		}

		public static float ConvertToFahrenheit(float celsius)
		{
			var output = (celsius * 9) / 5 + 32;
			return output;
		}

		public float ReadPressure()
		{
			if(tFine == -9999)
			{
				ReadTemperatureCelsius();
			}
			// Returns pressure in Pa as unsigned 32 bit integer in Q24.8 format (24 integer bits and 8 fractional bits).
			// Output value of “24674867” represents 24674867/256 = 96386.2 Pa = 963.862 hPa
			int adc_P = (int)(((uint)readRegister(BME280_PRESSURE_MSB_REG) << 12) | ((uint)readRegister(BME280_PRESSURE_LSB_REG) << 4) | (uint)((readRegister(BME280_PRESSURE_XLSB_REG) >> 4) & 0x0F));

			long var1, var2, p_acc;
			var1 = (tFine) - 128000;
			var2 = var1 * var1 * (long)digP6;
			var2 = var2 + ((var1 * (long)digP5) << 17);
			var2 = var2 + (((long)digP4) << 35);
			var1 = ((var1 * var1 * (long)digP3) >> 8) + ((var1 * (long)digP2) << 12);
			var1 = (((((long)1) << 47) + var1)) * ((long)digP1) >> 33;
			if (var1 == 0)
			{
				return 0; // avoid exception caused by division by zero
			}
			p_acc = 1048576 - adc_P;
			p_acc = (((p_acc << 31) - var2) * 3125) / var1;
			var1 = (((long)digP9) * (p_acc >> 13) * (p_acc >> 13)) >> 25;
			var2 = (((long)digP8) * p_acc) >> 19;
			p_acc = ((p_acc + var1 + var2) >> 8) + (((long)digP7) << 4);

			p_acc = p_acc >> 8; // /256
			return (float)p_acc;
		}

		public static float PressureAsAltitudeMeters(float pressure)
		{
			float heightOutput = 0;

			heightOutput = ((float)-45846.2) * ((float)Math.Pow((pressure / (float)101325), 0.190263) - (float)1);
			return heightOutput;
		}

		public static float PressureAsAltitudeFeet(float pressure)
		{
			return PressureAsAltitudeMeters(pressure) * 3.28084f;
		}

		public float ReadHumidity()
		{
			if (tFine == -9999)
			{
				ReadTemperatureCelsius();
			}

			// Returns humidity in %RH as unsigned 32 bit integer in Q22. 10 format (22 integer and 10 fractional bits).
			// Output value of “47445” represents 47445/1024 = 46. 333 %RH
			int adc_H = (int)(((uint)readRegister(BME280_HUMIDITY_MSB_REG) << 8) | ((uint)readRegister(BME280_HUMIDITY_LSB_REG)));

			int var1;
			var1 = ((int)tFine - ((int)76800));
			var1 = (((((adc_H << 14) - (((int)digH4) << 20) - (((int)digH5) * var1)) +
			((int)16384)) >> 15) * (((((((var1 * ((int)digH6)) >> 10) * (((var1 * ((int)digH3)) >> 11) + ((int)32768))) >> 10) + ((int)2097152)) *
			((int)digH2) + 8192) >> 14));
			var1 = (var1 - (((((var1 >> 15) * (var1 >> 15)) >> 7) * ((int)digH1)) >> 4));
			var1 = (var1 < 0 ? 0 : var1);
			var1 = (var1 > 419430400 ? 419430400 : var1);

			return (float)((var1 >> 12) >> 10);

		}

		public static float HumidityToRH(float humidity)
		{
			return humidity / 1024;
		}

		public void Dispose()
		{
			device?.Dispose();
		}
	}
}
