// This is the main DLL file.

#include "stdafx.h"

#include "FileAccess.h"

using namespace System::IO;

array<String^>^ LowLevelFileAccess::LowLevelAcces::listAllFiles(String^ path)
{
	array<String^>^ files = Directory::GetFiles(path);
	return files;
}

array<String^>^ LowLevelFileAccess::LowLevelAcces::listAllDirs(String ^ path)
{
	array<String^>^ dirs = Directory::GetDirectories(path);
	return dirs;
}
