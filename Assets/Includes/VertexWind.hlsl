#ifndef VERTEX_WIND_INCLUDED
#define VERTEX_WIND_INCLUDED

void wind_simplified_float(half3 vertex_xyz, half4 color, half _WaveFreq, half _WaveHeight, half _WaveScale, out float3 wind_xyz) {
	half phase_slow = _Time * _WaveFreq;
	half phase_med = _Time * 3 * _WaveFreq;
	half phase_fast = _Time * 5 * _WaveFreq;
	           
	half offset = (vertex_xyz.x + (vertex_xyz.z * _WaveScale)) * _WaveScale;
	half offset2 = (vertex_xyz.x + (vertex_xyz.z * _WaveScale * 3)) * _WaveScale * 3;
	half offset3 = (vertex_xyz.x + (vertex_xyz.z * _WaveScale * 5)) * _WaveScale * 5;

	         
	half sin1 = sin(phase_slow + offset);
	half sin2 = sin(phase_med + offset2);  
	half sin3 = sin(phase_fast + offset3);        
	 
	half sin_combined = (sin1 * 4) + sin2 + (sin3 * 0.5) ;


	           
	half wind_factor =  sin_combined * _WaveHeight * 0.1;
	wind_factor = wind_factor * color.r;
	wind_xyz = float3(wind_factor, wind_factor * 0.2, wind_factor);


	//wind_xyz = wind_xyz * pow(color.r, 2);
	wind_xyz = mul(unity_WorldToObject, half4(wind_xyz, 0.0)); 

	// return wind_xyz;
}

#endif
