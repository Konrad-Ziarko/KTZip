// LowLevelFileAccess.h

#pragma once

using namespace System;

namespace LowLevelFileAccess {

	public ref class LowLevelAcces
	{
	public:
		array<String^>^ listAllFiles(String^ path);
		array<String^>^ listAllDirs(String^ path);
	};
}
