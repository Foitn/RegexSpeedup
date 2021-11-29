#pragma once
#include <cstdint>
#define external extern "C" __declspec(dllexport) 
external int ReplaceWhiteSpacesInCppFor(const char* input, char* output, int inputLength)
{
	bool gotFirst = false;
	int numberOfChars = 0;
	int index = 0;
	while (input[index] == ' ')index++;
	for (; index < inputLength; index++)
	{
		char c = input[index];
		//uint16_t space = ' ' << 8;
		if ((c == ' ' || c == '\t'<<8) && gotFirst)
		{
			continue;
		}
		else if (c == ' ')
		{
			gotFirst = true;
		}
		else
		{
			gotFirst = false;
		}
		output[numberOfChars++] = c;
	}
	if (gotFirst) numberOfChars--;
	return numberOfChars;
}

extern "C"             //No name mangling
__declspec(dllexport)  //Tells the compiler to export the function
int                    //Function return type     
__cdecl                //Specifies calling convention, cdelc is default, 
					   //so this can be omitted 
	test(uint32_t * input, uint32_t * output, int amount)
{
	for (int i = 0; i < amount; i++)
	{
		output[i] = input[i];
	}
	return amount;
}