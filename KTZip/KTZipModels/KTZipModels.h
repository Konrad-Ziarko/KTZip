// KTZipModels.h

#pragma once
#include <string>
#include <Windows.h>
#include <sstream>
#include <iomanip>
using namespace System;

namespace KTZipModels {

	public ref class FileInfoGeter
	{
	public:
		char* fileName;
		FileInfoGeter(char* filename);
		long GetFileSize();
		char* GetCeationAndLastWriteTime();
	};
}
