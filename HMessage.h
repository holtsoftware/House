#pragma once

namespace HouseShared
{
	public enum class HMessageType {
		Other=0,
		TempLog=1
	};
	public ref class HMessage sealed
	{
	private:
		HMessageType mtype;
		// [length][id][device_1][device_2][arg1_a][arg1_b][arg1_c][arg1_d][arg2_a][arg2_b][arg2_c][arg2_d][arg3_a][arg3_b][arg3_c][arg3_d][arg4_a][arg4_b][arg4_c][arg4_d]	
		//char[] data = char[255];

	public:
		property HMessageType MessageType
		{
			HMessageType get() { return mtype; }
		}
		HMessage();
	};
}
